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

  public class InventorySubItemQuery : QueryBase<InventorySubItem>, IInventorySubItemQuery
  {
    public InventorySubItemQuery(IStorage context) : base(context)
    {
    }

    protected override void DefaultSort(IQueryRequest request)
    {
      if (string.IsNullOrEmpty(request.OrderColumn))
      {
        request.OrderColumn = "InventoryCode";
        request.SortDirection = "asc";
      }
    }

    protected override IQueryable<InventorySubItem> Define(IQueryRequest request)
    {

      var tbInventorySubItem = storageContext.Set<InventorySubItem>().AsNoTracking();
      var tbItemColor = storageContext.Set<ItemColor>().AsNoTracking();
      var tbItemSize = storageContext.Set<ItemSize>().AsNoTracking();
      var query = tbInventorySubItem.GroupJoin(tbItemColor, l => l.ColorCode, r => r.Code, (l, r) => new { sub = l, colors = r })
          .SelectMany(r => r.colors.DefaultIfEmpty(), (l, r) => new { sub = l.sub, color = r })

      .GroupJoin(tbItemSize, l => l.sub.SizeCode, r => r.Code, (l, r) => new { sub = l.sub, color = l.color, sizes = r })
      .SelectMany(r => r.sizes.DefaultIfEmpty(), (l, r) => new InventorySubItem
      {
        Code = l.sub.Code,
        InventoryCode = l.sub.InventoryCode,
        ColorCode = l.sub.ColorCode,
        ColorCodeDesc = l.color.Description,
        SizeCode = l.sub.SizeCode,
        SizeCodeDesc = r.Description,
        SerialNo = l.sub.SerialNo,
      });
      var internalRequest = request as InventorySubItemQueryRequest;
      if (internalRequest != null)
      {
        query = query.Where(r => r.InventoryCode == internalRequest.InventoryCode);
      }
      query = query.Where(r => r.ColorCode.Contains(request.SearchValue));
      return query;
    }
  }
}