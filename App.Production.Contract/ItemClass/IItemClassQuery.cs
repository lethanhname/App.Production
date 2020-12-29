


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IItemClassQuery : IQueryBase<ItemClass>
  {
  
  }
  public class ItemClassQueryRequest : QueryRequestBase
  {
    public bool ActiveOnly { get; set; }
  }
}