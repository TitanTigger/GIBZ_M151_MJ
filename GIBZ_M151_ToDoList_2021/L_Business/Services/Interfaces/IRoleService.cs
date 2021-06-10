using L_Business.Models;
using L_Business.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Generic_ResultSet<Role_ResultSet>> AddRole(string name);
        Task<Generic_ResultSet<Role_ResultSet>> GetRoleById(int id);
        Task<Generic_ResultSet<Role_ResultSet>> UpdateRole(int id, string name);
        Task<Generic_ResultSet<Role_ResultSet>> DeleteRole(int id);

    }
}
