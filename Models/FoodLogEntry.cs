using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class FoodLogEntry
    {
        public DateTime Timestamp { get; set; }

        public Food Food { get; set; }

        public double ServingAmount { get; set; }

        public object BreakFastLunchDinnerSnack { get; set; }
    }
}
