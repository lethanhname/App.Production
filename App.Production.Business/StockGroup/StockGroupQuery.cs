


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

  public class StockGroupQuery : QueryBase<StockGroup>, IStockGroupQuery
  {
    public StockGroupQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      request.OrderColumn = "Code";
      request.SortDirection = "asc";
    }

    protected override IQueryable<StockGroup> Define(IQueryRequest request)
    {
      var dbset = storageContext.Set<StockGroup>().AsNoTracking();

      var groupRequest = request as StockGroupQueryRequest;
      if (groupRequest != null && groupRequest.ActiveOnly)
      {
        dbset = dbset.Where(r => r.IsActive);
      }
      if(!string.IsNullOrWhiteSpace(request.SearchValue))
        dbset = dbset.Where(r => r.Code.Contains(request.SearchValue) || r.Description.Contains(request.SearchValue));
        
      return dbset;
    }
  }
}