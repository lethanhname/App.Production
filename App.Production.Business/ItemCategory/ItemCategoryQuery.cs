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

  public class ItemCategoryQuery : QueryBase<ItemCategory>, IItemCategoryQuery
  {
    public ItemCategoryQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      request.OrderColumn = "Code";
      request.SortDirection = "asc";
    }

    protected override IQueryable<ItemCategory> Define(IQueryRequest request)
    {
      var dbset = storageContext.Set<ItemCategory>().AsNoTracking();

      var groupRequest = request as ItemCategoryQueryRequest;
      if (groupRequest != null && groupRequest.ActiveOnly)
      {
        return dbset.Where(r => r.IsActive && r.Description.Contains(request.SearchValue));
      }

      return dbset.Where(r => r.Description.Contains(request.SearchValue));
    }
  }
}