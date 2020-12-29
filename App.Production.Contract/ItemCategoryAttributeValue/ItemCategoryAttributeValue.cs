
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{

    public class ItemCategoryAttributeValue : EntityBase
    {
        [Required]
        [Display(Name = "ItemAttributeCode")]
        [StringLength(20)]
        public string ItemAttributeCode { get; set; }

        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        #region Calculated fields
        [NotMapped]
        public string ItemAttributeCodeDesc { get; set; }

        #endregion
    }
}