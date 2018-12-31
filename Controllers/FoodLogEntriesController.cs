using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodLogEntriesController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            using (var db = new UserContext())
            {
                try
                {
                    return db.Users.Where(x => x.Id == id).ToList()[0];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return StatusCode(404);
                }
            }
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
