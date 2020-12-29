using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class ItemClass : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }
		
        [Display(Name = "PrefixCode")]
        [StringLength(20)]
        public string PrefixCode { get; set; }
		
        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }
		
        [Required]
        [Display(Name = "Stock Type")]
        [StringLength(20)]
        public string StockTypeCode { get; set; }
		
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}