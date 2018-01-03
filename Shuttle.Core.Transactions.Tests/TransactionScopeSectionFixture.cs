using System;
using System.IO;
using System.Transactions;
using NUnit.Framework;
using Shuttle.Core.Configuration;

namespace Shuttle.Core.Transactions.Tests
{
    public class TransactionScopeSectionFixture
    {
        private TransactionScopeSection GetSection(string file)
        {
            return ConfigurationSectionProvider.OpenFile<TransactionScopeSection>("shuttle", "transactionScope",
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@".\files\{file}"));
        }

        [Test]
        [TestCase("TransactionScope.config")]
        [TestCase("TransactionScope-Grouped.config")]
        public void Should_be_able_to_load_a_valid_configuration(string file)
        {
            var section = GetSection(file);

            Assert.IsNotNull(section);
            Assert.IsFalse(section.Enabled);
            Assert.AreEqual(IsolationLevel.RepeatableRead, section.IsolationLevel);
            Assert.AreEqual(300, section.TimeoutSeconds);
        }

        [Test]
        public void Should_be_able_to_load_an_empty_configuration()
        {
            var section = GetSection("Empty.config");

            Assert.IsTrue(section.Enabled);
            Assert.AreEqual(IsolationLevel.ReadCommitted, section.IsolationLevel);
            Assert.AreEqual(30, section.TimeoutSeconds);
        }
    }
}