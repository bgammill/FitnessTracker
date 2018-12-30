using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class HeightLogEntry
    {
        [Key] public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public double Height { get; set; }
    }
}
