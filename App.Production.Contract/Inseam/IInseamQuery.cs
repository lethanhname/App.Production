


using System.Collections.Generic;

using App.CoreLib.EF.Data; 
using App.CoreLib.EF.Data.Entity;

namespace App.Production.Contract
{
    public interface IInseamQuery : IQueryBase<Inseam>
    {

    }
    public class InseamQueryRequest : QueryRequestBase
    {
        public bool ActiveOnly { get; set; }
    }
}