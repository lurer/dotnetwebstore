using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBOperations.DataServices;

namespace BLL.BussinessObjectOperations
{
    public class CategoryBLL : InterfaceBLL<ItemCategory>
    {
        public void Delete(int id)
        { 
        
            new CategoryService().Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ItemCategory GetById(int? id)
        {
            return new CategoryService().GetById(id);
        }

        public IEnumerable<ItemCategory> GetList()
        {
            return new CategoryService().GetList();
        }

        public ItemCategory Insert(ItemCategory obj)
        {
            return new CategoryService().Insert(obj);
        }

        public ItemCategory Update(ItemCategory obj)
        {
            return new CategoryService().Update(obj);
        }

        List<ItemCategory> InterfaceBLL<ItemCategory>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
