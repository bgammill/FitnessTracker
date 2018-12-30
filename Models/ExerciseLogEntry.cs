using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class ExerciseLogEntry
    {
        public DateTime Timestamp { get; set; }

        public Exercise Exercise { get; set; }

        public object RepsSetsRestTime { get; set; }
    }
}
