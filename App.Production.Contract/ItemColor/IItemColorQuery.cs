


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IItemColorQuery : IQueryBase<ItemColor>
  {
  
  }
    public class ItemColorQueryRequest : QueryRequestBase
  {
    public bool ActiveOnly { get; set; }
  }
}