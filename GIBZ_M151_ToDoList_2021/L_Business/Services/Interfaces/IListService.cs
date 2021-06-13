using L_Business.Models;
using L_Business.Models.List;
using L_Business.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_Business.Services.Interfaces
{
    public interface IListService
    {
        Task<Generic_ResultSet<ListModel>> AddList(string name, string username);
        Task<Generic_ResultSet<ListModel>> GetListById(int id);
        Task<Generic_ResultSet<ListModel>> UpdateList(int id, string name);
        Task<Generic_ResultSet<ListModel>> DeleteList(int id);
        Task<Generic_ResultSet<List<ListModel>>> GetListsByUser(string username);
        Task<Generic_ResultSet<ListDetailViewModel>> GetListDetail(int id);

    }
}
