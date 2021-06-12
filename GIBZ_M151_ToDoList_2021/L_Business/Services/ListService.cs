﻿using L_Business.Models;
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
        private ShareService _shareService = new ShareService();
        private TaskService _taskService = new TaskService();
        private UserService _userService = new UserService();

        public async Task<Generic_ResultSet<List_ResultSet>> AddList(string name, string username)
        {
            
            Generic_ResultSet<List_ResultSet> result = new Generic_ResultSet<List_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF List
                ListDA List = new ListDA
                {
                    Name = name
                };
                

                //ADD List TO DB
                List = await _crud.Create<ListDA>(List);

                IdentityUser user = await _userService.GetUserByUsername(username);
                await _shareService.AddShare(user.Id, 1, List.Id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                List_ResultSet addedList = new List_ResultSet
                {
                    Id = List.Id,
                    Name = List.Name,                   
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("List added successfully", name);
                result.internalMessage = "LOGIC.Services.ListService:  AddList() method executed successfully.";
                result.result_set = addedList;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add list. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: AddList(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List_ResultSet>> DeleteList(int id)
        {
            
            Generic_ResultSet<List_ResultSet> result = new Generic_ResultSet<List_ResultSet>();
            try
            {
                await _taskService.DeleteTasksByListId(id);
                await _shareService.DeleteSharesByListId(id);
                await _crud.Delete<ListDA>(id);
                result.userMessage = string.Format("List deleted successfully");
                result.internalMessage = "LOGIC.Services.ListService:  DeleteList() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete list. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: DeleteList(): {0}", exception.Message); ;
            }
            return result;
        }

        public async Task<Generic_ResultSet<List_ResultSet>> GetListById(int id)
        {
            Generic_ResultSet<List_ResultSet> result = new Generic_ResultSet<List_ResultSet>();
            try
            {
                //GET List FROM DB
                ListDA List = await _crud.Read<ListDA>(id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO List_ResultSet
                List_ResultSet returnedList = new List_ResultSet
                {
                    Id = List.Id,
                    Name = List.Name
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("List {0} was found successfully", returnedList.Name);
                result.internalMessage = "LOGIC.Services.ListService: GetListById() method executed successfully.";
                result.result_set = returnedList;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find list.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: GetListById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List_ResultSet>> UpdateList(int id, string name)
        {
            Generic_ResultSet<List_ResultSet> result = new Generic_ResultSet<List_ResultSet>();
            try
            {
                ListDA List = new ListDA
                {
                    Id = id,
                    Name = name
                };
                //UPDATE Applicant FROM DB
                List = await _crud.Update<ListDA>(List, id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                List_ResultSet updatedList = new List_ResultSet
                {
                    Id = List.Id,
                    Name = List.Name,
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("List {0} was updated successfully", updatedList.Name);
                result.internalMessage = "LOGIC.Services.ListService: UpdateList() method executed successfully.";
                result.result_set = updatedList;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update list.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.ListService: UpdateList(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<List_ResultSet>>> GetListsByUserId(string userId)
        {
            
            Generic_ResultSet<List<List_ResultSet>> result = new Generic_ResultSet<List<List_ResultSet>>();
            result.result_set = new List<List_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                List<Share_ResultSet> Shares = (await _shareService.GetSharesByUserId(userId)).result_set;

                //MANUAL MAPPING OF RETURNED Task VALUES TO Task_ResultSet
                Shares.ForEach(async share => {
                    result.result_set.Add((await this.GetListById(share.ListId)).result_set);
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = "Your tasks were located successfully";
                result.internalMessage = "LOGIC.Services.Implementation.TasksService: GetTasksByListId() method executed successfully.";
                result.result_set = result.result_set;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find the tasks you were looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.TaskService: GetTasksByListId(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
