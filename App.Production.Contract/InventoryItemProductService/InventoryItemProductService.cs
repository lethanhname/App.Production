
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class InventoryItemProductService : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string InventoryCode { get; set; }

        [Required]
        [Display(Name = "ProductServiceCode")]
        [StringLength(20)]
        public string ProductServiceCode { get; set; }

        [Required]
        [Display(Name = "ProductServiceValueCode")]
        [StringLength(20)]
        public string ProductServiceValueCode { get; set; }
		
        [Display(Name = "Availability")]
         public bool Availability { get; set; }
    }
}