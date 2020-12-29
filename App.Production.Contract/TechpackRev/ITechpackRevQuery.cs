


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface ITechpackRevQuery : IQueryBase<TechpackRev>
    {

    }

    public class TechpackRevQueryRequest : QueryRequestBase
    {
        public bool ActiveOnly { get; set; }
    }
}