using L_Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using L_Presentation.Data;
using Microsoft.AspNetCore.Identity;

using L_Business.Services.Interfaces;
using L_Business.Services;
using L_Business.Models.List;
using L_Business.Models.Task;

namespace L_Presentation.Controllers {
    public class ListDetailController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ITaskService _taskService = new TaskService();
        private IListService _listService = new ListService();
        private IShareService _shareService = new ShareService();

        public ListDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            // Get list detail with tasks, users and statuses
            ListDetailViewModel listDetail = (await _listService.GetListDetail(id)).result_set;
            
            return View(listDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTask(int id, string userId, string description, string title, int listId, int statusId)
        {
            // Update task
            await _taskService.UpdateTask(id, title, description, listId, statusId, userId);           
            return RedirectToAction("Index", new { id = listId });
        }


        public async Task<IActionResult> ChangeStatus(int id, int statusId, bool back)
        {
            // Check if status change can work
            if(back)
            {
                if(statusId != 1)
                {
                    statusId -= 1;
                }
            } else
            {
                if(statusId != 3)
                {
                    statusId += 1;
                }
            }
            // Save changed status of task
            TaskModel task = (await _taskService.ChangeStatus(id, statusId)).result_set;
            return RedirectToAction("Index", new { id = task.ListId });
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            // Delete task
            await _taskService.DeleteTask(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskModel task)
        {
            // Create task
            await _taskService.AddTask(task.Title, task.Description, task.ListId, task.StatusId, task.UserId);
            return RedirectToAction("Index", new { id = task.ListId });
        }

        [HttpPost]
        public async Task<IActionResult> Share(int id, string username)
        {
            // Share list with other user by username
            await _shareService.AddShare(username, id);


            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
