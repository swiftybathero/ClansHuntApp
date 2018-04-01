using ClansHuntApp.Monitor.Interfaces;
using ClansHuntApp.Monitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Monitor.Console
{
    static class Program
    {
        public static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            Logger.Info("Welcome to Logger!");

            IActivityMonitor activityMonitor = ActivityMonitorFactory.Create();
            activityMonitor.Configuration.MonitorRunInterval = 1 * 60 * 1000;
            activityMonitor.MonitorStarted += OnMonitorActivity;
            activityMonitor.MonitorStopped += OnMonitorActivity;

            activityMonitor.StartMonitorAsync().Wait();

            System.Console.ReadKey();
        }

        private static void OnMonitorActivity(object sender, Events.MonitorActivityEventArgs e)
        {
            System.Console.WriteLine($"{e.Time}\t{e.Message}");
        }
    }
}
