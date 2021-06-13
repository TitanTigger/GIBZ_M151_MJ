using L_DataAccess.DataContext;
using L_DataAccess.Entities;
using L_DataAccess.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.Functions.Specific
{
    public class ShareOperations : IShareOperations
    {
        // Delete all Share Entries from one list
        public async Task<bool> DeleteSharesByListId(int listId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    context.Share.RemoveRange(context.Share.Where(s => s.ListId == listId));
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        // Get all Share Entries from one List
        public async Task<List<ShareDA>> GetSharesByListId(int listId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<ShareDA> Shares = await context.Share.Where(s => s.ListId == listId).ToListAsync();
                    return Shares;
                }
            }
            catch
            {
                throw;
            }
        }


        // Get all Share Entries from one User
        public async Task<List<ShareDA>> GetSharesByUserId(string userId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<ShareDA> Shares = await context.Share.Where(s => s.UserId == userId).ToListAsync();

                    return Shares;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
