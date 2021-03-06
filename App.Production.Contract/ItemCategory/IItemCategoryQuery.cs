﻿


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IItemCategoryQuery : IQueryBase<ItemCategory>
  {
  
  }

  public class ItemCategoryQueryRequest : QueryRequestBase
  {
    public bool ActiveOnly { get; set; }
  }
}