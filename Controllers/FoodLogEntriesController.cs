using System;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodLogEntriesController : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateFoodLogEntry()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult GetFoodLogEntry(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public ActionResult UpdateFoodLogEntry()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult DeleteFoodLogEntry()
        {
            throw new NotImplementedException();
        }
    }
}
