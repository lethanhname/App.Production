
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class ItemSize : EntityBase
    {
        [Required]
        [Display(Name = "SizeCode")]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "WaistCode")]
        [StringLength(20)]
        public string WaistCode { get; set; }

        [Required]
        [Display(Name = "InseamCode")]
        [StringLength(20)]
        public string InseamCode { get; set; }

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

        #region Calculated fields
        [NotMapped]
        public string ItemCategoryCodeDesc { get; set; }
        [NotMapped]
        public string InseamCodeDesc { get; set; }
        [NotMapped]
        public string WaistCodeDesc { get; set; }

        #endregion

    }
}