using System;

namespace Shuttle.Core.Transactions
{
    public interface ITransactionScope : IDisposable
    {
        string Name { get; }
        void Complete();
    }
}