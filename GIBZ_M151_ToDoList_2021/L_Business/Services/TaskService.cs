using L_Business.Models;
using L_Business.Models.Task;
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
    public class TaskService : ITaskService
    {
        private ICRUD _crud = new CRUD();
        private ITaskOperations _taskOperations = new TaskOperations();

        public async Task<Generic_ResultSet<Task_ResultSet>> AddTask(string title, string description, int listId, int statusId, string userId)
        {
            Generic_ResultSet<Task_ResultSet> result = new Generic_ResultSet<Task_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Task
                TaskDA Task = new TaskDA
                {
                    Title = title,
                    Description = description,
                    ListId = listId,
                    StatusId = statusId,
                    UserId = userId
                };


                //ADD Task TO DB
                Task = await _crud.Create<TaskDA>(Task);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Task_ResultSet addedTask = new Task_ResultSet
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    StatusId = Task.StatusId,
                    UserId = Task.UserId
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task added successfully", title);
                result.internalMessage = "LOGIC.Services.TaskService:  AddTask() method executed successfully.";
                result.result_set = addedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add Task. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: AddTask(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Task_ResultSet>> DeleteTask(int id)
        {
            Generic_ResultSet<Task_ResultSet> result = new Generic_ResultSet<Task_ResultSet>();
            try
            {
                await _crud.Delete<TaskDA>(id);
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

        public async Task<Generic_ResultSet<Task_ResultSet>> DeleteTasksByListId(int listId)
        {
            Generic_ResultSet<Task_ResultSet> result = new Generic_ResultSet<Task_ResultSet>();
            try
            {
                await _taskOperations.DeleteTasksByListId(listId);
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

        public async Task<Generic_ResultSet<Task_ResultSet>> GetTaskById(int id)
        {
            Generic_ResultSet<Task_ResultSet> result = new Generic_ResultSet<Task_ResultSet>();
            try
            {
                //GET Task FROM DB
                TaskDA Task = await _crud.Read<TaskDA>(id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO Task_ResultSet
                Task_ResultSet returnedTask = new Task_ResultSet
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    StatusId = Task.StatusId,
                    UserId = Task.UserId

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task {0} was found successfully", returnedTask.Title);
                result.internalMessage = "LOGIC.Services.TaskService: GetTaskById() method executed successfully.";
                result.result_set = returnedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Task.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: GetTaskById(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<Task_ResultSet>>> GetTasksByListId(int listId)
        {
            Generic_ResultSet<List<Task_ResultSet>> result = new Generic_ResultSet<List<Task_ResultSet>>();
            result.result_set = new List<Task_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                List<TaskDA> Tasks = await _taskOperations.GetTasksByListId(listId);

                //MANUAL MAPPING OF RETURNED Task VALUES TO Task_ResultSet
                Tasks.ForEach(app => {
                    result.result_set.Add(new Task_ResultSet
                    {
                        Id = app.Id,
                        Title = app.Title,
                        Description = app.Description,
                        ListId = app.ListId,
                        StatusId = app.StatusId,
                        UserId = app.UserId
                    });
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

        public async Task<Generic_ResultSet<Task_ResultSet>> UpdateTask(int id, string title, string description, int listId, int statusId, string userId)
        {
            Generic_ResultSet<Task_ResultSet> result = new Generic_ResultSet<Task_ResultSet>();
            try
            {
                TaskDA Task = new TaskDA
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    ListId = listId,
                    StatusId = statusId,
                    UserId = userId
                };
                //UPDATE Applicant FROM DB
                Task = await _crud.Update<TaskDA>(Task, id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                Task_ResultSet updatedTask = new Task_ResultSet
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    UserId = Task.UserId,
                    StatusId = Task.StatusId

                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task {0} was updated successfully", updatedTask.Title);
                result.internalMessage = "LOGIC.Services.TaskService: UpdateTask() method executed successfully.";
                result.result_set = updatedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update Task.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: UpdateTask(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
