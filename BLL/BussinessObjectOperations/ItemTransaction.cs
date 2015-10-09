using BOL.Models;
using BLL.DBOperations.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessObjectOperations
{
    public class ItemTransaction : ITransaction<Item>
    {
        private ItemService service;

        public ItemTransaction()
        {
            service = new ItemService();
        }

        public void Delete(int id)
        {
            service.Delete(id);
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
