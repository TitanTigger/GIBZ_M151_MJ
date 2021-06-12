using L_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.Functions.Interfaces
{
    public interface IShareOperations
    {
        Task<List<ShareDA>> GetSharesByUserId(string userId);
        Task<bool> DeleteSharesByListId(int listId);
        Task<List<ShareDA>> GetSharesByListId(int listId);

    }
}
