using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            //_conn.Open();
        }
        public void Save(List<string> companyInfo)
        {
            _conn.Open();

            if (companyInfo[0].Equals(string.Empty))
            {
                HttpContext.Current.Response.Write("<script>alert('Please Add Company ID')</script>");
            }

            else
            {
                //var checkDuplicateIDQuery = $"SELECT COUNT(*) FROM [dbo].[Hrms_Company_Master] WHERE ([CompanyId] = {companyInfo[0]})";
                //SqlCommand checkIDCommand = new SqlCommand(checkDuplicateIDQuery, _conn);
                ////checkIDCommand.Parameters.AddWithValue("@companyInfo[0]", companyInfo[0]);
                //SqlDataReader reader = checkIDCommand.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    HttpContext.Current.Response.Write("<script>alert('Company ID already exists')</script>");
                //}

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

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    HttpContext.Current.Response.Write("<script>alert('Company already exists')</script>");
                }
            }

            _conn.Close();
        }

        //public SqlDataReader GetCompanyInformation()
        //{
        //    string sqlQuery = "SELECT [CompanyId], [CompanyName], [Address1], [Address2], [Address3], [ContPer1], [ContPer2], [Phone1], [Fax1], [Email1], [Url1], [TIN], [RegNo], [VATNo], [Insurance1] FROM [dbo].[Hrms_Company_Master]";
        //    SqlCommand command = new SqlCommand(sqlQuery, _conn);
        //    SqlDataReader reader = command.ExecuteReader();
        //    return reader;
        //}

        public DataTable GetCompanyInformation()
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

        public void DeleteRow(string companyId)
        {
            _conn.Open();

            var sqlQuery = $"DELETE FROM [dbo].[Hrms_Company_Master] WHERE CompanyId='{companyId}'";
            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }

        public void Update(List<string> companyInfo)
        {
            _conn.Open();

            var sqlQuery = $@"UPDATE [dbo].[Hrms_Company_Master] Set CompanyName = '{companyInfo[1]}', Address1 = '{companyInfo[2]}', Address2 = '{companyInfo[3]}', Address3 = '{companyInfo[4]}', ContPer1 = '{companyInfo[5]}', ContPer2 = '{companyInfo[6]}', Phone1 = '{companyInfo[7]}', Fax1 = '{companyInfo[8]}', Email1 = '{companyInfo[9]}', Url1 = '{companyInfo[10]}', TIN = '{companyInfo[11]}', RegNo = '{companyInfo[12]}', VATNo = '{companyInfo[13]}', Insurance1 = '{companyInfo[14]}' WHERE CompanyId = '{companyInfo[0]}'";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);
            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}