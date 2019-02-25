using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorefrontMockup.Data;
using StorefrontMockup.Models;

namespace StorefrontMockup.Controllers
{
    public class HomeController : Controller
    {
        private readonly StorefrontDbContext _context;

        public HomeController(StorefrontDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new StoreFrontHomeViewModel();

            model.InventoryItems = await
                _context.InventoryItems
                    .Include(x => x.InventoryItemCategory)
                    .Include(x => x.PrimaryPhoto)
                    .AsNoTracking()
                    .OrderBy(x => x.Name)
                    .ToListAsync();

            return View(model);
        }

        // GET: /Home/Product/Id
        public async Task<IActionResult> Product(int Id)
        {
            var model = new StoreFrontDetailViewModel();

            model.InventoryItem = await
                _context.InventoryItems
                    .Include(x => x.InventoryItemCategory)
                    .Include(x => x.PrimaryPhoto)
                    .Include(x => x.Photos)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == Id);

            if (model.InventoryItem != null)
            {
                model.RelatedItems = await
                    _context.InventoryItems
                        .Include(x => x.PrimaryPhoto)
                        .Where(x => 
                            x.InventoryItemCategoryId == model.InventoryItem.InventoryItemCategoryId
                            && x.Id != Id
                        )
                        .AsNoTracking()
                        .OrderBy(x => x.Name)
                        .Take(3)
                        .ToListAsync();
            }  

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
