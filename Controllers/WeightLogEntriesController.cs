using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class WeightLogEntriesController : ControllerBase
    {
        [HttpGet("{id}/weightlogentries")]
        public ActionResult<ApiModels.WeightLogEntries> GetUserWeightHistory(int id)
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var user = db.Users
                        .Where(x => x.Id == id)
                        .Select(x => new { x.Weights })
                        .ToList()[0];

                    var rv = new ApiModels.WeightLogEntries();
                    rv.Entries = new List<ApiModels.WeightLogEntry>();

                    foreach (var weightLogEntry in user.Weights)
                    {
                        rv.Entries.Add(new ApiModels.WeightLogEntry
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
            [FromBody] ApiModels.WeightLogEntry weightLogEntry)
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
