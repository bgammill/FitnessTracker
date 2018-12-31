using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<ApiModels.User> Get(int id)
        {
            using (var db = new UserContext())
            {
                try
                {
                    var user = db.Users
                        .Where(x => x.Id == id)
                        .Select(x => new { x.Id, x.FirstName, x.LastName })
                        .ToList()[0];

                    return new ApiModels.User
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        HeightLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/1/heightlogentries",
                        WeightLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/1/weightlogentries",
                        FoodLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/1/foodlogentries",
                        ExerciseLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/1/exerciselogentries"
                    };
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
        }

        [HttpGet("{id}/weightlogentries")]
        public ActionResult<ApiModels.WeightLogEntries> GetWeightHistory(int id)
        {
            using (var db = new UserContext())
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
        public ActionResult CreateWeightLogEntry(
            [FromBody] ApiModels.WeightLogEntry weightLogEntry)
        {
            using (var db = new UserContext())
            {
                var myWeight = new WeightLogEntry
                {
                    Timestamp = DateTime.Parse(weightLogEntry.Timestamp),
                    Weight = weightLogEntry.Value,
                    UserId = Convert.ToInt32(this.ControllerContext.RouteData.Values["id"])
                };

                db.Weights.Add(myWeight);
                db.SaveChanges();
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id)
        {
            using (var db = new UserContext())
            {
                var myUser = new User { FirstName = "Craig", LastName = "Carr" };

                db.Users.Add(myUser);
                var count = db.SaveChanges();

                return myUser;
            }
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            using (var db = new UserContext())
            {
                try
                {
                    var user = db.Users.Where(x => x.Id == id).ToList()[0];
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return StatusCode(204);
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
        }
    }
}
