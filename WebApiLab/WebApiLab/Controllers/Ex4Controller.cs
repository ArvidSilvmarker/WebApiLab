using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLab.Controllers
{
    [Route("api/ex3")]
    public class Ex4Controller : Controller
    {

        [Route("addperson"), HttpPost]
        public IActionResult AddPerson(SimplePerson person)
        {
            return Ok($"Person med namn: {person.Name} och ålder: {person.Age} har nu lagt till i databasen.");
        }

        [Route("validateperson"), HttpPost]
        public IActionResult ValidatePerson(SimplePerson person)
        {
            List<string> errorMessage = new List<string>();
            if (string.IsNullOrWhiteSpace(person.Name))
                errorMessage.Add("Personen måste ha ett namn.");
            else if (person.Name.Length > 20)
                errorMessage.Add("Namn får inte vara längre än 20 tecken.");
            if (person.Age == null)
                errorMessage.Add("Personen måste ha en ålder.");
            else if (person.Age < 0 || person.Age > 120)
                errorMessage.Add("Ålder måste vara mellan 0 och 120.");

            if (errorMessage.Count > 0)
                return BadRequest(string.Join(' ', errorMessage.ToArray()));

            return Ok($"Person med namn: {person.Name} och ålder: {person.Age} har nu lagt till i databasen.");
        }

        [Route("validatepersonattributes"), HttpPost]
        public IActionResult ValidatePersonWithAttributes(SimplePersonWithAttributes person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok($"Person med namn: {person.Name} och ålder: {person.Age} har nu lagt till i databasen.");
        }


    }

    public class SimplePerson
    {
        public string Name { get; set; }
        public int? Age { get; set; }
    }

    public class SimplePersonWithAttributes
    {
        [Required(ErrorMessage = "Måste ha ett namn.")]
        [StringLength(20, ErrorMessage = "Namn får inte vara längre än 20 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Måste ha en ålder.")]
        [Range(0,120, ErrorMessage = "Ålder måste vara mellan 0 och 120.")]
        public int Age { get; set; }
    }
}

