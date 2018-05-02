using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace News.Models
{


    public class NewsRepository : INewsRepository
    {
        private readonly DatabaseContext context = new DatabaseContext();

        public void ClearAll()
        {
            context.RemoveRange(context.News);
        }

        public void Add(NewsArticle news)
        {
            context.News.Add(news);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.News.ToList().Count;
        }

        public List<NewsArticle> GetAll()
        {
            return context.News.ToList();
        }

        public NewsArticle Find(int id)
        {
            return context.News.SingleOrDefault(a => a.Id == id);
        }

        public void Remove(NewsArticle article)
        {
            context.Remove(article);
            context.SaveChanges();
        }

        public void Update(NewsArticle article)
        {
            var temp = context.News.SingleOrDefault(s => s.Id == article.Id);
            temp.ChangedDate = DateTime.Now;
            temp.Title = article.Title;
            temp.Header = article.Header;
            temp.Body = article.Body;
            context.SaveChanges();
        }


    }
}
