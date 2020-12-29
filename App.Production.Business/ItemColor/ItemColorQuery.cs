


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

  public class ItemColorQuery : QueryBase<ItemColor>, IItemColorQuery
  {
    public ItemColorQuery(IStorage context) : base(context)
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

    protected override IQueryable<ItemColor> Define(IQueryRequest request)
    {
      var query = storageContext.Set<ItemColor>().AsNoTracking();

      var internalRequest = request as ItemClassQueryRequest;
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