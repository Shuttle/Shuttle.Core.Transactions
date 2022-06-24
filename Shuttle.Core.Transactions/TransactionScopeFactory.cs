using System;
using System.Transactions;
using Microsoft.Extensions.Options;
using Shuttle.Core.Contract;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeFactory : ITransactionScopeFactory
    {
        private readonly TransactionScopeSettings _settings;

        public TransactionScopeFactory(IOptions<TransactionScopeSettings> options)
        {
            Guard.AgainstNull(options, nameof(options));
            
            _settings = options.Value;
        }
        public ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout)
        {
            return new DefaultTransactionScope(_settings.IsolationLevel, _settings.Timeout);
        }
    }
}