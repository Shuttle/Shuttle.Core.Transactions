using System;
using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public interface ITransactionScopeFactory
    {
        ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout);
        IsolationLevel IsolationLevel { get; }
        TimeSpan Timeout { get; }
    }
}