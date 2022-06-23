using System;
using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeFactory : ITransactionScopeFactory
    {
        public TransactionScopeFactory(IsolationLevel isolationIsolationLevel, TimeSpan timeout)
        {
            IsolationLevel = isolationIsolationLevel;
            Timeout = timeout;
        }
        public IsolationLevel IsolationLevel { get; }
        public TimeSpan Timeout { get; }

        public ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout)
        {
            return new DefaultTransactionScope(IsolationLevel, Timeout);
        }
    }
}