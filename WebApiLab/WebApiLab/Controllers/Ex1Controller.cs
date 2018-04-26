using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLab.Controllers
{
    [Route("api/ex1")]
    public class Ex1Controller : Controller
    {
        [Route("Hello")]
        public string Hello()
        {
            return new Random().Next(0,3) == 0 
                ? "Hello World" 
                : new Random().Next(0,2) == 0 
                        ? "Bonjour le Monde"
                        : "Hei maailma";
            //Extra: Slumpa så antingen "Hello world", "Bonjour le monde" eller "Hei maailma" dyker upp
        }

        [Route("now")]
        public IActionResult Now()
        {
            return Ok(DateTime.Now.ToShortTimeString());
        }

        //Knappen “Skriv veckodag” ska gå till en sidan som skriver “Idag är det onsdag” (om det är onsdag)
        //Extra: Skriv på samma sätt ut vilken veckodag det var för tio år sedan(denna dag och denna månad)

        [Route("today")]
        public string Today()
        {
            return DateTime.Now.DayOfWeek.ToString();
        }

        [Route("todayTenYearsAgo")]
        public string TodayTenYearsAgo()
        {
            var culture = new CultureInfo("sv-SE");
            return culture.DateTimeFormat.GetDayName(DateTime.Now.AddYears(-10).DayOfWeek);
        }
    }
}
