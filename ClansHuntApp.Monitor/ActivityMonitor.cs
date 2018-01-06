﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClansHuntApp.Monitor.Configuration.Interfaces;
using ClansHuntApp.Monitor.Interfaces;
using ClansHuntApp.Infrastructure.Services;
using System.Threading;
using System.Diagnostics;

namespace ClansHuntApp.Monitor
{
    public class ActivityMonitor : IActivityMonitor
    {
        public IActivityMonitorConfiguration Configuration { get; set; }

        private int _monitorRunInterval = 5 * 60 * 1000;
        private int MonitorRunInterval
        {
            get
            {
                if (Configuration == null)
                {
                    return _monitorRunInterval;
                }
                return Configuration.MonitorRunInterval;
            }
        }

        private int _monitorTimeout = 0;
        private int MonitorTimeout
        {
            get
            {
                if (Configuration == null)
                {
                    return _monitorTimeout;
                }
                return Configuration.MonitorTimeout;
            }
        }

        private IMembersDataActivityService MembersDataActivityService { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        private Stopwatch Stopwatch { get; set; }

        private ActivityMonitor()
        {
        }

        protected ActivityMonitor(IMembersDataActivityService membersDataActivityService) : this()
        {
            MembersDataActivityService = membersDataActivityService;
        }
        protected ActivityMonitor(IMembersDataActivityService membersDataActivityService, IActivityMonitorConfiguration activityMonitorConfiguration) : this(membersDataActivityService)
        {
            Configuration = activityMonitorConfiguration;
        }

        public async Task StartMonitorAsync()
        {
            CancellationTokenSource = new CancellationTokenSource();
            if (MonitorTimeout != 0)
            {
                CancellationTokenSource.CancelAfter(MonitorTimeout);
            }
            while (!CancellationTokenSource.IsCancellationRequested)
            {
                await RunWithTimeCalc(async() => await CallMonitorAsync());

                var intervalRemaining = MonitorRunInterval - Stopwatch.ElapsedMilliseconds;
                if (intervalRemaining > 0)
                {
                    await Task.Delay((int)intervalRemaining, CancellationTokenSource.Token);
                }
            }
        }

        private Task CallMonitorAsync()
        {
            return Task.Run(() =>
            {
                MembersDataActivityService.LoadMembersData();
                MembersDataActivityService.SaveMembersData();
            },
            CancellationTokenSource.Token);
        }

        private async Task RunWithTimeCalc(Func<Task> calculatedMethodAsync)
        {
            Stopwatch = Stopwatch.StartNew();
            await calculatedMethodAsync();
            Stopwatch.Stop();
        }

        public void StopMonitor()
        {
            CancellationTokenSource.Cancel();
        }
    }
}
