using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.Entities
{
    public class TaskDA
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }
        public int StatusId { get; set;}
        public string UserId { get; set; }
    }
}
