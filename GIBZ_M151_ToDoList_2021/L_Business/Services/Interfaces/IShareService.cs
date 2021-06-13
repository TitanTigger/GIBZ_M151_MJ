using L_Business.Models;
using L_Business.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface IShareService
    {
        Task<Generic_ResultSet<ShareModel>> AddShare(string username, int listId);
        Task<Generic_ResultSet<ShareModel>> GetShareById(int id);
        Task<Generic_ResultSet<ShareModel>> UpdateShare(int id, string userId, int listId);
        Task<Generic_ResultSet<ShareModel>> DeleteShare(int id);
        Task<Generic_ResultSet<List<ShareModel>>> GetSharesByUserId(string userId);
        Task<Generic_ResultSet<List<ShareModel>>> GetSharesByListId(int listId);

        Task<Generic_ResultSet<ShareModel>> DeleteSharesByListId(int listId);

    }
}
