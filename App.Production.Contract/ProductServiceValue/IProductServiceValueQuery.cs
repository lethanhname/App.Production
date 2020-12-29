


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IProductServiceValueQuery : IQueryBase<ProductServiceValue>
  {
  
  }

   public class ProductServiceValueQueryRequest : QueryRequestBase
  {
    public bool ActiveOnly { get; set; }
  }
}