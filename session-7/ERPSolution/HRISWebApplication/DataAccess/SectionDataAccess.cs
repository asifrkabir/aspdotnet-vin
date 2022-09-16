using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class SectionDataAccess
    {
        private SqlConnection _conn;

        public SectionDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCompany"].ConnectionString);
        }

        public void Save(List<string> sectionInfo)
        {
            _conn.Open();

            var sqlQuery = $"INSERT INTO [dbo].[Hrms_Section_Master] ([CompanyId], [OfficeLocationCode], [DepartmentCode], [SectionCode], [SectionName], [HeadOfSection], [SubHeadOfSection]) VALUES ('{sectionInfo[0]}', '{sectionInfo[1]}', '{sectionInfo[2]}', '{sectionInfo[3]}', '{sectionInfo[4]}', '{sectionInfo[5]}', '{sectionInfo[6]}')";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }

        public DataTable GetSectionInformation()
        {
            _conn.Open();

            string sqlQuery = "SELECT [CompanyId], [OfficeLocationCode], [DepartmentCode], [SectionCode], [SectionName], [HeadOfSection], [SubHeadOfSection] FROM [dbo].[Hrms_Section_Master]";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            _conn.Close();

            return dataTable;
        }

        public void DeleteRow(string sectionCode)
        {
            _conn.Open();

            var sqlQuery = $"DELETE FROM [dbo].[Hrms_Section_Master] WHERE SectionCode='{sectionCode}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}