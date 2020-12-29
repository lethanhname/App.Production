


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF;
using App.CoreLib.EF.Data;
using App.CoreLib.EF.Data.Repositories;
using App.Production.Contract;

namespace App.Production.Business
{

  public class InseamQuery : QueryBase<Inseam>, IInseamQuery
  {
    public InseamQuery(IStorage context) : base(context)
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

    protected override IQueryable<Inseam> Define(IQueryRequest request)
    {
      var query = storageContext.Set<Inseam>().AsNoTracking();
      var internalRequest = request as InseamQueryRequest;
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