using L_Business.Models;
using L_Business.Models.Status;
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
    public class StatusService : IStatusService
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<StatusModel>> AddStatus(string name)
        {
            Generic_ResultSet<StatusModel> result = new Generic_ResultSet<StatusModel>();
            try
            {
                // INIT NEW DB ENTITY OF Status
                StatusDA Status = new StatusDA
                {
                    Name = name
                };


                // ADD Status TO DB
                Status = await _crud.Create<StatusDA>(Status);

                // MANUAL MAPPING OF RETURNED STATUS VALUES TO STATUSMODEL
                StatusModel addedStatus = new StatusModel
                {
                    Id = Status.Id,
                    Name = Status.Name,
                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Status added successfully", name);
                result.internalMessage = "LOGIC.Services.StatusService:  AddStatus() method executed successfully.";
                result.result_set = addedStatus;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add Status. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.StatusService: AddStatus(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<StatusModel>> DeleteStatus(int id)
        {
            Generic_ResultSet<StatusModel> result = new Generic_ResultSet<StatusModel>();
            try
            {
                await _crud.Delete<StatusDA>(id);
                result.userMessage = string.Format("Status deleted successfully");
                result.internalMessage = "LOGIC.Services.StatusService:  DeleteStatus() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Status. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.StatusService: DeleteStatus(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<StatusModel>>> GetAllStatus()
        {           
            Generic_ResultSet<List<StatusModel>> result = new Generic_ResultSet<List<StatusModel>>();
            result.result_set = new List<StatusModel>();
            try
            {
                //GET Status FROM DB
                List<StatusDA> Status = await _crud.ReadAll<StatusDA>();

                Status.ForEach(app => {
                    result.result_set.Add(new StatusModel
                    {
                        Id = app.Id,
                        Name = app.Name                        
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Status {0} was found successfully";
                result.internalMessage = "LOGIC.Services.StatusService: GetAllStatus() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Status.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.StatusService: GetAllStatus(): {0}", exception.Message);
            }
            return result;
            
        }

        public async Task<Generic_ResultSet<StatusModel>> GetStatusById(int id)
        {
            Generic_ResultSet<StatusModel> result = new Generic_ResultSet<StatusModel>();
            try
            {
                // GET Status FROM DB
                StatusDA Status = await _crud.Read<StatusDA>(id);

                // MANUAL MAPPING OF RETURNED STATUS VALUES TO STATUSMODEL
                StatusModel returnedStatus = new StatusModel
                {
                    Id = Status.Id,
                    Name = Status.Name

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Status {0} was found successfully", returnedStatus.Name);
                result.internalMessage = "LOGIC.Services.StatusService: GetStatusById() method executed successfully.";
                result.result_set = returnedStatus;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Status.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.StatusService: GetStatusById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<StatusModel>> UpdateStatus(int id, string name)
        {
            Generic_ResultSet<StatusModel> result = new Generic_ResultSet<StatusModel>();
            try
            {
                StatusDA Status = new StatusDA
                {
                    Id = id,
                    Name = name
                };
                // UPDATE STATUS FROM DB
                Status = await _crud.Update<StatusDA>(Status, id);

                // MANUAL MAPPING OF UPDATED STATUS VALUES TO OUR STATUSMODEL
                StatusModel updatedStatus = new StatusModel
                {
                    Id = Status.Id,
                    Name = Status.Name,

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Status {0} was updated successfully", updatedStatus.Name);
                result.internalMessage = "LOGIC.Services.StatusService: UpdateStatus() method executed successfully.";
                result.result_set = updatedStatus;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update Status.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.StatusService: UpdateStatus(): {0}", exception.Message);
            }
            return result;
        }
    }
}
