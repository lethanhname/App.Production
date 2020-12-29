


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface ITechpackLineQuery : IQueryBase<TechpackLine>
    {

    }

    public class TechpackLineQueryRequest : QueryRequestBase
    {
        public string Code { get; set; }

        public int RevNo { get; set; }

    }
}