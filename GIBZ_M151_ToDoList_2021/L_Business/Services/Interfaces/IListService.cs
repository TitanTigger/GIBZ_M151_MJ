using L_Business.Models;
using L_Business.Models.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface IListService
    {
        Task<Generic_ResultSet<List_ResultSet>> AddList(string name);
        Task<Generic_ResultSet<List_ResultSet>> GetListById(int id);
        Task<Generic_ResultSet<List_ResultSet>> UpdateList(int id, string name);
        Task<Generic_ResultSet<List_ResultSet>> DeleteList(int id);

    }
}
