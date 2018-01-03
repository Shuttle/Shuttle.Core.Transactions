using System;
using System.Threading;
using System.Transactions;
using Shuttle.Core.Logging;

namespace Shuttle.Core.Transactions
{
    public class DefaultTransactionScope : ITransactionScope
    {
        private const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadUncommitted;
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);
        private readonly bool _ignore;

        private readonly ILog _log;
        private readonly TransactionScope _scope;

        public DefaultTransactionScope()
            : this(Guid.NewGuid().ToString("n"), DefaultIsolationLevel, DefaultTimeout)
        {
        }

        public DefaultTransactionScope(IsolationLevel isolationLevel, TimeSpan timeout)
            : this(Guid.NewGuid().ToString("n"), isolationLevel, timeout)
        {
        }

        public DefaultTransactionScope(string name)
            : this(name, DefaultIsolationLevel, DefaultTimeout)
        {
        }

        public DefaultTransactionScope(string name, IsolationLevel isolationLevel, TimeSpan timeout)
        {
            Name = name;

            _log = Log.For(this);

            _ignore = Transaction.Current != null;

            if (_ignore)
            {
                if (_log.IsVerboseEnabled)
                {
                    _log.Verbose(string.Format(Resources.VerboseTransactionScopeAmbient, name,
                        Thread.CurrentThread.ManagedThreadId));
                }

                return;
            }

            _scope = new TransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions
                {
                    IsolationLevel = isolationLevel,
                    Timeout = timeout
                });

            if (_log.IsVerboseEnabled)
            {
                _log.Verbose(string.Format(Resources.VerboseTransactionScopeCreated, name, isolationLevel,
                    timeout,
                    Thread.CurrentThread.ManagedThreadId));
            }
        }

        public string Name { get; }

        public void Dispose()
        {
            if (_scope == null)
            {
                return;
            }

            try
            {
                _scope.Dispose();
            }
            catch
            {
                // _ignore --- may be bug in transaction _scope
            }
        }

        public void Complete()
        {
            if (_ignore)
            {
                if (_log.IsVerboseEnabled)
                {
                    _log.Verbose(string.Format(Resources.VerboseTransactionScopeAmbientCompleted, Name,
                        Thread.CurrentThread.ManagedThreadId));
                }

                return;
            }

            if (_scope == null)
            {
                return;
            }

            _scope.Complete();

            if (_log.IsVerboseEnabled)
            {
                _log.Verbose(string.Format(Resources.VerboseTransactionScopeCompleted, Name,
                    Thread.CurrentThread.ManagedThreadId));
            }
        }
    }
}