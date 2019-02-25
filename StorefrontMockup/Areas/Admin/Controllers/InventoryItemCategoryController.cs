using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StorefrontMockup.Data;

namespace StorefrontMockup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryItemCategoryController : Controller
    {
        private readonly StorefrontDbContext _context;

        public InventoryItemCategoryController(StorefrontDbContext context)
        {
            _context = context;
        }

        // GET: InventoryItemCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryItemCategories.ToListAsync());
        }

        // GET: InventoryItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItemCategory = await _context.InventoryItemCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItemCategory == null)
            {
                return NotFound();
            }

            return View(inventoryItemCategory);
        }

        // GET: InventoryItemCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryItemCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] InventoryItemCategory inventoryItemCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryItemCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryItemCategory);
        }

        // GET: InventoryItemCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItemCategory = await _context.InventoryItemCategories.FindAsync(id);
            if (inventoryItemCategory == null)
            {
                return NotFound();
            }
            return View(inventoryItemCategory);
        }

        // POST: InventoryItemCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] InventoryItemCategory inventoryItemCategory)
        {
            if (id != inventoryItemCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryItemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryItemCategoryExists(inventoryItemCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryItemCategory);
        }

        // GET: InventoryItemCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItemCategory = await _context.InventoryItemCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItemCategory == null)
            {
                return NotFound();
            }

            return View(inventoryItemCategory);
        }

        // POST: InventoryItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryItemCategory = await _context.InventoryItemCategories.FindAsync(id);
            _context.InventoryItemCategories.Remove(inventoryItemCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryItemCategoryExists(int id)
        {
            return _context.InventoryItemCategories.Any(e => e.Id == id);
        }
    }
}
