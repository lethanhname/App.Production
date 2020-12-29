
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class Techpack : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "TypeofTechPack")]
        [StringLength(20)]
        public string TypeofTechPack { get; set; }

        [Required]
        [Display(Name = "ProductType")]
        [StringLength(20)]
        public string ProductType { get; set; }

        [Display(Name = "Customer")]
        [StringLength(20)]
        public string CustomerCode { get; set; }

        [Required]
        [Display(Name = "SeasonCode")]
        [StringLength(20)]
        public string SeasonCode { get; set; }

        [Required]
        [Display(Name = "StyleCode")]
        [StringLength(20)]
        public string StyleCode { get; set; }

        [Required]
        [Display(Name = "FabricCode")]
        [StringLength(20)]
        public string FabricCode { get; set; }

        [Required]
        [Display(Name = "WashCode")]
        [StringLength(20)]
        public string WashCode { get; set; }

        [Display(Name = "Embroidery")]
        public bool Embroidery { get; set; }

        [Display(Name = "Printing")]
        public bool Printing { get; set; }

        [Display(Name = "Embossing")]
        public bool Embossing { get; set; }

        [Display(Name = "SAM")]
        public decimal SAM { get; set; }

        [Display(Name = "ReceivedDate")]
        public DateTime ReceivedDate { get; set; }
        

        #region Calculated fields
        [NotMapped]
        public string CustomerCodeDesc { get; set; }
        [NotMapped]
        public string SeasonCodeDesc { get; set; }
        [NotMapped]
        public string StyleCodeDesc { get; set; }

        #endregion

    }
}