using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Models.Share
{
    public class ShareModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ListId { get; set; }
        public int RoleId { get; set; }
    }
}
