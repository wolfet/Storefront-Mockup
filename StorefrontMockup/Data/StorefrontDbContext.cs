using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StorefrontMockup.Data;

namespace StorefrontMockup.Data
{
    public class StorefrontDbContext : IdentityDbContext
    {
        public StorefrontDbContext(DbContextOptions<StorefrontDbContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryItemCategory> InventoryItemCategories { get; set; }
        public DbSet<InventoryItemPhoto> InventoryItemPhotos { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }
    }
}
