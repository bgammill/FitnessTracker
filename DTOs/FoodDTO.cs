using FitnessTracker.Models.Enums;

namespace FitnessTracker.DTOs
{
    public class FoodDTO
    {
        // TODO Should this be optional for creates?
        public int Id { get; set; }

        public string Name { get; set; }

        public string ServingSize { get; set; }

        public double ProteinAmount { get; set; }

        public double FatAmount { get; set; }

        public double CarbohydrateAmount { get; set; }

        public int Calories { get; set; }
    }
}
