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

  public class ItemCategoryAttributeQuery : QueryBase<ItemCategoryAttribute>, IItemCategoryAttributeQuery
  {
    public ItemCategoryAttributeQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      request.OrderColumn = "Code";
      request.SortDirection = "asc";
    }

    protected override IQueryable<ItemCategoryAttribute> Define(IQueryRequest request)
    {

      var tbItemCategoryAttribute = storageContext.Set<ItemCategoryAttribute>().AsNoTracking();
      var tbItemCategory = storageContext.Set<ItemCategory>().AsNoTracking();
      var query = tbItemCategoryAttribute.GroupJoin(tbItemCategory, t => t.ItemCategoryCode, g => g.Code, (t, g) => new { t, g })
      .SelectMany(p => p.g.DefaultIfEmpty(), (p, g) => new ItemCategoryAttribute
      {
        Code = p.t.Code,
        Description = p.t.Description,
        IsActive = p.t.IsActive,
        IsRequired = p.t.IsRequired,
        HasDescription = p.t.HasDescription,
        DataType = p.t.DataType,
        ItemCategoryCode = p.t.ItemCategoryCode,
        ItemCategoryCodeDesc = g.Description
      });

      var internalRequest = request as ItemCategoryAttributeQueryRequest;
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