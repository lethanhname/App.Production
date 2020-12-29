using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class InventorySubItem : EntityBase
    {
        [Required]
        [Display(Name = "InventoryCode")]
        [StringLength(20)]
        public string InventoryCode { get; set; }

        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "ColorCode")]
        [StringLength(20)]
        public string ColorCode { get; set; }

        [Required]
        [Display(Name = "SizeCode")]
        [StringLength(20)]
        public string SizeCode { get; set; }

        [Required]
        [Display(Name = "SerialNo")]
        [StringLength(20)]
        public string SerialNo { get; set; }

        #region Calculated fields
        
        [NotMapped]
        public string ColorCodeDesc { get; set; }
        [NotMapped]
        public string SizeCodeDesc { get; set; }

        #endregion

    }
}