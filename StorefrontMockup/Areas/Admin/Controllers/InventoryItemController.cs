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
    public class InventoryItemController : Controller
    {
        private readonly StorefrontDbContext _context;

        public InventoryItemController(StorefrontDbContext context)
        {
            _context = context;
        }

        // GET: InventoryItem
        public async Task<IActionResult> Index()
        {
            var storefrontDbContext = _context.InventoryItems.Include(i => i.InventoryItemCategory).Include(i => i.PrimaryPhoto).Include(i => i.UnitOfMeasure);
            return View(await storefrontDbContext.ToListAsync());
        }

        // GET: InventoryItem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItems
                .Include(i => i.InventoryItemCategory)
                .Include(i => i.PrimaryPhoto)
                .Include(i => i.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // GET: InventoryItem/Create
        public IActionResult Create()
        {
            ViewData["InventoryItemCategoryId"] = new SelectList(_context.InventoryItemCategories, "Id", "Name");
            ViewData["PrimaryPhotoId"] = new SelectList(_context.InventoryItemPhotos, "Id", "Url");
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitsOfMeasure, "Id", "SingularName");
            return View();
        }

        // POST: InventoryItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,PrimaryPhotoId,UnitOfMeasureId,InventoryItemCategoryId")] InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InventoryItemCategoryId"] = new SelectList(_context.InventoryItemCategories, "Id", "Name", inventoryItem.InventoryItemCategoryId);
            ViewData["PrimaryPhotoId"] = new SelectList(_context.InventoryItemPhotos, "Id", "Url", inventoryItem.PrimaryPhotoId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitsOfMeasure, "Id", "SingularName", inventoryItem.UnitOfMeasureId);
            return View(inventoryItem);
        }

        // GET: InventoryItem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItems.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            ViewData["InventoryItemCategoryId"] = new SelectList(_context.InventoryItemCategories, "Id", "Name", inventoryItem.InventoryItemCategoryId);
            ViewData["PrimaryPhotoId"] = new SelectList(_context.InventoryItemPhotos, "Id", "Url", inventoryItem.PrimaryPhotoId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitsOfMeasure, "Id", "SingularName", inventoryItem.UnitOfMeasureId);
            return View(inventoryItem);
        }

        // POST: InventoryItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,PrimaryPhotoId,UnitOfMeasureId,InventoryItemCategoryId")] InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryItemExists(inventoryItem.Id))
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
            ViewData["InventoryItemCategoryId"] = new SelectList(_context.InventoryItemCategories, "Id", "Name", inventoryItem.InventoryItemCategoryId);
            ViewData["PrimaryPhotoId"] = new SelectList(_context.InventoryItemPhotos, "Id", "Url", inventoryItem.PrimaryPhotoId);
            ViewData["UnitOfMeasureId"] = new SelectList(_context.UnitsOfMeasure, "Id", "SingularName", inventoryItem.UnitOfMeasureId);
            return View(inventoryItem);
        }

        // GET: InventoryItem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItems
                .Include(i => i.InventoryItemCategory)
                .Include(i => i.PrimaryPhoto)
                .Include(i => i.UnitOfMeasure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // POST: InventoryItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryItem = await _context.InventoryItems.FindAsync(id);
            _context.InventoryItems.Remove(inventoryItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItems.Any(e => e.Id == id);
        }
    }
}
