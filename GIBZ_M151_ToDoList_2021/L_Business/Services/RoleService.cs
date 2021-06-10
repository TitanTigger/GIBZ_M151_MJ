using L_Business.Models;
using L_Business.Models.Role;
using L_Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class RoleService : IRoleService
    {
        public Task<Generic_ResultSet<Role_ResultSet>> AddRole(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Role_ResultSet>> DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Role_ResultSet>> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Generic_ResultSet<Role_ResultSet>> UpdateRole(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}
