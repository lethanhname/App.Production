


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IStockGroupQuery : IQueryBase<StockGroup>
  {
  
  }

  public class StockGroupQueryRequest : QueryRequestBase
  {
    public bool ActiveOnly { get; set; }
  }
}