using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models.DTOs
{
    public class LibraryDto
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string ReleaseDate { get; set; }
        public int AvailableBooks { get; set; }
    }
}
