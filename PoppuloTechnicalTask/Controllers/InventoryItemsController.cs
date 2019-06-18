using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoppuloTechnicalTask.Models.DbContext;
using PoppuloTechnicalTask.Models.InventoryCategory;
using PoppuloTechnicalTask.Models.InventoryItem;
using PoppuloTechnicalTask.Repositories;

namespace PoppuloTechnicalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly PoppuloDbContext _context;
        public InventoryItemRepository InventoryItemRepository;

        public InventoryItemsController(PoppuloDbContext context)
        {
            _context = context;
            InventoryItemRepository = new InventoryItemRepository(context);
        }

        // GET: api/InventoryItems
        [HttpGet]
        public  ActionResult<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            return  InventoryItemRepository.GetAllInventoryItem();
        }

        // GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public  ActionResult<InventoryItem> GetInventoryItem(int id)
        {
            var inventoryItem = InventoryItemRepository.GetInventoryItem(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // PUT: api/InventoryItems/5
        [HttpPut("{id}")]
        public IActionResult PutInventoryItem(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.ItemId)
            {
                return BadRequest();
            }

            if (inventoryItem.ItemQuantity > 5)
            {
              
                return BadRequest("Quantity is above limit");

            }

            if (InventoryItemRepository.GetTotalQuantity()+inventoryItem.ItemQuantity > 200)
            {
                return BadRequest($"Total items are above 200, your current limit to add is {200- InventoryItemRepository.GetTotalQuantity()}");
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InventoryItems
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            if (inventoryItem.ItemQuantity > 5)
            {

                return BadRequest("Quantity is above limit");

            }

            if (InventoryItemRepository.GetTotalQuantity() + inventoryItem.ItemQuantity > 200)
            {
                return BadRequest($"Total items are above 200, your current limit to add is {200 - InventoryItemRepository.GetTotalQuantity()}");
            }
            _context.InventoryItems.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.ItemId }, inventoryItem);
        }

        // DELETE: api/InventoryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryItem>> DeleteInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return inventoryItem;
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItems.Any(e => e.ItemId == id);
        }
       
    }
}
