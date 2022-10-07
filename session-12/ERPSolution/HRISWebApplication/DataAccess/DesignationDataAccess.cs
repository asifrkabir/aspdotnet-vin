using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class DesignationDataAccess
    {
        private SqlConnection _conn;

        public DesignationDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCompany"].ConnectionString);
        }

        public void Save(List<string> designationInfo)
        {
            _conn.Open();

            var sqlQuery = $"INSERT INTO [dbo].[Hrms_Designation_Master] ([CompanyId], [OfficeLocationCode], [DepartmentCode], [SectionCode], [DesignationCode], [DesignationName]) VALUES ('{designationInfo[0]}', '{designationInfo[1]}', '{designationInfo[2]}', '{designationInfo[3]}', '{designationInfo[4]}', '{designationInfo[5]}')";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }

        public DataTable GetDesignationInformation()
        {
            _conn.Open();

            string sqlQuery = "SELECT [CompanyId], [OfficeLocationCode], [DepartmentCode], [SectionCode], [DesignationCode], [DesignationName] FROM [dbo].[Hrms_Designation_Master]";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            _conn.Close();

            return dataTable;
        }

        public void DeleteRow(string designationCode)
        {
            _conn.Open();

            var sqlQuery = $"DELETE FROM [dbo].[Hrms_Designation_Master] WHERE DesignationCode='{designationCode}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}