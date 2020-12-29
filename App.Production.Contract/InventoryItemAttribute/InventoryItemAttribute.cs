
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class InventoryItemAttribute : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string InventoryCode { get; set; }

        [Required]
        [Display(Name = "ItemAttributeCode")]
        [StringLength(20)]
        public string ItemAttributeCode { get; set; }

        [Required]
        [Display(Name = "ItemAttributeValueCode")]
        [StringLength(20)]
        public string ItemAttributeValueCode { get; set; }
    }
}