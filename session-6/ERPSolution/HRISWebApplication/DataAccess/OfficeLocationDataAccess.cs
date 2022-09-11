using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public DataTable GetOfficeLocationInformation()
        {
            _conn.Open();

            string sqlQuery = "SELECT [CompanyId], [CompanyName], [Address1], [Address2], [Address3], [ContPer1], [ContPer2], [Phone1], [Fax1], [Email1], [Url1], [TIN], [RegNo], [VATNo], [Insurance1] FROM [dbo].[Hrms_Company_Master]";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            _conn.Close();

            return dataTable;
        }

    }
}