using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Helpers
{
    interface IDBOperations
    {
        DataSet GetRecord_AS_DataSet(string query);
        DataTable GetRecord_AS_DataTable(string query);
        string Execute_Query(string query);
        string Update_Query(string query);
    }
}
