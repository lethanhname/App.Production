using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Production.Web;
using App.CoreLib.EF.Data;
using App.Production.Contract;
using App.CoreLib.EF.Messages;
using System.Collections.Generic;
using App.Production.Web.Common;
using App.Core.Web.AppControllers;

namespace App.Production.Web.Areas.Production.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Area(Constants.AreaName)]
  public class StockTypeApiController : ApiControllerBase
  {
    readonly ILogger<StockTypeApiController> _log;
    readonly IRepository<StockType> _StockTypeRepos;
    readonly IStockTypeQuery _StockTypeQuery;

    public StockTypeApiController(ILogger<StockTypeApiController> log, IRepository<StockType> StockTypeRepos, IStockTypeQuery StockTypeQuery)
    {
      _log = log;
      _StockTypeRepos = StockTypeRepos;
      _StockTypeQuery = StockTypeQuery;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] StockTypeQueryRequest request)
    {
      var gridData = await this._StockTypeQuery.ReadDataAsync(request);
      return Ok(gridData);
    }

    [HttpPost("Update")]
    [AllowAnonymous]
    public async Task<IActionResult> Update([FromBody] StockType entity)
    {
      EntityResult result = GetModelErrors();
      if (result.Succeeded)
      {
        if (entity.RowVersion == 0)
        {
          _StockTypeRepos.Add(entity);
          result = await _StockTypeRepos.SaveChangesAsync();
        }
        else
        {
          _StockTypeRepos.Edit(entity);

        }
        result = await _StockTypeRepos.SaveChangesAsync();
      }
      return new JsonResult(result);
    }

    [HttpPost("Delete")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete([FromBody] string code)
    {
      EntityResult result = GetModelErrors();
      if (result.Succeeded)
      {
          _StockTypeRepos.Remove(code);
          result = await _StockTypeRepos.SaveChangesAsync();
      }
      return new JsonResult(result);
    }
  }
}