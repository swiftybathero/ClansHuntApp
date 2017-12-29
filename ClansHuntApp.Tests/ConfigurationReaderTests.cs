using ClansHuntApp.Infrastructure.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Tests
{
    [TestFixture]
    public class ConfigurationReaderTests
    {
        private IConfigurationReader configurationReader;

        [SetUp]
        public void SetUp()
        {
            configurationReader = new ConfigurationReader();
        }

        [Test]
        public void IsAPIKeyNotNullOrEmpty()
        {
            Assert.That(configurationReader.ReadAPIKey(), Is.Not.Null.Or.Empty);
        }
    }
}
