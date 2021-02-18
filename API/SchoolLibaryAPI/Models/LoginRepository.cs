using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI.Models
{
    public class LoginRepository : ILoginRepository
    {
        private readonly LibaryDbContext _dbContext;

        public LoginRepository(LibaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Logins> GetLogin(int id)
        {
            return await _dbContext.Logins.FindAsync(id);
        }

        public IEnumerable<Logins> GetLogins()
        {
            return _dbContext.Logins;
        }

        public async Task AddLogin(Logins login)
        {
            await _dbContext.AddAsync(login);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLogin(int id)
        {
            var getLogin = await _dbContext.Logins.FindAsync(id);
            _dbContext.Logins.Remove(getLogin);
            await _dbContext.SaveChangesAsync();
        }

    }
}
