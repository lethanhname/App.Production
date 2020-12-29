


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IWaistQuery : IQueryBase<Waist>
    {

    }

    public class WaistQueryRequest : QueryRequestBase
    {
        public bool ActiveOnly { get; set; }
    }
}