


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{  
  public interface IProductServiceQuery : IQueryBase<ProductService>
  {
  
  }

   public class ProductServiceQueryRequest : QueryRequestBase
  {
    public bool ActiveOnly { get; set; }
  }
}