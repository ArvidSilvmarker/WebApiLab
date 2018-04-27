 using System;
using System.Collections.Generic;
using System.Linq;
 using System.Text.RegularExpressions;
 using System.Threading.Tasks;
 using Microsoft.AspNetCore.Mvc;
 using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApiLab.Controllers
{
    [Route("api/ex3")]
    public class Ex3Controller : Controller
    {
        [Route("choklad")]
        public IActionResult Choklad(double numberOfPeople)
        {
            if (numberOfPeople > 0)
                return Ok($"Varje person får {25.0 / numberOfPeople} bitar.");
            return BadRequest("Så kan man inte dela choklad.");
        }

        [Route("order")]
        public IActionResult Order(string orderNumber)
        {
            orderNumber = orderNumber.ToUpper().Trim();
            if (!new Regex(@"^[A-Z]{2}-\d{4}$").Match(orderNumber).Success)
                return BadRequest("Fel format.");

            int numberPart = Convert.ToInt32(orderNumber.Split('-')[1]);
            if (numberPart > 3000)
                return NotFound($"Order {orderNumber} hittades inte i databasen.");
            return Ok($"Order {orderNumber} hittades i databasen.");
        }
                //Om Stewie matas in => Exception med innehåll “DATA ERROR!”
                //Om Peter matas in => visa bild på en explosion
                //Om Lois, Meg, Chris, Brian matar in => visa en bild på nån som gör tummen upp
                //Annars => visa tummen ner

        [Route("username")]
        public IActionResult UserName(string userName)
        {
            if (userName == "Stewie")
            {
                throw new Exception("DATA ERROR!");
            }

            if (userName == "Peter")
            {
                string explosionImg = "<html><iframe src = \"https://giphy.com/embed/HhTXt43pk1I1W\" class=\"giphy - embed\"></iframe></html>";
                return Content(explosionImg, "text/html");
            }
            
            if (new List<string> { "Lois", "Meg", "Chris", "Brian"}.Contains(userName))
            {
                string thumbsUpImg = "<html><img src=\"http://www.emoji.co.uk/files/phantom-open-emojis/smileys-people-phantom/12299-thumbs-up-sign.png\"></html>";
                return Content(thumbsUpImg, "text/html");
            }

            string thumbsDownImg = "<html><iframe src=\"https://giphy.com/embed/iJxHzcuNcCJXi\" width=\"480\" height=\"360\" frameBorder=\"0\" class=\"giphy-embed\" allowFullScreen></iframe></html>";
            return Content(thumbsDownImg, "text/html");
        }

        [Route("lampa")]
        public JavaScriptResult Lampa(string lampa)
        {
            //IEnumerable<bool> lampa
            //bool checkBoxOnMarkup;
            //if (lampa != null && lampa.Count() == 2)
            //{
            //    checkBoxOnMarkup = true;
            //}
            //else
            //{
            //    checkBoxOnMarkup = false;
            //}

            bool checkBoxOnMarkup = lampa.ToLower() == "on";

            if (checkBoxOnMarkup)
                return new JavaScriptResult("document.body.style.backgroundColor = \"yellow\"");
            else
                return new JavaScriptResult("document.body.style.backgroundColor = \"gray\"");
        }

        public class JavaScriptResult : ContentResult
        {
            public JavaScriptResult(string script)
            {
                this.Content = script;
                this.ContentType = "application/javascript";
            }
        }

    }
}
