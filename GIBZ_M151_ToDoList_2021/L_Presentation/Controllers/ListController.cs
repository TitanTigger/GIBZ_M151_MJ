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
using L_Business.Services;
using L_Business.Services.Interfaces;
using L_Business.Models.List;
using Microsoft.AspNetCore.Authorization;

namespace L_Presentation.Controllers {
    public class ListController : Controller
    {
        private IListService _listService = new ListService();

        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            // Get all lists of current user
            List<ListModel> Lists = (await _listService.GetListsByUser(User.Identity.Name)).result_set;

            return View(Lists);
        }

        public async Task<IActionResult> Delete(int id)
        {
            // Delete list
            await _listService.DeleteList(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            // Create list
            await _listService.AddList(name, User.Identity.Name);            
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
