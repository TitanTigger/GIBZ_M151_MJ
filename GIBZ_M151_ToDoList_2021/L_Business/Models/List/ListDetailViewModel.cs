using L_Business.Models.Status;
using L_Business.Models.Task;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Models.List
{
    public class ListDetailViewModel
    {
        public int ListId;
        public List<TaskViewModel> Tasks { get; set; }
        public List<StatusModel> Statuses { get; set; }
        public List<IdentityUser> Users { get; set; }
    }
}
