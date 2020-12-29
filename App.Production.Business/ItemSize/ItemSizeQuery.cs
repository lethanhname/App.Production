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

  public class ItemSizeQuery : QueryBase<ItemSize>, IItemSizeQuery
  {
    public ItemSizeQuery(IStorage context) : base(context)
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

    protected override IQueryable<ItemSize> Define(IQueryRequest request)
    {
      var tbItemSize = storageContext.Set<ItemSize>().AsNoTracking();
      var tbItemCategory = storageContext.Set<ItemCategory>().AsNoTracking();
      var query = tbItemSize.GroupJoin(tbItemCategory, t => t.ItemCategoryCode, g => g.Code, (t, g) => new { t, g })
      .SelectMany(p => p.g.DefaultIfEmpty(), (p, g) => new ItemSize
      {
        Code = p.t.Code,
        Description = p.t.Description,
        IsActive = p.t.IsActive,
        InseamCode = p.t.InseamCode,
        WaistCode = p.t.WaistCode,
        ItemCategoryCode = p.t.ItemCategoryCode,
        ItemCategoryCodeDesc = g.Description
      });

      var internalRequest = request as ItemSizeQueryRequest;
      if (internalRequest != null)
      {
        if (internalRequest.ActiveOnly)
          query = query.Where(r => r.IsActive);
        if (!string.IsNullOrEmpty(internalRequest.ItemCategoryCode))
          query = query.Where(r => r.ItemCategoryCode == internalRequest.ItemCategoryCode);
      }
      query = query.Where(r => r.Description.Contains(request.SearchValue) || r.ItemCategoryCodeDesc.Contains(request.SearchValue));
      return query;
    }
  }
}