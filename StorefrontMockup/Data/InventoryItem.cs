using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StorefrontMockup.Data
{
    public class InventoryItem
    {
        public InventoryItem()
        {
            Photos = new HashSet<InventoryItemPhoto>();
        }

        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string DisplayPrice => string.Format("{0:C}", Price);

        [Display(Name = "Primary Photo")]
        [ForeignKey(nameof(PrimaryPhoto))]
        public int? PrimaryPhotoId { get; set; }

        [Display(Name="Unit Of Measure")]
        [ForeignKey(nameof(UnitOfMeasure))]
        public int? UnitOfMeasureId { get; set; }

        [Display(Name = "Item Category")]
        [ForeignKey(nameof(InventoryItemCategory))]
        public int? InventoryItemCategoryId { get; set; }

        public InventoryItemPhoto PrimaryPhoto { get; set; }
        
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public InventoryItemCategory InventoryItemCategory { get; set; }

        public ICollection<InventoryItemPhoto> Photos { get; set; }
    }
}
