using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBOperations.DataServices;
using DAL.DBOperations;
using DAL.DbModels;

namespace BLL.BussinessObjectOperations
{
    public class CategoryBLL : InterfaceBLL<ItemCategory>
    {
        private IDataService<DbItemCategory, ItemCategory> service;

        public CategoryBLL(IDataService<DbItemCategory, ItemCategory> service)
        {
            this.service = service;
        }

        public CategoryBLL()
        {
            service = new CategoryService();
        }

        public Boolean Delete(int id)
        { 
        
            return service.Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public ItemCategory GetById(int? id)
        {
            return service.GetById(id);
        }

        public List<ItemCategory> GetList()
        {
            return service.GetList();
        }

        public ItemCategory Insert(ItemCategory obj)
        {
            return service.Insert(obj);
        }

        public ItemCategory Update(ItemCategory obj)
        {
            return service.Update(obj);
        }


    }
}
