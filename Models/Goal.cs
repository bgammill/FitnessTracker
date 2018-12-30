using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class Goal
    {
        [Key] public int Id { get; set; }

        public DateTime CreationTimestamp { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        // public object GoalDetails { get; set; }
    }
}
