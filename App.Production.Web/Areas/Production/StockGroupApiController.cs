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
  public class StockGroupApiController : ApiControllerBase
  {
    readonly ILogger<StockGroupApiController> _log;
    readonly IRepository<StockGroup> _stockGroupRepos;
    readonly IStockGroupQuery _stockGroupQuery;

    public StockGroupApiController(ILogger<StockGroupApiController> log, IRepository<StockGroup> stockGroupRepos, IStockGroupQuery stockGroupQuery)
    {
      _log = log;
      _stockGroupRepos = stockGroupRepos;
      _stockGroupQuery = stockGroupQuery;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryRequestBase request)
    {
      var gridData = await this._stockGroupQuery.ReadDataAsync(request);
      return Ok(gridData);
    }

    [HttpPost("Update")]
    [AllowAnonymous]
    public async Task<IActionResult> Update([FromBody] StockGroup entity)
    {
      EntityResult result = GetModelErrors();
      if (result.Succeeded)
      {
        if (entity.RowVersion == 0)
        {
          _stockGroupRepos.Add(entity);
          result = await _stockGroupRepos.SaveChangesAsync();
        }
        else
        {
          _stockGroupRepos.Edit(entity);

        }
        result = await _stockGroupRepos.SaveChangesAsync();
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
          _stockGroupRepos.Remove(code);
          result = await _stockGroupRepos.SaveChangesAsync();
      }
      return new JsonResult(result);
    }
  }
}