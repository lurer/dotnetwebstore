﻿using BOL.Models;
using DAL.DbModels;
using DAL.Utilities;
using System;

namespace DAL.DBOperations.DataServices
{
    public class CategoryService : AbstractService<DbItemCategory, ItemCategory>
    {
        public override ItemCategory Insert(ItemCategory inObj)
        {
            DbItemCategory dbCategory = new DbItemCategory { CategoryName = inObj.CategoryName };
            using (var context = new DataContext())
            {

                try
                {
                    context.Category.Add(dbCategory);
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

            }
            return transFromDbToBusiness(dbCategory);
        }

        public override ItemCategory Update(ItemCategory obj)
        {
            var dbCategory = transFromBusinessToDb(obj);
            using (var context = new DataContext())
            {
                try
                {
                    context.Entry(dbCategory).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (CustomDbException e)
                {
                    e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
                }

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