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
        public override ItemCategory Insert(ItemCategory inObj)
        {
            DbItemCategory dbCategory = new DbItemCategory { CategoryName = inObj.CategoryName };
            using (var context = new DataContext())
            {
                context.Category.Add(dbCategory);
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbCategory);
        }

        public override ItemCategory Update(ItemCategory obj)
        {
            var dbCategory = transFromBusinessToDb(obj);
            using (var context = new DataContext())
            {
                context.Entry(dbCategory).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return transFromDbToBusiness(dbCategory);
        }

        internal override DbItemCategory transFromBusinessToDb(ItemCategory obj)
        {
            return new DbItemCategory { CategoryName = obj.CategoryName };
        }

        internal override ItemCategory transFromDbToBusiness(DbItemCategory dbObj)
        {
            return new ItemCategory { CategoryId = dbObj.CategoryId, CategoryName = dbObj.CategoryName };
        }
    }
}
