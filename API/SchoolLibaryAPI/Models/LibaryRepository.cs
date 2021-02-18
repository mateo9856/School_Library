using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{//DZIAŁANIA NASTĘPNE: PRÓBA ZROBIENIA DTO, PRZED TYM IMPLEMENTACJA AUTOMAPPERA
    public class LibaryRepository : ILibaryRepository//poczytac o API i jak dodac dane do entity tez
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
            //return await _dbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);
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
