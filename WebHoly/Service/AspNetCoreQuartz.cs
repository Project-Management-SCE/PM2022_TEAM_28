using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebHoly.Service
{
    public class AspNetCoreQuartz : Hub
    {
        public Task SendConcurrentJobsMessage(string message)
        {
            return Clients.All.SendAsync("ConcurrentJobs", message);
        }

        public Task SendNonConcurrentJobsMessage(string message)
        {
            return Clients.All.SendAsync("NonConcurrentJobs", message);
        }

    }
}
