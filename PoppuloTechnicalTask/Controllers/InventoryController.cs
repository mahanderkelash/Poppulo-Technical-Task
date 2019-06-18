using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoppuloTechnicalTask.Models.DbContext;
using PoppuloTechnicalTask.Models.InventoryCategory;
using PoppuloTechnicalTask.Models.InventoryItem;
using PoppuloTechnicalTask.Repositories;

namespace PoppuloTechnicalTask.Controllers
{
    public class InventoryController : Controller
    {
        private  PoppuloDbContext _context;

       

        public InventoryItemRepository InventoryItemRepository;
        public InventoryController(PoppuloDbContext context)
        {
            _context = context;
           InventoryItemRepository= new InventoryItemRepository(context);
        }

        public IActionResult Index()
        {
            var model = InventoryItemRepository.GetAllInventoryItem();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = new InventoryItemViewModel();
            model.Categories = InventoryItemRepository.GetCategoryList();
            model.InventoryItem = new InventoryItem();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( InventoryItemViewModel inventoryItemViewModel)
        {
            if (ModelState.IsValid)
            {
                if (inventoryItemViewModel.InventoryItem.ItemQuantity > 5)
                {
                    var model = CreateInventoryItemViewModel(inventoryItemViewModel.InventoryItem,
                        "Max Quantity for an item is 5. please try again Later");
                    return View(model);

                }
                else if (InventoryItemRepository.GetTotalQuantity() > 200)
                {
                    var model = CreateInventoryItemViewModel(inventoryItemViewModel.InventoryItem,
                        $"Your current limit of adding item is exceeded, you can add {200- InventoryItemRepository.GetTotalQuantity()} items only");
                    return View(model);
                }
                else
                {
                    var inventoryitem = InventoryItemRepository.GetInventoryItem(inventoryItemViewModel.InventoryItem.ItemName);
                    if(inventoryitem!=null)
                     {
                        var model = CreateInventoryItemViewModel(inventoryItemViewModel.InventoryItem,
                            "Item name already exists try again with some other name");
                        return View(model);
                      }

                    InventoryItemRepository.AddNewItem(inventoryItemViewModel.InventoryItem);
                    return RedirectToAction(nameof(Index));
                }}

            return View(inventoryItemViewModel);
        }

        public  IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var InventoryItem = InventoryItemRepository.GetInventoryItem(id);
        
            if (InventoryItem == null)
            {
                return NotFound();
            }

            var model = CreateInventoryItemViewModel(InventoryItem, "");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , InventoryItemViewModel inventoryItemViewModel)
        {
            if (id != inventoryItemViewModel.InventoryItem.ItemId)
            {
                return NotFound();
            }

           
            if (ModelState.IsValid)
            {
                if (inventoryItemViewModel.InventoryItem.ItemQuantity > 5)
                {
                    var model = CreateInventoryItemViewModel(inventoryItemViewModel.InventoryItem,
                        "Max Quantity for an item is 5. please try again Later");
                    return View(model);

                }
                else
                {
                    var inventoryitem = InventoryItemRepository.GetInventoryItem(id);
                    if (inventoryitem != null)
                    {
                        inventoryitem.ItemName = inventoryItemViewModel.InventoryItem.ItemName;
                        inventoryitem.ItemId = inventoryItemViewModel.InventoryItem.ItemId;
                        inventoryitem.ItemQuantity = inventoryItemViewModel.InventoryItem.ItemQuantity;
                        inventoryitem.ItemPrice = inventoryItemViewModel.InventoryItem.ItemPrice;
                        inventoryitem.CategoryId = inventoryItemViewModel.InventoryItem.CategoryId;
                       
                        InventoryItemRepository.UpdateInventoryItem(inventoryitem);
                        return RedirectToAction(nameof(Index));
                    }

         
                    
                }
            }

            var inventoryItemVm = CreateInventoryItemViewModel(inventoryItemViewModel.InventoryItem, "Please input all fields");
            return View(inventoryItemVm);
        }

        public IActionResult SearchItems()
        {
            var model = new MinMaxPrice();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchItems(MinMaxPrice model)
        {
            if (!ModelState.IsValid)
            {
                return View("SearchItems", model);
            }
            var listItems = InventoryItemRepository.GetInventoryItemsInPriceRange(model.MinPrice, model.MaxPrice);

            return View("Index", listItems);
        }


        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var InventoryItem = InventoryItemRepository.GetInventoryItem(id);
            if (InventoryItem == null)
            {
                return NotFound();
            }

            return View(InventoryItem);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var InventoryItem = InventoryItemRepository.GetInventoryItem(id);

            if (InventoryItem == null)
            {
                return NotFound();
            }

            return View(InventoryItem);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var item = InventoryItemRepository.GetInventoryItem(id);
            InventoryItemRepository.DeleteItem(item);
            return RedirectToAction(nameof(Index));

        }
        public InventoryItemViewModel CreateInventoryItemViewModel(InventoryItem inventoryItem, string ErrorMessage)
        {
            var model = new InventoryItemViewModel();
            
            model.Categories = InventoryItemRepository.GetCategoryList();
            model.InventoryItem = inventoryItem;
            model.ErrorMessage = ErrorMessage;
            return model;

        }
    }
}