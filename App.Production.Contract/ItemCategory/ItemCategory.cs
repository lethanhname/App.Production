
using System.ComponentModel.DataAnnotations;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class ItemCategory : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }
		
        [Required]
        [Display(Name = "StockTypeCode")]
        [StringLength(20)]
        public string StockTypeCode { get; set; }
		
        [Display(Name = "StockItem")]        
        public bool StockItem { get; set; }
		
        [Display(Name = "CapitalizationItem")]        
        public bool CapitalizationItem { get; set; }
				
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
		
        [Display(Name = "GMTSize")]        
        public bool IsGMTSize { get; set; }
    }
}