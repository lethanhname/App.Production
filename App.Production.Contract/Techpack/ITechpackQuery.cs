


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface ITechpackQuery : IQueryBase<Techpack>
    {

    }

    public class TechpackQueryRequest : QueryRequestBase
    {
        public bool ActiveOnly { get; set; }
    }
}