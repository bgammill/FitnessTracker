using FitnessTracker.Models.Enums;

namespace FitnessTracker.ApiModels
{
    public class Food
    {
        public string Name { get; set; }

        public string ServingSize { get; set; }

        public double ProteinAmount { get; set; }

        public double FatAmount { get; set; }

        public double CarbohydrateAmount { get; set; }

        public int Calories { get; set; }
    }
}
