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


        public async Task<Generic_ResultSet<ShareModel>> AddShare(string username, int listId)
        {
            IUserService _userService = new UserService();

            Generic_ResultSet<ShareModel> result = new Generic_ResultSet<ShareModel>();
            try
            {
                // INIT NEW DB ENTITY OF Share
                ShareDA Share = new ShareDA
                {
                    UserId = (await _userService.GetUserByUsername(username)).Id,
                    ListId = listId
                };


                // ADD Share TO DB
                Share = await _crud.Create<ShareDA>(Share);

                // MANUAL MAPPING OF RETURNED SHARE VALUES TO OUR SHAREMODEL
                ShareModel addedShare = new ShareModel
                {
                    Id = Share.Id,
                    ListId = Share.ListId,
                    UserId = Share.UserId
                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Share added successfully");
                result.internalMessage = "LOGIC.Services.ShareService:  AddShare() method executed successfully.";
                result.result_set = addedShare;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add Share. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: AddShare(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<ShareModel>> DeleteShare(int id)
        {
            Generic_ResultSet<ShareModel> result = new Generic_ResultSet<ShareModel>();
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

        public async Task<Generic_ResultSet<ShareModel>> DeleteSharesByListId(int listId)
        {
            Generic_ResultSet<ShareModel> result = new Generic_ResultSet<ShareModel>();
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

        public async Task<Generic_ResultSet<ShareModel>> GetShareById(int id)
        {
            Generic_ResultSet<ShareModel> result = new Generic_ResultSet<ShareModel>();
            try
            {
                // GET Share FROM DB
                ShareDA Share = await _crud.Read<ShareDA>(id);

                // MANUAL MAPPING OF RETURNED SHARE VALUES TO SHAREMODEL
                ShareModel returnedShare = new ShareModel
                {
                    Id = Share.Id,
                    ListId = Share.ListId,
                    UserId = Share.UserId

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Share {0} was found successfully");
                result.internalMessage = "LOGIC.Services.ShareService: GetShareById() method executed successfully.";
                result.result_set = returnedShare;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Share.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: GetShareById(): {0}", exception.Message);
                // Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<ShareModel>>> GetSharesByListId(int listId)
        {
            Generic_ResultSet<List<ShareModel>> result = new Generic_ResultSet<List<ShareModel>>();
            result.result_set = new List<ShareModel>();
            try
            {
                // GET SHARES TO LIST ID FROM DB
                List<ShareDA> Shares = await _shareOperations.GetSharesByListId(listId);

                // MANUAL MAPPING OF RETURNED SHARES VALUES TO SHAREMODEL
                Shares.ForEach(app => {
                    result.result_set.Add(new ShareModel
                    {
                        Id = app.Id,
                        ListId = app.ListId,
                        UserId = app.UserId
                    });
                });

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your shares were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.ShareService: GetSharesByListId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find the shares you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ShareService: GetSharesByUserId(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<ShareModel>>> GetSharesByUserId(string userId)
        {
            Generic_ResultSet<List<ShareModel>> result = new Generic_ResultSet<List<ShareModel>>();
            result.result_set = new List<ShareModel>();
            try
            {
                // GET SHARES TO USER ID FROM DB
                List<ShareDA> Shares = await _shareOperations.GetSharesByUserId(userId);

                // MANUAL MAPPING OF RETURNED SHARES VALUES TO SHAREMODEL
                Shares.ForEach(app => {
                    result.result_set.Add(new ShareModel
                    {
                        Id = app.Id,
                        ListId = app.ListId,
                        UserId = app.UserId
                    });
                });

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your shares were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.ShareService: GetSharesByUserId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find the shares you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.ShareService: GetSharesByUserId(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<ShareModel>> UpdateShare(int id, string userId, int listId)
        {
            Generic_ResultSet<ShareModel> result = new Generic_ResultSet<ShareModel>();
            try
            {
                ShareDA Share = new ShareDA
                {
                    Id = id,
                    UserId = userId,
                    ListId = listId
                };
                // UPDATE SHARE FROM DB
                Share = await _crud.Update<ShareDA>(Share, id);

                // MANUAL MAPPING OF UPDATED SHARE VALUES TO SHAREMODEL
                ShareModel updatedShare = new ShareModel
                {
                    Id = Share.Id,
                    UserId = Share.UserId,
                    ListId = Share.ListId

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Share {0} was updated successfully");
                result.internalMessage = "LOGIC.Services.ShareService: UpdateShare() method executed successfully.";
                result.result_set = updatedShare;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update Share.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ShareService: UpdateShare(): {0}", exception.Message);
            }
            return result;
        }
    }
}
