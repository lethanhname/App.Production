using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class ItemClassCategory : EntityBase
    {
        [Required]
        [Display(Name = "ItemClassCode")]
        [StringLength(20)]
        public string ItemClassCode { get; set; }
		
        [Required]
        [Display(Name = "ItemCategoryCode")]
        [StringLength(20)]
        public string ItemCategoryCode { get; set; }
		
        #region Calculated fields
        [NotMapped]
        public string ItemCategoryCodeDesc { get; set; }
        #endregion
    }
}