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

  public class ItemCategoryAttributeValueQuery : QueryBase<ItemCategoryAttributeValue>, IItemCategoryAttributeValueQuery
  {
    public ItemCategoryAttributeValueQuery(IStorage context) : base(context)
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

    protected override IQueryable<ItemCategoryAttributeValue> Define(IQueryRequest request)
    {

      var tbItemCategoryAttributeValue = storageContext.Set<ItemCategoryAttributeValue>().AsNoTracking();
      var tbItemCategoryAttribute = storageContext.Set<ItemCategoryAttribute>().AsNoTracking();
      var query = tbItemCategoryAttributeValue.GroupJoin(tbItemCategoryAttribute, t => t.ItemAttributeCode, g => g.Code, (t, g) => new { t, g })
      .SelectMany(p => p.g.DefaultIfEmpty(), (p, g) => new ItemCategoryAttributeValue
      {
        Code = p.t.Code,
        Description = p.t.Description,
        IsActive = p.t.IsActive,
        ItemAttributeCode = p.t.ItemAttributeCode,
        ItemAttributeCodeDesc = g.Description
      });

      var internalRequest = request as ItemCategoryAttributeValueQueryRequest;
      if (internalRequest != null)
      {
        if (internalRequest.ActiveOnly)
          query = query.Where(r => r.IsActive);
        if (!string.IsNullOrEmpty(internalRequest.ItemAttributeCode))
          query = query.Where(r => r.ItemAttributeCode == internalRequest.ItemAttributeCode);
      }
      query = query.Where(r => r.Description.Contains(request.SearchValue) || r.ItemAttributeCodeDesc.Contains(request.SearchValue));
      return query;
    }
  }
}