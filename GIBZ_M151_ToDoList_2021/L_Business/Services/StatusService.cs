using L_Business.Models;
using L_Business.Models.Status;
using L_Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class StatusService : IStatusService
    {
        public Task<Generic_ResultSet<Status_ResultSet>> AddStatus(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Status_ResultSet>> DeleteStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Status_ResultSet>> GetStatusBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Status_ResultSet>> UpdateStatus(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
