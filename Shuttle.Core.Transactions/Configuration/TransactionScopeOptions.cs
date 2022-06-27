using System;
using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeOptions
    {
        internal bool Enabled { get; private set; } = true;
        internal IsolationLevel? IsolationLevel { get; private set; }
        internal TimeSpan? Timeout { get; private set; }

        public TransactionScopeOptions WithIsolationLevel(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;

            return this;
        }

        public TransactionScopeOptions WithTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            
            return this;
        }

        public TransactionScopeOptions Disable()
        {
            Enabled = false;

            return this;
        }
    }
}