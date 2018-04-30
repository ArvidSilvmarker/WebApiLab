using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{


    public class NewsRepository : INewsRepository
    {
        private readonly DatabaseContext context = new DatabaseContext();

        public void ClearAll()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
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
            article.ChangedDate = DateTime.Now;
            context.News.Update(article);
            context.SaveChanges();
        }


    }
}
