using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.DTOs;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<FoodDTO> PostNewFood([FromBody] FoodDTO food)
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
                return food; // TODO Should a "location header" be returned instead?
            }
        }

        [HttpGet]
        public ActionResult<FoodsDTO> GetAllFoods(string name = "")
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var foods = db.Foods.Where(x => x.Name.ToLower().Contains(name.ToLower()));

                    var dto = new FoodsDTO();
                    dto.FoodList = new List<FoodDTO>();

                    foreach (var food in foods)
                    {
                        var entry = new FoodDTO
                        {
                            Id = food.Id,
                            Name = food.Name,
                            ServingSize = food.ServingSize,
                            ProteinAmount = food.ProteinAmount,
                            FatAmount = food.FatAmount,
                            CarbohydrateAmount = food.CarbohydrateAmount,
                            Calories = food.Calories,
                        };

                        dto.FoodList.Add(entry);
                    }

                    return dto;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FoodDTO> GetFood(int id)
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var food = db.Foods.FirstOrDefault(x => x.Id == id);

                    return new FoodDTO
                    {
                        Id = food.Id,
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
