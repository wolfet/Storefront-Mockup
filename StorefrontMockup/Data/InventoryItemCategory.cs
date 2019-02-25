using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorefrontMockup.Data
{
    public class InventoryItemCategory
    {
        public InventoryItemCategory()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }

        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        public ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
