using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FitnessTracker.ApiModels
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HeightLogEntries { get; set; }

        public string WeightLogEntries { get; set; }

        public string FoodLogEntries { get; set; }

        public string ExerciseLogEntries { get; set; }
    }
}
