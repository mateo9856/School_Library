using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public interface ILibaryRepository
    {
        Task<Library> GetBook(int id);
        IEnumerable<Library> GetAll();   
        Task AddBook(Library book);
        Task RemoveBook(Library book);
        Task SaveChanges();
    }
}
