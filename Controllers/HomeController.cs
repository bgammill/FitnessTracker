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
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ApiModels.HomePage> Get(int id)
        {
            return new ApiModels.HomePage
            {
                Users = $"{this.Request.Scheme}:{this.Request.Host}/api/users",
                Foods = $"{this.Request.Scheme}:{this.Request.Host}/api/foods",
                Exercises = $"{this.Request.Scheme}:{this.Request.Host}/exercises",
            };
        }
    }
}
