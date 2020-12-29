
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class TechpackRev : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Display(Name = "RevNo")]
        public int RevNo { get; set; }

        [Required]
        [Display(Name = "RevNote")]
        [StringLength(200)]
        public string RevNote { get; set; }

        [Display(Name = "IsPosted")]
        public bool IsPosted { get; set; }

        [Display(Name = "PostedID")]
        [StringLength(20)]
        public string PostedID { get; set; }

        [Display(Name = "PostedDate")]
        public DateTime PostedDate { get; set; }
        

        #region Calculated fields

        #endregion

    }
}