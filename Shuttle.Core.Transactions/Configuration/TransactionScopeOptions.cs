using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeOptions
    {
        internal IsolationLevel? IsolationLevel { get; private set; }
        internal int? TimeoutSeconds { get; private set; }

        public TransactionScopeOptions WithIsolationLevel(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;

            return this;
        }

        public TransactionScopeOptions WithTimeoutSeconds(int timeoutSeconds)
        {
            TimeoutSeconds = timeoutSeconds;
            
            return this;
        }
    }
}