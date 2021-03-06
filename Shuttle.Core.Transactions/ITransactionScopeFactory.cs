using System;
using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public interface ITransactionScopeFactory
    {
        ITransactionScope Create(string name);
        ITransactionScope Create(string name, IsolationLevel isolationLevel, TimeSpan timeout);
        ITransactionScope Create();
        ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout);
    }
}