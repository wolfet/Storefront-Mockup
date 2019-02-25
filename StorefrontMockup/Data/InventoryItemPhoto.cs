using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorefrontMockup.Data
{
    public class InventoryItemPhoto
    {
        public int Id { get; set; }

        [Display(Name = "Image Url")]
        [MaxLength(500)]
        public string Url { get; set; }

        [MaxLength(500)]
        public string Caption { get; set; }
    }
}
