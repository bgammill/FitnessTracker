using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.ApiModels
{
    public class WeightLogEntry
    {
        public string Timestamp { get; set; }

        public double Value { get; set; }
    }
}
