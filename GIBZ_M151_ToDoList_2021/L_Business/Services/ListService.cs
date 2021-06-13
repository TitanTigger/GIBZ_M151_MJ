using L_Business.Models;
using L_Business.Models.List;
using L_Business.Models.Share;
using L_Business.Services.Interfaces;
using L_DataAccess.Entities;
using L_DataAccess.Functions.Crud;
using L_DataAccess.Functions.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services
{
    public class ListService : IListService
    {
        private ICRUD _crud = new CRUD();

        public async Task<Generic_ResultSet<ListModel>> AddList(string name, string username)
        {
            // INIT SERVICES
            IShareService _shareService = new ShareService();
            IUserService _userService = new UserService();

            Generic_ResultSet<ListModel> result = new Generic_ResultSet<ListModel>();
            try
            {
                // INIT NEW DB ENTITY OF List
                ListDA List = new ListDA
                {
                    Name = name
                };
                

                // ADD List TO DB
                List = await _crud.Create<ListDA>(List);

                await _shareService.AddShare(username, List.Id);

                // MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                ListModel addedList = new ListModel
                {
                    Id = List.Id,
                    Name = List.Name,                   
                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = "List added successfully";
                result.internalMessage = "LOGIC.Services.ListService:  AddList() method executed successfully.";
                result.result_set = addedList;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add list. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: AddList(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<ListModel>> DeleteList(int id)
        {
            // INIT SERVICES
            ITaskService _taskService = new TaskService();
            IShareService _shareService = new ShareService();

            Generic_ResultSet<ListModel> result = new Generic_ResultSet<ListModel>();
            try
            {
                // DELETE ALL TASKS FROM LIST
                await _taskService.DeleteTasksByListId(id);

                // DELETE ALL SHARE ENTRIES FROM LIST
                await _shareService.DeleteSharesByListId(id);

                // DELETE LIST
                await _crud.Delete<ListDA>(id);

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("List deleted successfully");
                result.internalMessage = "LOGIC.Services.ListService:  DeleteList() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to delete list. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: DeleteList(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<ListModel>> GetListById(int id)
        {
            Generic_ResultSet<ListModel> result = new Generic_ResultSet<ListModel>();
            try
            {
                // GET List FROM DB
                ListDA List = await _crud.Read<ListDA>(id);

                // MANUAL MAPPING OF RETURNED LIST VALUES TO LISTMODEL
                ListModel returnedList = new ListModel
                {
                    Id = List.Id,
                    Name = List.Name
                    
                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("List {0} was found successfully", returnedList.Name);
                result.internalMessage = "LOGIC.Services.ListService: GetListById() method executed successfully.";
                result.result_set = returnedList;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find list.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: GetListById(): {0}", exception.Message);              
            }
            return result;
        }

        public async Task<Generic_ResultSet<ListModel>> UpdateList(int id, string name)
        {
            Generic_ResultSet<ListModel> result = new Generic_ResultSet<ListModel>();
            try
            {
                ListDA List = new ListDA
                {
                    Id = id,
                    Name = name
                };
                // UPDATE LIST FROM DB
                List = await _crud.Update<ListDA>(List, id);

                // MANUAL MAPPING OF UPDATED LIST VALUES TO LISTMODEL
                ListModel updatedList = new ListModel
                {
                    Id = List.Id,
                    Name = List.Name,
                    
                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("List {0} was updated successfully", updatedList.Name);
                result.internalMessage = "LOGIC.Services.ListService: UpdateList() method executed successfully.";
                result.result_set = updatedList;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update list.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: UpdateList(): {0}", exception.Message);
                // Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<ListModel>>> GetListsByUser(string username)
        {
            IUserService _userService = new UserService();
            IShareService _shareService = new ShareService();
            Generic_ResultSet<List<ListModel>> result = new Generic_ResultSet<List<ListModel>>();
            result.result_set = new List<ListModel>();
            try
            {
                IdentityUser User = await _userService.GetUserByUsername(username);
                // GET Applicant FROM DB
                List<ShareModel> Shares = (await _shareService.GetSharesByUserId(User.Id)).result_set;

                // MANUAL MAPPING OF RETURNED Task VALUES TO Task_ResultSet
                foreach(var share in Shares)
                {
                    result.result_set.Add((await this.GetListById(share.ListId)).result_set);
                }

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your tasks were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.TasksService: GetTasksByListId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find the tasks you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.TaskService: GetTasksByListId(): {0}", exception.Message);
                // Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<ListDetailViewModel>> GetListDetail(int id)
        {
            IUserService _userService = new UserService();
            IStatusService _statusService = new StatusService();
            ITaskService _taskService = new TaskService();
            Generic_ResultSet<ListDetailViewModel> result = new Generic_ResultSet<ListDetailViewModel>();
            try
            {
                ListDetailViewModel listDetail = new();
                listDetail.ListId = id;
                listDetail.Users = await _userService.GetUsersToList(id);
                listDetail.Statuses = (await _statusService.GetAllStatus()).result_set;
                listDetail.Tasks = (await _taskService.GetTasksByListId(id)).result_set;

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = "List {0} was found successfully";
                result.internalMessage = "LOGIC.Services.ListService: GetListDetail() method executed successfully.";
                result.result_set = listDetail;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find list.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: GetListDetail(): {0}", exception.Message);
            }
            return result;
        }
    }
}
