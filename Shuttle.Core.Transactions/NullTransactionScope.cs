using System;

namespace Shuttle.Core.Transactions
{
    public class NullTransactionScope : ITransactionScope
    {
        public Guid Id => Guid.Empty;

        public void Complete()
        {
        }

        public void Dispose()
        {
        }
    }
}