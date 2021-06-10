using L_Business.Models;
using L_Business.Models.Share;
using L_Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class ShareService : IShareService
    {
        public Task<Generic_ResultSet<Share_ResultSet>> AddShare(int userId, int roleId, int listId)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Share_ResultSet>> DeleteShare(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Share_ResultSet>> GetShareById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Share_ResultSet>> UpdateShare(int id, int userId, int roleId, int listId)
        {
            throw new NotImplementedException();
        }
    }
}
