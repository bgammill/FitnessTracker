using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.DTOs;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class FoodLogEntriesController : ControllerBase
    {
        [HttpGet("{id}/foodlogentries")]
        public ActionResult<FoodLogEntriesDTO> GetUserFoodHistory(int id)
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var user = db.Users
                        .Where(x => x.Id == id)
                        .Select(x => new { x.Foods })
                        .ToList()[0];

                    var dto = new FoodLogEntriesDTO();
                    dto.Entries = new List<FoodLogEntryDTO>();

                    foreach (var foodLogEntry in user.Foods)
                    {
                        var entry = new FoodLogEntryDTO
                        {
                            Timestamp = foodLogEntry.Timestamp.ToString(),
                            FoodId = foodLogEntry.FoodId,
                            ServingAmount = foodLogEntry.ServingAmount
                        };

                        dto.Entries.Add(entry);
                    }

                    return dto;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
        }

        [HttpPost("{id}/foodlogentries")]
        public ActionResult PostUserFoodLogEntry(
            int id,
            [FromBody] FoodLogEntryDTO foodLogEntry)
        {
            using (var db = new SqliteContext())
            {
                var myFood = new FoodLogEntry
                {
                    Timestamp = DateTime.Parse(foodLogEntry.Timestamp),
                    FoodId = foodLogEntry.FoodId,
                    ServingAmount = foodLogEntry.ServingAmount,
                    UserId = id,
                };

                db.FoodLogEntries.Add(myFood);
                db.SaveChanges();
            }

            return StatusCode(201);
        }
    }
}
