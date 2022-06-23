using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shuttle.Core.Contract;
using Shuttle.Core.Data;

namespace Shuttle.Core.Transactions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransactionScope(this IServiceCollection services, Action<TransactionScopeOptions> options = null)
        {
            Guard.AgainstNull(services, nameof(services));

            var transactionScopeOptions = new TransactionScopeOptions();

            options?.Invoke(transactionScopeOptions);

            services.AddOptions<TransactionScopeSettings>().Configure<IConfiguration>((option, configuration) =>
            {
                var settings = configuration.GetSection(TransactionScopeSettings.SectionName).Get<TransactionScopeSettings>();

                if (settings != null)
                {
                    option.IsolationLevel = settings.IsolationLevel;
                    option.TimeoutSeconds = settings.TimeoutSeconds;
                }

                if (transactionScopeOptions.IsolationLevel.HasValue)
                {
                    option.IsolationLevel = transactionScopeOptions.IsolationLevel.Value;
                }

                if (transactionScopeOptions.TimeoutSeconds.HasValue)
                {
                    option.TimeoutSeconds = transactionScopeOptions.TimeoutSeconds.Value;
                }
            });

            services.AddSingleton<ITransactionScopeFactory, TransactionScopeFactory>();

            return services;
        }

        public static IServiceCollection DisableTransactionScope(this IServiceCollection services)
        {
            services.AddSingleton<ITransactionScopeFactory, NullTransactionScopeFactory>();

            return services;
        }
    }
}