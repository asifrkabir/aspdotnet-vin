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

        public void Save(List<string> departmentInfo)
        {
            _conn.Open();

            var sqlQuery = $"INSERT INTO [dbo].[Hrms_Department_Master] ([CompanyId], [OfficeLocationCode], [DepartmentCode], [DepartmentName], [DepartmentLocation], [HeadOfDepartment], [SubHeadOfDepartment]) VALUES ('{departmentInfo[0]}', '{departmentInfo[1]}', '{departmentInfo[2]}', '{departmentInfo[3]}', '{departmentInfo[4]}', '{departmentInfo[5]}', '{departmentInfo[6]}')";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
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

        public void DeleteRow(string departmentCode)
        {
            _conn.Open();

            var sqlQuery = $"DELETE FROM [dbo].[Hrms_Department_Master] WHERE DepartmentCode='{departmentCode}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}