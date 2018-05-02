using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using News.Models;

namespace News.Controllers
{
    [Route("api/news")]
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [Route("seed"), HttpPost]
        public IActionResult Seed()
        {
            try
            {
                _newsRepository.ClearAll();
            }
            catch (Exception e)
            {
                return BadRequest("Gick inte att tömma databasen.");
            }

            try
            {
                _newsRepository.Add(new NewsArticle()
                {
                    Title = "Title1",
                    Header = "Header1",
                    Body = "Body1"
                });
                _newsRepository.Add(new NewsArticle()
                {
                    Title = "Title1",
                    Header = "Header2",
                    Body = "Body2"
                });
            }
            catch (Exception e)
            {
                return BadRequest("Gick inte att seeda.");
            }

            return Ok("Reseedat databasen.");
        }

        [Route("count"), HttpGet]
        public IActionResult Count()
        {
            return Ok($"Antal artiklar: {_newsRepository.Count()}");
        }

        [Route("ShowAll"), HttpGet]
        public IActionResult ShowAll()
        {
            return Json(_newsRepository.GetAll());
        }

        [Route("add"), HttpPost]
        public IActionResult Add(NewsArticle newsArticle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _newsRepository.Add(newsArticle);
                return Ok($"ID = {newsArticle.Id}");
            }
            catch
            {
                return BadRequest();
            }

        }

        [Route("remove"), HttpPost]
        public IActionResult Remove(int id)
        {
            NewsArticle article = _newsRepository.Find(id);
            if (article == null)
                return BadRequest($"Hittade inte artikel med ID: {id}");

            try
            {
                _newsRepository.Remove(article);
            }
            catch
            {
                return BadRequest("Gick inte att ta bort.");
            }

            return Ok($"Tog bort artikeln med ID {id}");
        }

        [Route("update"), HttpPost]
        public IActionResult Update(NewsArticle updatedArticle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                _newsRepository.Update(updatedArticle);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest(exception.Message);
            }

            return Ok($"Updaterade artikeln med ID: {updatedArticle.Id}");

        }

    }
}