using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models.DTOs
{
    public class LoanDto
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
    }
}
