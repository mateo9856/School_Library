using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public interface ILoginRepository
    {
        Task<Logins> GetLogin(int id);
        IEnumerable<Logins> GetLogins();
        Task AddLogin(Logins login);
        Task RemoveLogin(int id);
        
    }
}
