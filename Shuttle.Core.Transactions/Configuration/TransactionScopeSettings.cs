using System.Transactions;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeSettings
    {
        public const string SectionName = "Shuttle:TransactionScope";

        public TransactionScopeSettings()
        {
            IsolationLevel = IsolationLevel.ReadCommitted;
            TimeoutSeconds = 30;
        }

        public IsolationLevel IsolationLevel { get; set; }
        public int TimeoutSeconds { get; set; }
    }
}