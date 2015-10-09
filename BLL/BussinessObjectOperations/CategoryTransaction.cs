using BOL.Models;
using BLL.DBOperations.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public class CategoryTransaction : ITransaction<ItemCategory>
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

        List<ItemCategory> ITransaction<ItemCategory>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
