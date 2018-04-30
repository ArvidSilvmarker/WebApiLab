using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLab.Controllers
{
    [Route("api/calculator")]
    public class CalculatorController : Controller
    {
        [Route("square"),HttpGet]
        public IActionResult Square(string number)
        {
            if (number == null)
                return BadRequest("Måste ha en nuffra.");

            if (Convert.ToInt32(number) > 1000)
                return BadRequest("Kan inte kvadrera så stora tal.");

            return Ok($"{Convert.ToInt32(number)} x {Convert.ToInt32(number)} = {Convert.ToInt32(number) * Convert.ToInt32(number)}");
        }
    }
}