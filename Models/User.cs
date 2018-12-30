using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Goal> Goals { get; set; }

        public ICollection<HeightLogEntry> Heights { get; set; }
        
        public ICollection<WeightLogEntry> Weights { get; set; }

        public ICollection<FoodLogEntry> Foods { get; set; }

        public ICollection<ExerciseLogEntry> Exercises { get; set; }
    }
}
