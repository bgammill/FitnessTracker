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
    public class WeightLogEntriesController : ControllerBase
    {
        [HttpGet("{id}/weightlogentries")]
        public ActionResult<WeightLogEntriesDTO> GetUserWeightHistory(int id)
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var user = db.Users
                        .Where(x => x.Id == id)
                        .Select(x => new { x.Weights })
                        .ToList()[0];

                    var rv = new WeightLogEntriesDTO();
                    rv.Entries = new List<WeightLogEntryDTO>();

                    foreach (var weightLogEntry in user.Weights)
                    {
                        rv.Entries.Add(new WeightLogEntryDTO
                        {
                            Timestamp = weightLogEntry.Timestamp.ToString(),
                            Value = weightLogEntry.Weight
                        });
                    }

                    return rv;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
        }

        [HttpPost("{id}/weightlogentries")]
        public ActionResult PostUserWeightLogEntry(
            int id,
            [FromBody] WeightLogEntryDTO weightLogEntry)
        {
            using (var db = new SqliteContext())
            {
                var myWeight = new WeightLogEntry
                {
                    Timestamp = DateTime.Parse(weightLogEntry.Timestamp),
                    Weight = weightLogEntry.Value,
                    UserId = id
                };

                db.Weights.Add(myWeight);
                db.SaveChanges();
            }

            return StatusCode(201);
        }
    }
}
