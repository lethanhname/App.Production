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

  public class InventoryItemQuery : QueryBase<InventoryItem>, IInventoryItemQuery
  {
    public InventoryItemQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      request.OrderColumn = "Code";
      request.SortDirection = "asc";
    }

    protected override IQueryable<InventoryItem> Define(IQueryRequest request)
    {
      var tbInventoryItem = storageContext.Set<InventoryItem>().AsNoTracking();
      var tbItemCategory = storageContext.Set<ItemCategory>().AsNoTracking();
      var tbItemClass = storageContext.Set<ItemClass>().AsNoTracking();
      var tbBaseUnit = storageContext.Set<Unit>().AsNoTracking();
      var query = tbInventoryItem.GroupJoin(tbItemCategory, l => l.ItemCategoryCode, r => r.Code, (l, r) => new { inv = l, cates = r })
      .SelectMany(r => r.cates.DefaultIfEmpty(), (l, r) => new { inv = l.inv, cate = r })

      .GroupJoin(tbBaseUnit, l => l.inv.BaseUnit, r => r.Code, (l, r) => new { inv = l.inv, cate = l.cate, baseunits = r })
      .SelectMany(r => r.baseunits.DefaultIfEmpty(), (l, r) => new { inv = l.inv, cate = l.cate, baseunit = r })

      .GroupJoin(tbItemClass, l => l.inv.ItemClassCode, r => r.Code, (l, r) => new { inv = l.inv, cate = l.cate, baseunit = l.baseunit, itemclasses = r })
      .SelectMany(r => r.itemclasses.DefaultIfEmpty(), (l, r) => new { inv = l.inv, cate = l.cate, baseunit = l.baseunit, itemclass = r })

      .GroupJoin(tbBaseUnit, l => l.inv.SaleUnit, r => r.Code, (l, r) => new { inv = l.inv, cate = l.cate, baseunit = l.baseunit, itemclass = l.itemclass, saleunits = r })
      .SelectMany(r => r.saleunits.DefaultIfEmpty(), (l, r) => new InventoryItem
      {
        Code = l.inv.Code,
        Description = l.inv.Description,
        IsActive = l.inv.IsActive,
        AlternateCode = l.inv.AlternateCode,
        BaseUnit = l.inv.BaseUnit,
        BaseUnitDesc = l.baseunit.Description,
        SaleUnit = l.inv.SaleUnit,
        SaleUnitDesc = r.Description,
        ItemCategoryCode = l.inv.ItemCategoryCode,
        ItemCategoryCodeDesc = l.cate.Description,
        ItemClassCode = l.inv.ItemClassCode,
        ItemClassCodeDesc = l.itemclass.Description
      });

      var internalRequest = request as InventoryItemQueryRequest;
      if (internalRequest != null)
      {
        if (internalRequest.ActiveOnly)
          query = query.Where(r => r.IsActive);
        if (!string.IsNullOrEmpty(internalRequest.ItemCategoryCode))
          query = query.Where(r => r.ItemCategoryCode == internalRequest.ItemCategoryCode);
      }
      query = query.Where(r => r.Description.Contains(request.SearchValue) ||
                          r.AlternateCode.Contains(request.SearchValue) ||
                          r.ItemCategoryCodeDesc.Contains(request.SearchValue) ||
                          r.ItemClassCodeDesc.Contains(request.SearchValue) ||
                          r.SaleUnitDesc.Contains(request.SearchValue) ||
                          r.BaseUnitDesc.Contains(request.SearchValue));
      return query;
    }
  }
}