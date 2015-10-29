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
    public class ItemBLL : InterfaceBLL<Item>
    {
        private IDataService<DbItem, Item> service;


        public ItemBLL(IDataService<DbItem, Item> service)
        {
            this.service = service;
        }

        public ItemBLL()
        {
            service = new ItemService();
        }

        public Boolean Delete(int id)
        {
            return service.Delete(id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public Item GetById(int? id)
        {
            return service.GetById(id);
        }

        public List<Item> GetList()
        {
            return service.GetList();
        }

        public Item Insert(Item obj)
        {
            return service.Insert(obj);
        }

        public Item Update(Item obj)
        {
            return service.Update(obj);
        }
    }
}
