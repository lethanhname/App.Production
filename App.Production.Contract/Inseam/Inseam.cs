
using System;
using System.ComponentModel.DataAnnotations;
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public class Inseam : EntityBase
    {
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

        // [Display(Name = "CreatedBy")]
        // public string CreatedBy { get; set; }
        // [Display(Name = "ModifiedBy")]
        // public string ModifiedBy { get; set; }
        // [Display(Name = "CreatedDate")]
        // public DateTime CreatedDate { get; set; }
        // [Display(Name = "ModifiedDate")]
        // public DateTime ModifiedDate { get; set; }
    }
}