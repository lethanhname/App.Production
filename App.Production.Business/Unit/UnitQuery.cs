


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

  public class UnitQuery : QueryBase<Unit>, IUnitQuery
  {
    public UnitQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      request.OrderColumn = "Code";
      request.SortDirection = "asc";
    }

    protected override IQueryable<Unit> Define(IQueryRequest request)
    {
      var query = storageContext.Set<Unit>().AsNoTracking();

      var internalRequest = request as UnitQueryRequest;
      if (internalRequest != null)
      {
        if (internalRequest.ActiveOnly)
          query = query.Where(r => r.IsActive);
      }
      query = query.Where(r => r.Description.Contains(request.SearchValue));
      return query;
    }
  }
}