


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IItemCategoryAttributeValueQuery : IQueryBase<ItemCategoryAttributeValue>
    {

    }

    public class ItemCategoryAttributeValueQueryRequest : QueryRequestBase
    {
        public string ItemAttributeCode { get; set; }
        public bool ActiveOnly { get; set; }
    }
}