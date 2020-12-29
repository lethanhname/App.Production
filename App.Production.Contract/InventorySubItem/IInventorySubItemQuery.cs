


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IInventorySubItemQuery : IQueryBase<InventorySubItem>
    {

    }
    public class InventorySubItemQueryRequest : QueryRequestBase
    {
        public string InventoryCode { get; set; }
    }
}