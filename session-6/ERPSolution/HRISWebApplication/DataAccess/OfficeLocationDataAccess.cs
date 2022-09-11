using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class OfficeLocationDataAccess
    {

        private SqlConnection _conn;

        public OfficeLocationDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCompany"].ConnectionString);
        }

    }
}