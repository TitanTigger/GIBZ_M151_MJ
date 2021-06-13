using L_DataAccess.DataContext;
using L_DataAccess.Functions.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.Functions.Specific
{
    public class UserOperations : IUserOperations
    {
        // Get user by id
        public async Task<IdentityUser> GetUserById(string id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    IdentityUser user = await context.Users.FindAsync(id);
                    return user;
                }
            }
            catch
            {
                throw;
            }
        }

        // Get user by username
        public async Task<IdentityUser> GetUserByUsername(string username)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    IdentityUser user = await context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
                    return user;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
