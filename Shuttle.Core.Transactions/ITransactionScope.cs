using System;

namespace Shuttle.Core.Transactions
{
    public interface ITransactionScope : IDisposable
    {
        Guid Id { get; }
        void Complete();
    }
}