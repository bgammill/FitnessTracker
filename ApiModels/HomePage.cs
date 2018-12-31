using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.ApiModels
{
    public class HomePage
    {
        public string Users { get; set; }

        public string Foods { get; set; }

        public string Exercises { get; set; }
    }
}
