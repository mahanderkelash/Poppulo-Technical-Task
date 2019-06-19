using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoppuloTechnicalTask.Models.DbContext;
using PoppuloTechnicalTask.Models.InventoryCategory;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace PoppuloTechnicalTask.Repositories
{
    public class InventoryItemRepository
    {
        private  PoppuloDbContext _context;
        public IQueryable<SelectListItem> categories;
        public InventoryItemRepository(PoppuloDbContext context)
        {
            _context = context;
        }

        public List<InventoryItem> GetAllInventoryItem()
        {
            return _context.InventoryItems.Include(i => i.Category).ToList();
        }

        public void AddNewItem(InventoryItem item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public SelectList GetCategoryList()
        {
            categories = _context.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName
            });
            var categorieslist = new SelectList(categories, "Value", "Text");
            return categorieslist;
        }

        public int GetTotalQuantity()
        {
            int count = 0;
            var items = _context.InventoryItems.ToList();
            foreach (var item in items)
            {
                count = count + item.ItemQuantity;
            }

            return count;
        }

        public InventoryItem GetInventoryItem(string itemName)
        {
            var inventoryitem = _context.InventoryItems.FirstOrDefault(x =>
                x.ItemName == itemName);
            return inventoryitem;
        }

        public InventoryItem GetInventoryItem(int id)
        {
            var InventoryItem = _context.InventoryItems.Include(x => x.Category)
                .FirstOrDefault(m => m.ItemId == id);
            return InventoryItem;
        }

        public IEnumerable<InventoryItem> GetInventoryItemsInPriceRange(double minPrice, double maxPrice)
        {
            var items = _context.InventoryItems.Include(x => x.Category)
                .Where(x => x.ItemPrice < maxPrice && x.ItemPrice > minPrice).ToList();

            return items;

        }

        public void UpdateInventoryItem(InventoryItem item)
        {

            _context.Update(item);
            _context.SaveChanges();

        }

        public void DeleteItem(InventoryItem item)
        {
            _context.InventoryItems.Remove(item);
            _context.SaveChangesAsync();
        }

        public List<InventoryItem> GetLastFiveItems()
        {
            return _context.InventoryItems.Include(x => x.Category).OrderByDescending(i => i.ItemEntryDate).Take(5).ToList();
        }

       



    }
}
