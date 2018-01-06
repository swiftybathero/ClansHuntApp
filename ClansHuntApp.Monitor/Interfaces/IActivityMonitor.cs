using ClansHuntApp.Monitor.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Monitor.Interfaces
{
    public interface IActivityMonitor
    {
        Task StartMonitorAsync();
        void StopMonitor();
        IActivityMonitorConfiguration Configuration { get; set; }
    }
}
