using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class User
    {
        public string ProfileName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public List<Goal> Goals { get; set; }

        public List<HeightLogEntry> Heights { get; set; }
        
        public List<WeightLogEntry> Weights { get; set; }

        public List<FoodLogEntry> Foods { get; set; }

        public List<ExerciseLogEntry> Exercises { get; set; }
    }
}
