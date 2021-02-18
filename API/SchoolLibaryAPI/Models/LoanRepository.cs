using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibaryDbContext _dbContext;

        public LoanRepository(LibaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLoan(Loans loan)
        {
            var FindBook = _dbContext.Books.FirstOrDefault(d => d.BookId == loan.BookId);
            await _dbContext.Loans.AddAsync(loan);
            FindBook.AvailableBooks--;
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Loans> GetAll()
        {
            return _dbContext.Loans;
        }

        public async Task<Loans> GetById(int id)
        {
            return await _dbContext.Loans.FindAsync(id);
        }

        public async Task RemoveLoan(int id)
        {
            var GetLoan = await GetById(id);
            var GetBook = _dbContext.Books.FirstOrDefault(d => d.BookId == GetLoan.BookId);
            GetBook.AvailableBooks++;
            _dbContext.Loans.Remove(GetLoan);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
