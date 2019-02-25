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
    public class InventoryItemPhotoController : Controller
    {
        private readonly StorefrontDbContext _context;

        public InventoryItemPhotoController(StorefrontDbContext context)
        {
            _context = context;
        }

        // GET: Admin/InventoryItemPhoto
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventoryItemPhotos.ToListAsync());
        }

        // GET: Admin/InventoryItemPhoto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItemPhoto = await _context.InventoryItemPhotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItemPhoto == null)
            {
                return NotFound();
            }

            return View(inventoryItemPhoto);
        }

        // GET: Admin/InventoryItemPhoto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/InventoryItemPhoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Url,Caption")] InventoryItemPhoto inventoryItemPhoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryItemPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryItemPhoto);
        }

        // GET: Admin/InventoryItemPhoto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItemPhoto = await _context.InventoryItemPhotos.FindAsync(id);
            if (inventoryItemPhoto == null)
            {
                return NotFound();
            }
            return View(inventoryItemPhoto);
        }

        // POST: Admin/InventoryItemPhoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,Caption")] InventoryItemPhoto inventoryItemPhoto)
        {
            if (id != inventoryItemPhoto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryItemPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryItemPhotoExists(inventoryItemPhoto.Id))
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
            return View(inventoryItemPhoto);
        }

        // GET: Admin/InventoryItemPhoto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItemPhoto = await _context.InventoryItemPhotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItemPhoto == null)
            {
                return NotFound();
            }

            return View(inventoryItemPhoto);
        }

        // POST: Admin/InventoryItemPhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryItemPhoto = await _context.InventoryItemPhotos.FindAsync(id);
            _context.InventoryItemPhotos.Remove(inventoryItemPhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryItemPhotoExists(int id)
        {
            return _context.InventoryItemPhotos.Any(e => e.Id == id);
        }
    }
}
