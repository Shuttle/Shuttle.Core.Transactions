using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public interface ITransactionScopeConfiguration
    {
        bool Enabled { get; }
        IsolationLevel IsolationLevel { get; }
        int TimeoutSeconds { get; }
    }
}