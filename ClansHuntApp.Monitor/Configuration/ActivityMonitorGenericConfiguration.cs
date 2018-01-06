using ClansHuntApp.Monitor.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Monitor.Configuration
{
    public class ActivityMonitorGenericConfiguration : IActivityMonitorConfiguration
    {
        public int MonitorRunInterval { get; set; }
        public int MonitorTimeout { get; set; }
    }
}
