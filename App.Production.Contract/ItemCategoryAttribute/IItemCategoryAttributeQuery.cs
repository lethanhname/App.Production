


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IItemCategoryAttributeQuery : IQueryBase<ItemCategoryAttribute>
    {

    }

    public class ItemCategoryAttributeQueryRequest : QueryRequestBase
    {
        public string ItemCategoryCode { get; set; }
        public bool ActiveOnly { get; set; }
    }
}