using System;
using System.Collections.Generic;
using System.Linq;
using FitnessTracker.DTOs;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<UsersDTO> GetAllUsers()
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var users = db.Users
                        .Select(x => new { x.Id, x.FirstName, x.LastName })
                        .ToList();

                    var rv = new UsersDTO();
                    rv.UserList = new List<UserDTO>();

                    foreach (var user in users)
                    {
                        rv.UserList.Add(
                            new UserDTO
                            {
                                Id = user.Id,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                HeightLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/{user.Id}/heightlogentries",
                                WeightLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/{user.Id}/weightlogentries",
                                FoodLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/{user.Id}/foodlogentries",
                                ExerciseLogEntries = $"{this.Request.Scheme}:{this.Request.Host}/api/users/{user.Id}/exerciselogentries"
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

        /// <summary>
        ///  TODO Example documentation.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUser(int id)
        {
            using (var db = new SqliteContext())
            {
                try
                {
                    var user = db.Users
                        .Where(x => x.Id == id)
                        .Select(x => new { x.Id, x.FirstName, x.LastName })
                        .ToList()[0];

                    return new UserDTO
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

        [HttpPost]
        // TODO Should return UserDTO
        public ActionResult<User> PostNewUser([FromBody] UserDTO user)
        {
            var myUser = new User();
            myUser.FirstName = user.FirstName;
            myUser.LastName = user.LastName;
            myUser.Email = user.Email;

            using (var db = new SqliteContext())
            {
                db.Users.Add(myUser);
                db.SaveChanges();
                return myUser;
            }
        }

        [HttpPatch("{id}")]
        // TODO Should return UserDTO
        public ActionResult<User> PatchExistingUser(
            int id,
            [FromBody] UserDTO user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public StatusCodeResult DeleteUser(int id)
        {
            using (var db = new SqliteContext())
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
