using FitnessTracker.Models.Enums;

namespace FitnessTracker.ApiModels
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Sex Sex { get; set; }

        public string HeightLogEntries { get; set; }

        public string WeightLogEntries { get; set; }

        public string FoodLogEntries { get; set; }

        public string ExerciseLogEntries { get; set; }
    }
}
