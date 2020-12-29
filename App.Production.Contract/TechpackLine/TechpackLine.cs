
using System.ComponentModel.DataAnnotations;
using System;
using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Production.Contract
{
    public class TechpackLine : EntityBase
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(20)]
        public string Code { get; set; }


        [Display(Name = "RevNo")]
        public int RevNo { get; set; }


        [Display(Name = "LineNbr")]
        public int LineNbr { get; set; }

        [Display(Name = "StockHoldCompany")]
        [StringLength(20)]
        public string StockHoldCompanyCode { get; set; }

        [Required]
        [Display(Name = "InventoryCode")]
        [StringLength(20)]
        public string InventoryCode { get; set; }

        [Required]
        [Display(Name = "ItemCategory")]
        [StringLength(20)]
        public string ItemCategoryCode { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }

        [Display(Name = "SubItemCode")]
        [StringLength(20)]
        public string SubItemCode { get; set; }

        [Required]
        [Display(Name = "ColorCode")]
        [StringLength(20)]
        public string ColorCode { get; set; }

        [Required]
        [Display(Name = "SizeCode")]
        [StringLength(20)]
        public string SizeCode { get; set; }

        [Required]
        [Display(Name = "VendorCode")]
        [StringLength(20)]
        public string VendorCode { get; set; }


        [Required]
        [Display(Name = "BaseUOM")]
        [StringLength(20)]
        public string BaseUOM { get; set; }


        [Required]
        [Display(Name = "DimSize")]
        [StringLength(20)]
        public string DimSize { get; set; }


        [Required]
        [Display(Name = "GMTSizeGroup")]
        [StringLength(20)]
        public string GMTSizeGroup { get; set; }

        [Display(Name = "AutoBreak")]
        public bool AutoBreak { get; set; }

        [Display(Name = "PerUnitPrice")]
        public decimal PerUnitPrice { get; set; }

        
        [Required]
        [Display(Name = "ConsumptionUOM")]
        [StringLength(20)]
        public string ConsumptionUOM { get; set; }

        [Display(Name = "StandardCons")]
        public decimal StandardCons { get; set; }

        [Display(Name = "Cons_Production")]
        public decimal Cons_Production { get; set; }

        [Display(Name = "Cons_Costing")]
        public decimal Cons_Costing { get; set; }


        [Display(Name = "Cons_Booking")]
        public decimal Cons_Booking { get; set; }



        [Display(Name = "OrderingCons")]
        public decimal OrderingCons { get; set; }




        [Display(Name = "NoCostBlock")]
        public decimal NoCostBlock { get; set; }


        

        [Display(Name = "Scrap")]
        public int Scrap { get; set; }

        
        [Display(Name = "SubItem_BPOColor")]
        public bool SubItem_BPOColor { get; set; }

        
        [Display(Name = "SubItem_GMTLength")]
        public bool SubItem_GMTLength { get; set; }
 
        [Display(Name = "SubItem_GMTWaist")]
        public bool SubItem_GMTWaist { get; set; }



        [Display(Name = "SubItem_GMTSize")]
        public bool SubItem_GMTSize { get; set; }


        [Display(Name = "SubITem_BPONo")]
        public bool SubITem_BPONo { get; set; }


        
        [Required]
        [Display(Name = "Status")]
        [StringLength(20)]
        public string Status { get; set; }
   
        [Required]
        [Display(Name = "Notes")]
        [StringLength(200)]
        public string Notes { get; set; }

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