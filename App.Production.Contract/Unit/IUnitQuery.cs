


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IUnitQuery : IQueryBase<Unit>
    {

    }
    public class UnitQueryRequest : QueryRequestBase
    {
        public bool ActiveOnly { get; set; }
    }
}