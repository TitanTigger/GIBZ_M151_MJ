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
     

        public async Task<Generic_ResultSet<TaskModel>> AddTask(string title, string description, int listId, int statusId, string userId)
        {
            Generic_ResultSet<TaskModel> result = new Generic_ResultSet<TaskModel>();
            try
            {
                // INIT NEW DB ENTITY OF Task
                TaskDA Task = new TaskDA
                {
                    Title = title,
                    Description = description,
                    ListId = listId,
                    StatusId = statusId,
                    UserId = userId
                };


                // ADD Task TO DB
                Task = await _crud.Create<TaskDA>(Task);

                // MANUAL MAPPING OF RETURNED TASK VALUES TO OUR TASKMODEL
                TaskModel addedTask = new TaskModel
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    StatusId = Task.StatusId,
                    UserId = Task.UserId
                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task added successfully", title);
                result.internalMessage = "LOGIC.Services.TaskService:  AddTask() method executed successfully.";
                result.result_set = addedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to add Task. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: AddTask(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<TaskModel>> ChangeStatus(int id, int statusId)
        {
            Generic_ResultSet<TaskModel> result = new Generic_ResultSet<TaskModel>();
            try
            {
                TaskDA Task = await _crud.Read<TaskDA>(id);
                Task.StatusId = statusId;

                Task = await _taskOperations.ChangeStatus(Task);

                TaskModel updatedTask = new TaskModel
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    UserId = Task.UserId,
                    StatusId = Task.StatusId

                };

                result.result_set = updatedTask;
                result.userMessage = "Status changed successfully";
                result.internalMessage = "LOGIC.Services.TaskService:  ChangeStatus() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Task. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: ChangeStatus(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<TaskModel>> DeleteTask(int id)
        {
            Generic_ResultSet<TaskModel> result = new Generic_ResultSet<TaskModel>();
            try
            {
                await _crud.Delete<TaskDA>(id);
                result.userMessage = "Task deleted successfully";
                result.internalMessage = "LOGIC.Services.TaskService:  DeleteTask() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Task. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: DeleteTask(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<TaskModel>> DeleteTasksByListId(int listId)
        {
            Generic_ResultSet<TaskModel> result = new Generic_ResultSet<TaskModel>();
            try
            {
                await _taskOperations.DeleteTasksByListId(listId);
                result.userMessage = "Tasks deleted successfully";
                result.internalMessage = "LOGIC.Services.TaskService:  DeleteTasksByListId() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                result.exception = exception;
                result.userMessage = "Failed to delete Task. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: DeleteTasksByListId(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<TaskModel>> GetTaskById(int id)
        {
            Generic_ResultSet<TaskModel> result = new Generic_ResultSet<TaskModel>();
            try
            {
                // GET Task FROM DB
                TaskDA Task = await _crud.Read<TaskDA>(id);

                // MANUAL MAPPING OF RETURNED TASK VALUES TO TASKMODULE
                TaskModel returnedTask = new TaskModel
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    StatusId = Task.StatusId,
                    UserId = Task.UserId

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task {0} was found successfully", returnedTask.Title);
                result.internalMessage = "LOGIC.Services.TaskService: GetTaskById() method executed successfully.";
                result.result_set = returnedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Task.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: GetTaskById(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<List<TaskViewModel>>> GetTasksByListId(int listId)
        {
            IStatusService _statusService = new StatusService();
            IUserService _userService = new UserService();

            Generic_ResultSet<List<TaskViewModel>> result = new Generic_ResultSet<List<TaskViewModel>>();
            result.result_set = new List<TaskViewModel>();
            try
            {
                // GET TASKS BY LIST ID FROM DB
                List<TaskDA> Tasks = await _taskOperations.GetTasksByListId(listId);

                // MANUAL MAPPING OF RETURNED TASKS VALUES TO TASKMODEL
                foreach(var task in Tasks)
                {
                    result.result_set.Add(new TaskViewModel
                    {
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        ListId = task.ListId,
                        Status = (await _statusService.GetStatusById(task.StatusId)).result_set,
                        User = await _userService.GetUserById(task.UserId)
                    });
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
            }
            return result;
        }

        public async Task<Generic_ResultSet<TaskViewModel>> GetTaskViewModel(int id)
        {
            IStatusService _statusService = new StatusService();
            IUserService _userService = new UserService();

            Generic_ResultSet<TaskViewModel> result = new Generic_ResultSet<TaskViewModel>();
            try
            {
                // GET Task FROM DB
                TaskDA Task = await _crud.Read<TaskDA>(id);

                // MANUAL MAPPING OF RETURNED TASK VALUES TO TASKVIEWMODEL
                TaskViewModel returnedTask = new()
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    Status = (await _statusService.GetStatusById(Task.StatusId)).result_set,
                    User = await _userService.GetUserById(Task.UserId)

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task {0} was found successfully", returnedTask.Title);
                result.internalMessage = "LOGIC.Services.TaskService: GetTaskViewModel() method executed successfully.";
                result.result_set = returnedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to find Task.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: GetTaskViewModel(): {0}", exception.Message);
            }
            return result;
        }

        public async Task<Generic_ResultSet<TaskModel>> UpdateTask(int id, string title, string description, int listId, int statusId, string userId)
        {
            Generic_ResultSet<TaskModel> result = new Generic_ResultSet<TaskModel>();
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
                // UPDATE TASK FROM DB
                Task = await _crud.Update<TaskDA>(Task, id);

                // MANUAL MAPPING OF UPDATED TASK VALUES TO TASKMODEL
                TaskModel updatedTask = new TaskModel
                {
                    Id = Task.Id,
                    Title = Task.Title,
                    Description = Task.Description,
                    ListId = Task.ListId,
                    UserId = Task.UserId,
                    StatusId = Task.StatusId

                };

                // SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Task {0} was updated successfully", updatedTask.Title);
                result.internalMessage = "LOGIC.Services.TaskService: UpdateTask() method executed successfully.";
                result.result_set = updatedTask;
                result.success = true;
            }
            catch (Exception exception)
            {
                // SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to update Task.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.TaskService: UpdateTask(): {0}", exception.Message);
            }
            return result;
        }
    }
}
