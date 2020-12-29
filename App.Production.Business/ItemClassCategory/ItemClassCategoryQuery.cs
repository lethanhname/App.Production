


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

  public class ItemClassCategoryQuery : QueryBase<ItemClassCategory>, IItemClassCategoryQuery
  {
    public ItemClassCategoryQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      if (string.IsNullOrEmpty(request.OrderColumn))
      {
        request.OrderColumn = "ItemClassCode";
        request.SortDirection = "asc";
      }
    }


    protected override IQueryable<ItemClassCategory> Define(IQueryRequest request)
    {

      var tbItemClassCategory = storageContext.Set<ItemClassCategory>().AsNoTracking();
      var tbItemCategory = storageContext.Set<ItemCategory>().AsNoTracking();
      var query = tbItemClassCategory.GroupJoin(tbItemCategory, l => l.ItemCategoryCode, r => r.Code, (l, r) => new { classCate = l, cates = r })
      .SelectMany(r => r.cates.DefaultIfEmpty(), (l, r) => new ItemClassCategory
      {
        ItemClassCode = l.classCate.ItemClassCode,
        ItemCategoryCode = l.classCate.ItemCategoryCode,
        ItemCategoryCodeDesc = r.Description,
      });
      var internalRequest = request as ItemClassCategoryQueryRequest;
      if (internalRequest != null)
      {
        query = query.Where(r => r.ItemClassCode == internalRequest.ItemClassCode);
      }
      query = query.Where(r => r.ItemCategoryCode.Contains(request.SearchValue));
      return query;
    }
  }
}