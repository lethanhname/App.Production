using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class InventoryItem : EntityBase
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
        [Display(Name = "AlternateCode")]
        [StringLength(20)]
        public string AlternateCode { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "BaseUnit")]
        [StringLength(20)]
        public string BaseUnit { get; set; }

        [Required]
        [Display(Name = "SaleUnit")]
        [StringLength(20)]
        public string SaleUnit { get; set; }

        [Required]
        [Display(Name = "PurchaseUnit")]
        [StringLength(20)]
        public string PurchaseUnit { get; set; }

        [Required]
        [Display(Name = "ItemClassCode")]
        [StringLength(20)]
        public string ItemClassCode { get; set; }

        [Required]
        [Display(Name = "ItemCategoryCode")]
        [StringLength(20)]
        public string ItemCategoryCode { get; set; }

        [Required]
        [Display(Name = "CustomCodeCode")]
        [StringLength(20)]
        public string CustomCodeCode { get; set; }

        [Required]
        [Display(Name = "HSCode")]
        [StringLength(20)]
        public string HSCode { get; set; }

        [Display(Name = "LotTracking")]
        public bool LotTracking { get; set; }

        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Required]
        [Display(Name = "WeightUnit")]
        [StringLength(20)]
        public string WeightUnit { get; set; }

        [Display(Name = "Volume")]
        public decimal Volume { get; set; }

        [Required]
        [Display(Name = "VolumeUnit")]
        [StringLength(20)]
        public string VolumeUnit { get; set; }

        #region Calculated fields
        [NotMapped]
        public string ItemClassCodeDesc { get; set; }

        [NotMapped]
        public string ItemCategoryCodeDesc { get; set; }

        [NotMapped]
        public string BaseUnitDesc { get; set; }

        [NotMapped]
        public string SaleUnitDesc { get; set; }

        [NotMapped]
        public string PurchaseUnitDesc { get; set; }
        [NotMapped]
        public string WeightUnitDesc { get; set; }

        [NotMapped]
        public string VolumeUnitDesc { get; set; }

        #endregion

    }
}