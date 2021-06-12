using L_Business.Models;
using L_Business.Models.Role;
using L_Business.Services.Interfaces;
using L_DataAccess.Entities;
using L_DataAccess.Functions.Crud;
using L_DataAccess.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class RoleService : IRoleService
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<Role_ResultSet>> AddRole(string name)
        {
            Generic_ResultSet<Role_ResultSet> result = new Generic_ResultSet<Role_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Role
                RoleDA Role = new RoleDA
                {
                    Name = name
                };


                //ADD Role TO DB
                Role = await _crud.Create<RoleDA>(Role);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Role_ResultSet addedRole = new Role_ResultSet
                {
                    Id = Role.Id,
                    Name = Role.Name,
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Role added successfully", name);
                result.internalMessage = "LOGIC.Services.RoleService:  AddRole() method executed successfully.";
                result.result_set = addedRole;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add Role. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.RoleService: AddRole(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Role_ResultSet>> DeleteRole(int id)
        {
            Generic_ResultSet<Role_ResultSet> result = new Generic_ResultSet<Role_ResultSet>();
            try
            {
                await _crud.Delete<RoleDA>(id);
                result.userMessage = string.Format("Role deleted successfully");
                result.internalMessage = "LOGIC.Services.RoleService:  DeleteRole() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Role. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.RoleService: DeleteRole(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<Role_ResultSet>> GetRoleById(int id)
        {
            Generic_ResultSet<Role_ResultSet> result = new Generic_ResultSet<Role_ResultSet>();
            try
            {
                //GET Role FROM DB
                RoleDA Role = await _crud.Read<RoleDA>(id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO Role_ResultSet
                Role_ResultSet returnedRole = new Role_ResultSet
                {
                    Id = Role.Id,
                    Name = Role.Name

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Role {0} was found successfully", returnedRole.Name);
                result.internalMessage = "LOGIC.Services.RoleService: GetRoleById() method executed successfully.";
                result.result_set = returnedRole;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Role.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.RoleService: GetRoleById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Role_ResultSet>> UpdateRole(int id, string name)
        {
            Generic_ResultSet<Role_ResultSet> result = new Generic_ResultSet<Role_ResultSet>();
            try
            {
                RoleDA Role = new RoleDA
                {
                    Id = id,
                    Name = name
                };
                //UPDATE Applicant FROM DB
                Role = await _crud.Update<RoleDA>(Role, id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                Role_ResultSet updatedRole = new Role_ResultSet
                {
                    Id = Role.Id,
                    Name = Role.Name,

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Role {0} was updated successfully", updatedRole.Name);
                result.internalMessage = "LOGIC.Services.RoleService: UpdateRole() method executed successfully.";
                result.result_set = updatedRole;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update Role.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.RoleService: UpdateRole(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
