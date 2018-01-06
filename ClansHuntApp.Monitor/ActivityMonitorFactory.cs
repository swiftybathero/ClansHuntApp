using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ClansHuntApp.Infrastructure.Repositories;
using ClansHuntApp.Infrastructure.Services;
using ClansHuntApp.Monitor.Configuration;
using ClansHuntApp.Monitor.Configuration.Interfaces;
using ClansHuntApp.Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Monitor
{
    public class ActivityMonitorFactory
    {
        private static WindsorContainer _container;
        public static WindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = InitContainer();
                }
                return _container;
            }
        }

        private ActivityMonitorFactory() { }

        private static WindsorContainer InitContainer()
        {
            var windsorContainer = new WindsorContainer();
            windsorContainer
            .AddFacility<TypedFactoryFacility>()
            .Register
            (
                Component.For<IActivityMonitor>().ImplementedBy<ActivityMonitor>(),
                //Component.For<IActivityMonitorConfiguration>().Instance
                //(
                //    new ActivityMonitorGenericConfiguration
                //    {
                //        MonitorRunInterval = 60 * 1000,
                //        MonitorTimeout = 0
                //    }
                //),
                Component.For<IMembersDataActivityService>().ImplementedBy<MembersDataActivityService>(),
                Component.For<IMembersDataRepository>().ImplementedBy<MembersDataRepository>(),
                Component.For<IDestinationDataRepository>().ImplementedBy<DestinationDataRepository>(),
                Component.For<IConfigurationReader>().ImplementedBy<ConfigurationReader>(),
                Component.For<Func<IMembersDataRepository>>().AsFactory(),
                Component.For<Func<IDestinationDataRepository>>().AsFactory()
            );

            return windsorContainer;
        }

        public static ActivityMonitor Create()
        {
            return Container.Resolve<ActivityMonitor>();
        }
    }
}
