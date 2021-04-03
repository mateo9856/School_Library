using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public class LibaryRepository : ILibaryRepository
    {

        private readonly LibaryDbContext _dbContext;

        public LibaryRepository(LibaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBook(Library book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }
        
        public IEnumerable<Library> GetAll()
        {
            return _dbContext.Books;
        }

        public async Task<Library> GetBook(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task RemoveBook(Library book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
