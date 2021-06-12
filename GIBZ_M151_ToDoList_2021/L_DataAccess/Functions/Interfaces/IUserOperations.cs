using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.Functions.Interfaces
{
    public interface IUserOperations
    {
        Task<IdentityUser> GetUserByUsername(string username);
        Task<IdentityUser> GetUserById(string id);
    }
}
