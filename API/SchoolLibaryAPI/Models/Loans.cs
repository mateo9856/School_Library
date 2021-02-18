using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public class Loans
    {
        [Key]
        public int LoanId { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }   
        public Library Book { get; set; }
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string LoanDate { get; set; }
    }
}
