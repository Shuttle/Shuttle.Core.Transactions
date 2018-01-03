using System;
using System.Configuration;
using System.Transactions;
using Shuttle.Core.Configuration;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeSection : ConfigurationSection
    {
        private const int DefaultTimeoutSeconds = 30;
        private const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadCommitted;
        private static bool _initialized;
        private static readonly object Padlock = new object();
        private static TransactionScopeSection _section;

        [ConfigurationProperty("enabled", IsRequired = false, DefaultValue = true)]
        public bool Enabled => (bool) this["enabled"];

        [ConfigurationProperty("isolationLevel", IsRequired = false, DefaultValue = DefaultIsolationLevel)]
        public IsolationLevel IsolationLevel
        {
            get
            {
                var value = this["isolationLevel"];

                if (string.IsNullOrEmpty(value?.ToString()))
                {
                    return DefaultIsolationLevel;
                }

                try
                {
                    return (IsolationLevel) Enum.Parse(typeof(IsolationLevel), value.ToString());
                }
                catch
                {
                    return DefaultIsolationLevel;
                }
            }
        }

        [ConfigurationProperty("timeoutSeconds", IsRequired = false, DefaultValue = "30")]
        public int TimeoutSeconds
        {
            get
            {
                var value = this["timeoutSeconds"].ToString();

                if (string.IsNullOrEmpty(value))
                {
                    return DefaultTimeoutSeconds;
                }

                return int.TryParse(value, out var result) ? result : DefaultTimeoutSeconds;
            }
        }

        public static TransactionScopeSection Get()
        {
            lock (Padlock)
            {
                if (!_initialized)
                {
                    _section =
                        ConfigurationSectionProvider.Open<TransactionScopeSection>("shuttle", "transactionScope");

                    _initialized = true;
                }

                return _section;
            }
        }
    }
}