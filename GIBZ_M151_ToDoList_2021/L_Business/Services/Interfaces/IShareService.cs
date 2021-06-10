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
        Task<Generic_ResultSet<Share_ResultSet>> AddShare(int userId, int roleId, int listId);
        Task<Generic_ResultSet<Share_ResultSet>> GetShareById(int id);
        Task<Generic_ResultSet<Share_ResultSet>> UpdateShare(int id, int userId, int roleId, int listId);
        Task<Generic_ResultSet<Share_ResultSet>> DeleteShare(int id);

    }
}
