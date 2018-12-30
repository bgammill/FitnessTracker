using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class ExerciseLogEntry
    {
        [Key] public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public Exercise Exercise { get; set; }

        // public object RepsSetsRestTime { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")] public User User { get; set; }
    }
}
