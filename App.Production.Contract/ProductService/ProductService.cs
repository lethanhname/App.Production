using System;
using System.ComponentModel.DataAnnotations;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class ProductService : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }
		
        [Required]
        [Display(Name = "ItemCategoryCode")]
        [StringLength(20)]
        public string ItemCategoryCode { get; set; }
		
        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }
		
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}