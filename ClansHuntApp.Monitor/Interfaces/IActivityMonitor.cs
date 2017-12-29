using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Monitor.Interfaces
{
    public interface IActivityMonitor
    {
        void StartMonitor();
        Task StartMonitorAsync();
        void StopMonitor();
    }
}
