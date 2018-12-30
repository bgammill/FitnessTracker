using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class Exercise
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Muscle> PrimaryMuscleGroups { get; set; }

        public ICollection<Muscle> SecondaryMuscleGroups { get; set; }

        // Example: Strength vs. Cardio
        // public object Type { get; set; }

        // Example: Isolation vs. Compound
        // public object Mechanics { get; set; }

        // public ICollection<object> RequiredEquipment { get; set; }

        // Example: Beginner vs. Advanced
        // public object Difficulty { get; set; }

        // public string ExerciseInstructions { get; set; }
    }
}
