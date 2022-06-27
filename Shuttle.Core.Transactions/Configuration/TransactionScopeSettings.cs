using System;
using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeSettings
    {
        public const string SectionName = "Shuttle:TransactionScope";

        public TransactionScopeSettings()
        {
            Enabled = true;
            IsolationLevel = IsolationLevel.ReadCommitted;
            Timeout = TimeSpan.FromSeconds(30);
        }

        public bool Enabled { get; set; }
        public IsolationLevel IsolationLevel { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}