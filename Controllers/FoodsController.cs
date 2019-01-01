using System;
using System.Linq;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ApiModels.Food> PostNewFood([FromBody] ApiModels.Food food)
        {
            var myFood = new Food();
            myFood.Name = food.Name;
            myFood.ServingSize = food.ServingSize;
            myFood.ProteinAmount = food.ProteinAmount;
            myFood.FatAmount = food.FatAmount;
            myFood.CarbohydrateAmount = food.CarbohydrateAmount;
            myFood.Calories = food.Calories;

            using (var db = new SqliteContext())
            {
                db.Foods.Add(myFood);
                db.SaveChanges();
                return food; // TODO Why bother even doing this?
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ApiModels.Food> GetFood(int id)
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var food = db.Foods.FirstOrDefault(x => x.Id == id);

                    return new ApiModels.Food
                    {
                        Name = food.Name,
                        ServingSize = food.ServingSize,
                        ProteinAmount = food.ProteinAmount,
                        FatAmount = food.FatAmount,
                        CarbohydrateAmount = food.CarbohydrateAmount,
                        Calories = food.Calories,
                    };
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateFood(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFood(int id)
        {
            throw new NotImplementedException();
        }
    }
}
