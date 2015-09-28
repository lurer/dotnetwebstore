using BOL.Models;
using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.DataServices
{
    public class CategoryService : AbstractService<DbItemCategory, ItemCategory>
    {
        public override void Insert(ItemCategory inObj)
        {
            DbItemCategory dbCategory = new DbItemCategory { CategoryName = inObj.CategoryName };
            using (var context = new DataContext())
            {
                context.Category.Add(dbCategory);
                context.SaveChanges();
            }
        }

        public override void Update(ItemCategory obj)
        {
            DbItemCategory dbCategory = new DbItemCategory { CategoryName = obj.CategoryName };
            using (var context = new DataContext())
            {
                context.Entry(dbCategory).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        internal override DbItemCategory transFromBusinessToDb(ItemCategory obj)
        {
            throw new NotImplementedException();
        }

        internal override ItemCategory transFromDbToBusiness(DbItemCategory dbObj)
        {
            throw new NotImplementedException();
        }
    }
}
