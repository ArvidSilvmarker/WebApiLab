using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApiLab.Controllers
{
    [Route("api/ex2")]
    public class Ex2Controller : Controller
    {
        [Route("frukost"), HttpGet]
        public IActionResult Frukost(string food)
        {
            if (food.ToLower().Contains("egg"))
                return Ok($"You shall not eat {food} for breakfast.");
            if (new Regex(@"^[a-zåäöA-ZÅÄÖ]+$").Match(food).Success)
                return Ok($"A dish of {food} is always good for breakfast.");
            return BadRequest("Det är inte frukost.");
        }

        [Route("coolor"), HttpGet]
        public IActionResult Coolor(string color)
        {
            return Content($"<html><style>body {{background-color: {color}; }}</style><body></body></html>", "text/html");
        }

        [Route("quad"), HttpGet]
        public IActionResult Quad(string number)
        {
            if (new Regex(@"^-?\d+$").Match(number).Success)
                return Ok($"{number} x {number} = {Convert.ToInt32(number) * Convert.ToInt32(number)}");
            else
                return BadRequest("Inte en nuffra");
        }

        [Route("span"), HttpGet]
        public IActionResult Span(int from, int to)
        {
            StringBuilder text = new StringBuilder();
            for (int i = from; i <= to; i++)
            {
                text.Append(i);
                text.Append("\n");
            }

            return Ok(text.ToString());
        }
    }
}
