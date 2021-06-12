using L_Business.Models;
using L_Business.Models.Share;
using L_Business.Services.Interfaces;
using L_DataAccess.Functions.Crud;
using L_DataAccess.Functions.Interfaces;
using L_DataAccess.Functions.Specific;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class UserService : IUserService
    {
        private ShareService _shareService = new ShareService();
        private IUserOperations _userOperations = new UserOperations();

        public async Task<IdentityUser> GetUserById(string id)
        {
            IdentityUser user = new IdentityUser();
            try
            {
                //GET user FROM DB
                user = await _userOperations.GetUserById(id);     

                
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
            return user;
        }

        public async Task<IdentityUser> GetUserByUsername(string username)
        {
            IdentityUser user = new IdentityUser();
            try
            {
                //GET Task FROM DB
                user = await _userOperations.GetUserByUsername(username);          
                
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
            return user;
        }

        public async Task<List<IdentityUser>> GetUsersToList(int listId)
        {
            List<IdentityUser> Users = new();
            try
            {
                List<Share_ResultSet> Shares = (await _shareService.GetSharesByListId(listId)).result_set;
                Shares.ForEach(async share =>
                {
                    Users.Add(await this.GetUserById(share.UserId));
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
            return Users;
        }
    }
}
