using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class DepartmentDataAccess
    {
        private SqlConnection _conn;

        public DepartmentDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCompany"].ConnectionString);
        }

        public DataTable GetDepartmentInformation()
        {
            _conn.Open();

            string sqlQuery = "SELECT [CompanyId], [OfficeLocationCode], [DepartmentCode], [DepartmentName], [DepartmentLocation], [HeadOfDepartment], [SubHeadOfDepartment] FROM [dbo].[Hrms_Department_Master]";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            _conn.Close();

            return dataTable;
        }
    }
}