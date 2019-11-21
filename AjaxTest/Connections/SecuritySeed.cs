using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AjaxTest.Connections
{
    public class SecuritySeed : CreateDatabaseIfNotExists<SqlExpContext>
    {

    }
}