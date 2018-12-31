using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class User
    {
        [Key] public int Id { get; set; }

        [Required] public string Email { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public DateTime BirthDate { get; set; }

        [Required] public Sex Sex { get; set; }
        
        public ICollection<Goal> Goals { get; set; }

        public ICollection<HeightLogEntry> Heights { get; set; }
        
        public ICollection<WeightLogEntry> Weights { get; set; }

        public ICollection<FoodLogEntry> Foods { get; set; }

        public ICollection<ExerciseLogEntry> Exercises { get; set; }
    }
}
