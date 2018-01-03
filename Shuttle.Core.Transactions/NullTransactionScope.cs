namespace Shuttle.Core.Transactions
{
    public class NullTransactionScope : ITransactionScope
    {
        private const string NullTransactionScopeName = "[null transaction scope]";

        public string Name => NullTransactionScopeName;

        public void Complete()
        {
        }

        public void Dispose()
        {
        }
    }
}