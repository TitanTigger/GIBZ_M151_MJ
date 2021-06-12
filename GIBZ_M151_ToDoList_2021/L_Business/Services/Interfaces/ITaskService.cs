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
        Task<Generic_ResultSet<Task_ResultSet>> AddTask(string title, string description, int listId, int statusId, string userId);
        Task<Generic_ResultSet<Task_ResultSet>> GetTaskById(int id);
        Task<Generic_ResultSet<Task_ResultSet>> UpdateTask(int id, string title, string description, int listId, int statusId, string userId);
        Task<Generic_ResultSet<Task_ResultSet>> DeleteTask(int id);
        Task<Generic_ResultSet<List<Task_ResultSet>>> GetTasksByListId(int listId);
        Task<Generic_ResultSet<Task_ResultSet>> DeleteTasksByListId(int listId);

    }
}
