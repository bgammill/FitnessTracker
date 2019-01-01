using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Food
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }

        [Required] public string ServingSize { get; set; }

        [Required] public double ProteinAmount { get; set; }

        [Required] public double FatAmount { get; set; }

        [Required] public double CarbohydrateAmount { get; set; }

        [Required] public int Calories { get; set; }
    }
}
