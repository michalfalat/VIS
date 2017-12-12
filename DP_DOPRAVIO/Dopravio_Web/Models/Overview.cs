using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopravio_api.Models
{
    public class Overview
    {
        public int failures { get; set; }
        public int failurestInLastMonth { get; set; }
        public int vehicleCount { get; set; }

        public int driverCount { get; set; }
        public int dispatcherCount { get; set; }
        public int acceptedRequests { get; set; }
        public int declinedRequests { get; set; }

        public int newRequests { get; set; }
        public decimal monthSalary { get; set; }
    }
}
