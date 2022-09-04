using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Setup
{
    public partial class CompanyInformationForm : System.Web.UI.Page
    {
        private CompanyDataAccess companyDataAccess;
        public CompanyInformationForm()
        {
            companyDataAccess = new CompanyDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCompanyInformation();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveCompanyInformation();
            ShowCompanyInformation();
        }

        private void SaveCompanyInformation()
        {
            var companyInfo = new List<string>();
            companyInfo.Add(txtCompanyID.Text);
            companyInfo.Add(txtCompanyName.Text);
            companyInfo.Add(txtCompanyAddress1.Text);
            companyInfo.Add(txtCompanyAddress2.Text);
            companyInfo.Add(txtCompanyAddress3.Text);
            companyInfo.Add(txtContactPersonAddress.Text);
            companyInfo.Add(txtContactPersonEmail.Text);
            companyInfo.Add(txtPhoneNumber.Text);
            companyInfo.Add(txtFax.Text);
            companyInfo.Add(txtEmail.Text);
            companyInfo.Add(txtURL.Text);
            companyInfo.Add(txtTIN.Text);
            companyInfo.Add(txtRegNo.Text);
            companyInfo.Add(txtVATNo.Text);
            companyInfo.Add(txtInsurance.Text);

            companyDataAccess.Save(companyInfo);
        }

        private void ShowCompanyInformation()
        {
            SqlDataReader reader = companyDataAccess.GetCompanyInformation();
            companyGrid.DataSource = reader;
            companyGrid.DataBind();
            reader.Close();
        }
    }
}