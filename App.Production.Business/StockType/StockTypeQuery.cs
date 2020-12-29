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

  public class StockTypeQuery : QueryBase<StockType>, IStockTypeQuery
  {
    public StockTypeQuery(IStorage context) : base(context)
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

    protected override IQueryable<StockType> Define(IQueryRequest request)
    {

      var tbStockType = storageContext.Set<StockType>().AsNoTracking();
      var tbStockGroup = storageContext.Set<StockGroup>().AsNoTracking();
      var query = tbStockType.GroupJoin(tbStockGroup, t => t.StockGroupCode, g => g.Code, (t, g) => new { t, g })
      .SelectMany(p => p.g.DefaultIfEmpty(), (p, g) => new StockType
      {
        Code = p.t.Code,
        Description = p.t.Description,
        IsActive = p.t.IsActive,
        IsBOMTemplate = p.t.IsBOMTemplate,
        StockGroupCode = p.t.StockGroupCode,
        StockGroupCodeDesc = g.Description,
        RowVersion = p.t.RowVersion
      });

      var internalRequest = request as StockTypeQueryRequest;
      if (internalRequest != null)
      {
        if (internalRequest.ActiveOnly)
          query = query.Where(r => r.IsActive);
        if (!string.IsNullOrEmpty(internalRequest.StockGroupCode))
          query = query.Where(r => r.StockGroupCode == internalRequest.StockGroupCode);
      }
      if(!string.IsNullOrWhiteSpace(request.SearchValue))
        query = query.Where(r => r.Code.Contains(request.SearchValue) || r.Description.Contains(request.SearchValue) || r.StockGroupCodeDesc.Contains(request.SearchValue));
      return query;
    }
  }
}