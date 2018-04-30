using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public interface INewsRepository
    {
        void Add(NewsArticle news);
        void ClearAll();
        int Count();
        List<NewsArticle> GetAll();
        NewsArticle Find(int id);
        void Remove(NewsArticle article);
        void Update(NewsArticle article);
    }
}
