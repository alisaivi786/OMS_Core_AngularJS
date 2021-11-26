using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMS.Models.Context;


namespace OMS.Models.Interface
{
    public interface IModules
    {
        IEnumerable<Modules> GelAllModules();
        IEnumerable<SubModules> GelAllSubModules();
        IEnumerable<Pages> GelAllPages();
    }
}
