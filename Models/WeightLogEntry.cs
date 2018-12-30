using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class WeightLogEntry
    {
        public DateTime Timestamp { get; set; }

        public double Weight { get; set; }
    }
}
