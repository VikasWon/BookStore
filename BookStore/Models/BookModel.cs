using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        // CoverImage corresponds to the image url. 
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
    }
}
