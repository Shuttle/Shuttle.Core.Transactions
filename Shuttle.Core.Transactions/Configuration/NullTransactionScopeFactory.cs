using System;
using System.Transactions;
using Shuttle.Core.Transactions;

namespace Shuttle.Core.Data
{
    public class NullTransactionScopeFactory : ITransactionScopeFactory
    {
        private static readonly ITransactionScope NullTransactionScope = new NullTransactionScope();

        public ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout)
        {
            return NullTransactionScope;
        }

        public IsolationLevel IsolationLevel => IsolationLevel.Unspecified;
        public TimeSpan Timeout => TimeSpan.Zero;
    }
}