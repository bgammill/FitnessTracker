using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class Exercise
    {
        public string Name { get; set; }

        public List<object> PrimaryMuscleGroups { get; set; }

        public List<object> SecondaryMuscleGroups { get; set; }

        // Example: Strength vs. Cardio
        public object Type { get; set; }

        // Example: Isolation vs. Compound
        public object Mechanics { get; set; }

        public List<object> RequiredEquipment { get; set; }

        // Example: Beginner vs. Advanced
        public object Difficulty { get; set; }

        public string ExerciseInstructions { get; set; }
    }
}
