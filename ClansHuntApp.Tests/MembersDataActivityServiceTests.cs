using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClansHuntApp.Infrastructure;
using ClansHuntApp.Infrastructure.Services;
using ClansHuntApp.Infrastructure.Repositories;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Facilities.TypedFactory;

namespace ClansHuntApp.Tests
{
    [TestFixture]
    public class MembersDataActivityServiceTests
    {
        private IMembersDataActivityService membersDataActivityService;
        private WindsorContainer container;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            container = new WindsorContainer();
            container
            .AddFacility<TypedFactoryFacility>()
            .Register
            (
                Component.For<IMembersDataActivityService>().ImplementedBy<MembersDataActivityService>(),
                Component.For<IMembersDataRepository>().ImplementedBy<MembersDataRepository>(),
                Component.For<IConfigurationReader>().ImplementedBy<ConfigurationReader>(),
                Component.For<Func<IMembersDataRepository>>().AsFactory()
            );
        }

        [SetUp]
        public void SetUp()
        {
            membersDataActivityService = container.Resolve<IMembersDataActivityService>();
        }

        [Test]
        public void IsMembersCollectionNotNull()
        {
            membersDataActivityService.LoadMembersData();
            Assert.That((membersDataActivityService as MembersDataActivityService).MembersList, Is.Not.Null);
        }

        [Test]
        public void IsMembersCollectionNotEmpty()
        {
            membersDataActivityService.LoadMembersData();
            Assert.That((membersDataActivityService as MembersDataActivityService).MembersList.Count, Is.Not.EqualTo(0));
        }
    }
}
