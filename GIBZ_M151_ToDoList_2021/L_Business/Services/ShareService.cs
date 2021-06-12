using L_Business.Models;
using L_Business.Models.Share;
using L_Business.Services.Interfaces;
using L_DataAccess.Entities;
using L_DataAccess.Functions.Crud;
using L_DataAccess.Functions.Interfaces;
using L_DataAccess.Functions.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class ShareService : IShareService
    {
        private ICRUD _crud = new CRUD();
        private IShareOperations _shareOperations = new ShareOperations();

        public async Task<Generic_ResultSet<Share_ResultSet>> AddShare(string userId, int roleId, int listId)
        {
            Generic_ResultSet<Share_ResultSet> result = new Generic_ResultSet<Share_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Share
                ShareDA Share = new ShareDA
                {
                    UserId = userId,
                    ListId = listId,
                    RoleId = roleId
                };


                //ADD Share TO DB
                Share = await _crud.Create<ShareDA>(Share);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Share_ResultSet addedShare = new Share_ResultSet
                {
                    Id = Share.Id,
                    ListId = Share.ListId,
                    UserId = Share.UserId,
                    RoleId = Share.RoleId
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Share added successfully");
                result.internalMessage = "LOGIC.Services.ShareService:  AddShare() method executed successfully.";
                result.result_set = addedShare;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add Share. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: AddShare(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Share_ResultSet>> DeleteShare(int id)
        {
            Generic_ResultSet<Share_ResultSet> result = new Generic_ResultSet<Share_ResultSet>();
            try
            {
                await _crud.Delete<ShareDA>(id);
                result.userMessage = string.Format("Share deleted successfully");
                result.internalMessage = "LOGIC.Services.ShareService:  DeleteShare() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Share. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: DeleteShare(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<Share_ResultSet>> DeleteSharesByListId(int listId)
        {
            Generic_ResultSet<Share_ResultSet> result = new Generic_ResultSet<Share_ResultSet>();
            try
            {
                await _shareOperations.DeleteSharesByListId(listId);
                result.userMessage = string.Format("Task deleted successfully");
                result.internalMessage = "LOGIC.Services.TaskService:  DeleteTask() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Task. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: DeleteTask(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<Share_ResultSet>> GetShareById(int id)
        {
            Generic_ResultSet<Share_ResultSet> result = new Generic_ResultSet<Share_ResultSet>();
            try
            {
                //GET Share FROM DB
                ShareDA Share = await _crud.Read<ShareDA>(id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO Share_ResultSet
                Share_ResultSet returnedShare = new Share_ResultSet
                {
                    Id = Share.Id,
                    RoleId = Share.RoleId,
                    ListId = Share.ListId,
                    UserId = Share.UserId

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Share {0} was found successfully");
                result.internalMessage = "LOGIC.Services.ShareService: GetShareById() method executed successfully.";
                result.result_set = returnedShare;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Share.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: GetShareById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Share_ResultSet>>> GetSharesByListId(int listId)
        {
            Generic_ResultSet<List<Share_ResultSet>> result = new Generic_ResultSet<List<Share_ResultSet>>();
            result.result_set = new List<Share_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                List<ShareDA> Shares = await _shareOperations.GetSharesByListId(listId);

                //MANUAL MAPPING OF RETURNED Task VALUES TO Task_ResultSet
                Shares.ForEach(app => {
                    result.result_set.Add(new Share_ResultSet
                    {
                        Id = app.Id,
                        RoleId = app.RoleId,
                        ListId = app.ListId,
                        UserId = app.UserId
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your shares were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.ShareService: GetSharesByListId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find the shares you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ShareService: GetSharesByUserId(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Share_ResultSet>>> GetSharesByUserId(string userId)
        {
            Generic_ResultSet<List<Share_ResultSet>> result = new Generic_ResultSet<List<Share_ResultSet>>();
            result.result_set = new List<Share_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                List<ShareDA> Shares = await _shareOperations.GetSharesByUserId(userId);

                //MANUAL MAPPING OF RETURNED Task VALUES TO Task_ResultSet
                Shares.ForEach(app => {
                    result.result_set.Add(new Share_ResultSet
                    {
                        Id = app.Id,
                        RoleId = app.RoleId,
                        ListId = app.ListId,
                        UserId = app.UserId
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your shares were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.ShareService: GetSharesByUserId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find the shares you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ShareService: GetSharesByUserId(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Share_ResultSet>> UpdateShare(int id, string userId, int roleId, int listId)
        {
            Generic_ResultSet<Share_ResultSet> result = new Generic_ResultSet<Share_ResultSet>();
            try
            {
                ShareDA Share = new ShareDA
                {
                    Id = id,
                    UserId = userId,
                    RoleId = roleId,
                    ListId = listId
                };
                //UPDATE Applicant FROM DB
                Share = await _crud.Update<ShareDA>(Share, id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                Share_ResultSet updatedShare = new Share_ResultSet
                {
                    Id = Share.Id,
                    UserId = Share.UserId,
                    ListId = Share.ListId,
                    RoleId = Share.RoleId

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Share {0} was updated successfully");
                result.internalMessage = "LOGIC.Services.ShareService: UpdateShare() method executed successfully.";
                result.result_set = updatedShare;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update Share.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: UpdateShare(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
