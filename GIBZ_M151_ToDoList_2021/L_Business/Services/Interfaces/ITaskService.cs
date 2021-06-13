using L_Business.Models;
using L_Business.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface ITaskService
    {
        Task<Generic_ResultSet<TaskModel>> AddTask(string title, string description, int listId, int statusId, string userId);
        Task<Generic_ResultSet<TaskModel>> GetTaskById(int id);
        Task<Generic_ResultSet<TaskModel>> UpdateTask(int id, string title, string description, int listId, int statusId, string userId);
        Task<Generic_ResultSet<TaskModel>> DeleteTask(int id);
        Task<Generic_ResultSet<List<TaskViewModel>>> GetTasksByListId(int listId);
        Task<Generic_ResultSet<TaskModel>> DeleteTasksByListId(int listId);
        Task<Generic_ResultSet<TaskViewModel>> GetTaskViewModel(int id);
        Task<Generic_ResultSet<TaskModel>> ChangeStatus(int id, int statusId);

    }
}
