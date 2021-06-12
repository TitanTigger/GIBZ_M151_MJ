using L_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.Functions.Interfaces
{
    public interface ITaskOperations
    {
        Task<List<TaskDA>> GetTasksByListId(int listId);
        Task<bool> DeleteTasksByListId(int listId);
    }
}
