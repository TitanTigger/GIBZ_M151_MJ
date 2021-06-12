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
    public class TaskOperations : ITaskOperations
    {
        public async Task<bool> DeleteTasksByListId(int listId)
        {            
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    context.Tasks.RemoveRange(context.Tasks.Where(t => t.ListId == listId));
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<List<TaskDA>> GetTasksByListId(int listId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<TaskDA> Tasks = await context.Tasks.Where(t => t.ListId == listId).ToListAsync();

                    return Tasks;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
