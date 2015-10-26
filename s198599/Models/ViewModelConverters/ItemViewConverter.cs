using BLL.BussinessObjectOperations;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Models.ViewModelConverters
{
    public class ItemViewConverter
    {

        public static Item convertToBussiness(ItemViewPopulated viewItem)
        {
            return new Item()
            {
                ItemID = viewItem.ItemID,
                ItemCode = viewItem.ItemCode,
                ItemDesc = viewItem.ItemDesc,
                Category = viewItem.SelectedCategory,
                InStock = viewItem.InStock,
                Price = viewItem.Price,
                ImgPath = viewItem.ImgPath
            };
        }

        public static ItemViewPopulated convertToView(Item item)
        {
            var categoryDb = new CategoryBLL();
            var categories = categoryDb.GetList();
            IEnumerable<SelectListItem> categoryList = categories.ToList().Select(x => new SelectListItem()
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName
            });

            var viewItem =  new ItemViewPopulated()
            {

                ItemID = item.ItemID,
                ItemCode = item.ItemCode,
                ItemDesc = item.ItemDesc,
                Categories = new SelectList(categoryList, "Value", "Text"),
                InStock = item.InStock,
                Price = item.Price,
                ImgPath = item.ImgPath
            };
            if (item.ItemID != 0)
                viewItem.SelectedCategoryName = categoryDb.GetById(item.Category).CategoryName;

            return viewItem;
        }
    }
}