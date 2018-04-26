using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLab.Controllers
{
    [Route("api/ex0")]
    public class Ex0Controller : Controller
    {
        [Route("AddPlanet")]
        public IActionResult AddPlanet()
        {
            string formContent = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                formContent = reader.ReadToEndAsync().Result;
            }

            var planet = CreatePlanet(formContent);
            return Ok($"Skapade planeten {planet.Name} med storlek {planet.Size}.");

        }

        [Route("ReadPlanet")]
        public IActionResult ReadPlanet()
        {
            string name = Request.Query["Planet"];
            int size = Convert.ToInt32(Request.Query["Size"]);
            var planet = new Planet {Name = name, Size = size};
            return Ok($"Letar efter planeten {planet.Name} med storlek {planet.Size}.");

        }


        [Route("AddPlanet2"), HttpPost]
        public IActionResult AddPlanet2(Planet planet)
        {
            return Ok($"Skapade planeten {planet.Name} med storlek {planet.Size}.");

        }

        [Route("ReadPlanet2"), HttpGet]
        public IActionResult ReadPlanet2(Planet planet)
        {
            return Ok($"Letar efter planeten {planet.Name} med storlek {planet.Size}.");
        }

        private Planet CreatePlanet(string text)
        {
            var planetArray = text.Split('&');
            return new Planet
            {
                Name = planetArray[0].Split('=').ElementAt(1),
                Size = Convert.ToInt32(planetArray[1].Split('=').ElementAt(1))
            };
            //Planet=Saturnus&Size=100
        }
    }


    public class Planet
    {
        public int Size { get; set; }
        public string Name { get; set; }

    }
}
