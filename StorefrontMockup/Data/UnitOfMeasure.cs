using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorefrontMockup.Data
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }

        [Display(Name = "Singular Name")]
        public string SingularName { get; set; }

        [Display(Name = "Plural Name")]
        public string PluralName { get; set; }
    }
}

