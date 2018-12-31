﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using FitnessTracker.Models.Enums;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ApiModels.Users> GetAllUsers()
        {
            using (var db = new UserContext())
            {
                try
                {
                    var users = db.Users
                        .Select(x => new { x.Id, x.FirstName, x.LastName })
                        .ToList();

                    var rv = new ApiModels.Users();
                    rv.UserList = new List<ApiModels.User>();

                    foreach (var user in users)
                    {
                        rv.UserList.Add(
                            new ApiModels.User
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

        [HttpGet("{id}")]
        public ActionResult<ApiModels.User> GetUser(int id)
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

        [HttpPost]
        public ActionResult<User> PostNewUser([FromBody] ApiModels.User user)
        {
            var myUser = new User();
            myUser.FirstName = user.FirstName;
            myUser.LastName = user.LastName;
            myUser.Email = user.Email;

            using (var db = new UserContext())
            {
                db.Users.Add(myUser);
                db.SaveChanges();
                return myUser;
            }
        }

        [HttpDelete("{id}")]
        public StatusCodeResult DeleteUser(int id)
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
