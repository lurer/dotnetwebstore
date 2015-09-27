using BOL.Models;
using DataServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BussinessTransactions
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

        public Item GetByStringId(string id)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetList()
        {
            return service.GetList();
        }

        public void Insert(Item obj)
        {
            service.Insert(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Item obj)
        {
            service.Update(obj);
        }
    }
}
