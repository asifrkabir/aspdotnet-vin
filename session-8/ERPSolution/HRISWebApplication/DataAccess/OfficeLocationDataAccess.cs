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

        public void Save(List<string> officeLocationInfo)
        {
            _conn.Open();

            var sqlQuery = $"INSERT INTO [dbo].[Hrms_Office_Location_Master] ([CompanyId], [OfficeLocationCode], [OfficeLocationName], [Location], [Address1], [Address2], [Address3]) VALUES ('{officeLocationInfo[0]}', '{officeLocationInfo[1]}', '{officeLocationInfo[2]}', '{officeLocationInfo[3]}', '{officeLocationInfo[4]}', '{officeLocationInfo[5]}', '{officeLocationInfo[6]}')";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }

        public void Update(List<string> officeLocationInfo)
        {
            _conn.Open();

            var sqlQuery = $"UPDATE [dbo].[Hrms_Office_Location_Master] Set CompanyId = '{officeLocationInfo[0]}', OfficeLocationName = '{officeLocationInfo[2]}', Location = '{officeLocationInfo[3]}', Address1 = '{officeLocationInfo[4]}', Address2 = '{officeLocationInfo[5]}', Address3 = '{officeLocationInfo[6]}' WHERE OfficeLocationCode = '{officeLocationInfo[1]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }

        public DataTable GetOfficeLocationInformation()
        {
            _conn.Open();

            string sqlQuery = "SELECT [CompanyId], [OfficeLocationCode], [OfficeLocationName], [Location], [Address1], [Address2], [Address3] FROM [dbo].[Hrms_Office_Location_Master]";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            _conn.Close();

            return dataTable;
        }

        public DataTable GetOfficeLocationInformation(string companyId)
        {
            _conn.Open();

            string sqlQuery = $"SELECT [CompanyId], [OfficeLocationCode], [OfficeLocationName], [Location], [Address1], [Address2], [Address3] FROM [dbo].[Hrms_Office_Location_Master] WHERE CompanyId = '{companyId}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            _conn.Close();

            return dataTable;
        }

        public void DeleteRow(string officeLocationCode)
        {
            _conn.Open();

            var sqlQuery = $"DELETE FROM [dbo].[Hrms_Office_Location_Master] WHERE OfficeLocationCode='{officeLocationCode}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }

    }
}