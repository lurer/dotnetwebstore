using BOL.Models;
using DataServices.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
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

        public ItemCategory GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<ItemCategory> GetList()
        {
            return new CategoryService().GetList();
        }

        public void Insert(ItemCategory obj)
        {
            new CategoryService().Insert(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ItemCategory obj)
        {
            new CategoryService().Update(obj);
        }
    }
}
