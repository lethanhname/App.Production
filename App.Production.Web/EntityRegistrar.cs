using Microsoft.EntityFrameworkCore;
using App.CoreLib.EF.Data;
using App.Production.Business;

namespace App.Production.Web
{
  public class EntityRegistrar : IEntityRegistrar
  {
    public void RegisterEntities(ModelBuilder modelBuilder) => EntityService.RegisterEntities(modelBuilder);
  }
}