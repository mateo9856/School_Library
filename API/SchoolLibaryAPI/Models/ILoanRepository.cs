using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public interface ILoanRepository
    {
        Task<Loans> GetById(int id);
        IEnumerable<Loans> GetAll();
        Task AddLoan(Loans loan);
        Task RemoveLoan(int id);
        Task SaveChanges();
    }
}
