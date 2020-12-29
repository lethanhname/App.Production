


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IItemSizeQuery : IQueryBase<ItemSize>
    {

    }

    public class ItemSizeQueryRequest : QueryRequestBase
    {
        public string ItemCategoryCode { get; set; }
        public bool ActiveOnly { get; set; }
    }
}