using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{


    public class NewsRepository : INewsRepository
    {
        private readonly DatabaseContext context = new DatabaseContext();

        public void Add(News news)
        {

        }
        
    }
}
