using L_Business.Models;
using L_Business.Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface IStatusService
    {
        Task<Generic_ResultSet<StatusModel>> AddStatus(string name);
        Task<Generic_ResultSet<StatusModel>> GetStatusById(int id);
        Task<Generic_ResultSet<StatusModel>> UpdateStatus(int id, string name);
        Task<Generic_ResultSet<StatusModel>> DeleteStatus(int id);
        Task<Generic_ResultSet<List<StatusModel>>> GetAllStatus();

    }
}
