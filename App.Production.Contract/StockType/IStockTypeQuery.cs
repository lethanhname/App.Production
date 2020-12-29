


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IStockTypeQuery : IQueryBase<StockType>
  {
  
  }

   public class StockTypeQueryRequest : QueryRequestBase
  {
    public string StockGroupCode { get; set; }
    public bool ActiveOnly { get; set; }
  }
}