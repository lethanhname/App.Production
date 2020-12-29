using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    
    public class ItemCategoryAttribute : EntityBase
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

        [Display(Name = "Has Description")]
        public bool HasDescription { get; set; }

        [Display(Name = "Required")]
        public bool IsRequired { get; set; }
		
        [Required]
        [Display(Name = "DataType")]
        [StringLength(20)]
        public string DataType { get; set; }

        #region Calculated fields
        [NotMapped]
        public string ItemCategoryCodeDesc { get; set; }

        #endregion
    }
}