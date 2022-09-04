using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanyDataAccess
    {
        private SqlConnection _conn;

        public CompanyDataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringCompany"].ConnectionString);
            _conn.Open();
        }
        public void Save(List<string> companyInfo)
        {
            var sqlQuery = $"INSERT INTO [dbo].[Hrms_Company_Master] " +
                $"([CompanyName] ,[CompanyId], [Address1] ,[Address2], [Address3],[ContPer1], [ContPer2], [Phone1]" +
                $", [Fax1], [Email1] ,[Url1] ,[TIN],[RegNo] ,[VATNo] ,[Insurance1])" +
                $"VALUES " +
                $"('{companyInfo[0]}', '{companyInfo[1]}', " +
                $"'{companyInfo[2]}', '{companyInfo[3]}', " +
                $"'{companyInfo[4]}', '{companyInfo[5]}', " +
                $"'{companyInfo[6]}', '{companyInfo[7]}'," +
                $"'{companyInfo[8]}', '{companyInfo[9]}', '{companyInfo[10]}', '{companyInfo[11]}'," +
                $"'{companyInfo[12]}', '{companyInfo[13]}', '{companyInfo[14]}')";


            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
        }

        public SqlDataReader GetCompanyInformation()
        {
            string sqlQuery = "SELECT [CompanyId], [CompanyName], [Address1], [Address2], [Address3], [ContPer1], [ContPer2], [Phone1], [Fax1], [Email1], [Url1], [TIN], [RegNo], [VATNo], [Insurance1] FROM [dbo].[Hrms_Company_Master]";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void DeleteRow(string companyId)
        {
            var sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Master] WHERE CompanyId='{companyId}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();
        }
    }
}