﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;

namespace Shuttle.Core.Transactions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionScope(this IServiceCollection services, Action<TransactionScopeBuilder> builder = null)
        {
            Guard.AgainstNull(services, nameof(services));

            var transactionScopeBuilder = new TransactionScopeBuilder(services);

            builder?.Invoke(transactionScopeBuilder);

            services.AddOptions<TransactionScopeOptions>().Configure(options =>
            {
                options.IsolationLevel = transactionScopeBuilder.Options.IsolationLevel;
                options.Timeout = transactionScopeBuilder.Options.Timeout;
                options.Enabled = transactionScopeBuilder.Options.Enabled;
            });

            if (services.Contains(ServiceDescriptor.Singleton<ITransactionScopeFactory, TransactionScopeFactory>()))
            {
                throw new InvalidOperationException(Resources.AddTransactionScopeFactoryException);
            }

            services.AddSingleton<ITransactionScopeFactory, TransactionScopeFactory>();

            return services;
        }
    }
}