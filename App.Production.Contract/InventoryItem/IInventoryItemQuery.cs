


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IInventoryItemQuery : IQueryBase<InventoryItem>
    {

    }

    public class InventoryItemQueryRequest : QueryRequestBase
    {
        public string ItemCategoryCode { get; set; }
        public bool ActiveOnly { get; set; }
    }
}