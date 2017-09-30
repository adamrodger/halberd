namespace Halberd.Example.AspNetCore.Controllers
{
    using System.Collections.Generic;
    using Halberd.Example.AspNetCore.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly IDictionary<string, CarModel> cars = new Dictionary<string, CarModel>
        {
            ["AB123CD"] = new CarModel { Registration = "AB123CD", Make = "Ford", Model = "Fiesta", Year = 2017 }
        };

        [HttpGet(Name = "GetAllCars")]
        public IActionResult GetAll()
        {
            return Ok(this.cars.Values);
        }

        [HttpGet("{id}", Name = "GetCarDetails")]
        public IActionResult GetById(string id)
        {
            if (this.cars.ContainsKey(id))
            {
                var car = this.cars[id];
                return Ok(car);
            }

            return this.NotFound();
        }
    }
}
