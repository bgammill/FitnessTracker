using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Models
{
    public class Muscle
    {
        [Key] public string Id { get; set; }

        [Required] public string Name { get; set; }
    }
}
