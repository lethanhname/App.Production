


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF;
using App.CoreLib.EF.Data;
using App.CoreLib.EF.Data.Repositories;
using App.Production.Contract;
using System.Linq.Expressions;

namespace App.Production.Business
{

  public class ProductServiceQuery : QueryBase<ProductService>, IProductServiceQuery
  {
    public ProductServiceQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      if (string.IsNullOrEmpty(request.OrderColumn))
      {
        request.OrderColumn = "Code";
        request.SortDirection = "asc";
      }
    }

    protected override IQueryable<ProductService> Define(IQueryRequest request)
    {
      var dbset = storageContext.Set<ProductService>().AsNoTracking();

      var groupRequest = request as ProductServiceQueryRequest;
      if (groupRequest != null && groupRequest.ActiveOnly)
      {
        return dbset.Where(r => r.IsActive && r.Description.Contains(request.SearchValue));
      }

      return dbset.Where(r => r.Description.Contains(request.SearchValue));
    }
  }
}