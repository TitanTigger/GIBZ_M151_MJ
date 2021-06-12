using L_Business.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<IdentityUser> GetUserByUsername(string username);
        Task<List<IdentityUser>> GetUsersToList(int listId);
        Task<IdentityUser> GetUserById(string id);
    }
}
