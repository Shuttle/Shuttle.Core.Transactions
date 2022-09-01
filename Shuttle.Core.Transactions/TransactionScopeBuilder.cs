﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Core.Transactions
{
    public class TransactionScopeBuilder
    {
        public TransactionScopeBuilder(IServiceCollection services)
        {
            Guard.AgainstNull(services, nameof(services));

            Services = services;
        }

        private TransactionScopeOptions _transactionScopeOptions = new TransactionScopeOptions();

        public TransactionScopeOptions Options
        {
            get => _transactionScopeOptions;
            set => _transactionScopeOptions = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IServiceCollection Services { get; }
    }
}