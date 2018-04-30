using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsArticle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Måste ha en titel.")]
        [Range(5, 20, ErrorMessage="Titeln måste vara 5-20 tecken lång.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Måste ha en header.")]
        [StringLength(200, ErrorMessage = "Header får vara max 200 tecken.")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Måste ha en body.")]
        [StringLength(2000, ErrorMessage = "Body får vara max 2000 tecken.")]
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }

        public NewsArticle()
        {
            CreatedDate = DateTime.Now;
            ChangedDate = DateTime.Now;
        }
    }
}
