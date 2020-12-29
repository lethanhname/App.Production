
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class StockType : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "StockGroupCode")]
        [StringLength(20)]
        public string StockGroupCode { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "IsBOMTemplate")]
        public bool IsBOMTemplate { get; set; }

        #region Calculated fields
        [NotMapped]
        public string StockGroupCodeDesc { get; set; }

        #endregion
    }
}