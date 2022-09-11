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
            if (btnSave.Text.Equals("Save"))
            {
                SaveCompanyInformation();
            }
            else
            {
                UpdateCompanyInformation();
                btnSave.Text = "Save";
            }

            ClearAllInputs();
            ShowCompanyInformation();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
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

        //private void ShowCompanyInformation()
        //{
        //    SqlDataReader reader = companyDataAccess.GetCompanyInformation();
        //    companyGrid.DataSource = reader;
        //    companyGrid.DataBind();
        //    reader.Close();
        //}

        private void ShowCompanyInformation()
        {
            var dataTable = companyDataAccess.GetCompanyInformation();
            companyGrid.DataSource = dataTable;
            companyGrid.DataBind();
        }

        private void UpdateCompanyInformation()
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

            companyDataAccess.Update(companyInfo);
        }

        private void ClearAllInputs()
        {
            txtCompanyID.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCompanyAddress1.Text = string.Empty;
            txtCompanyAddress2.Text = string.Empty;
            txtCompanyAddress3.Text = string.Empty;
            txtContactPersonAddress.Text = string.Empty;
            txtContactPersonEmail.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtURL.Text = string.Empty;
            txtTIN.Text = string.Empty;
            txtRegNo.Text = string.Empty;
            txtVATNo.Text = string.Empty;
            txtInsurance.Text = string.Empty;
        }

        protected void companyGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());
                var companyID = companyGrid.Rows[selectedIndex].Cells[2].Text;
                companyDataAccess.DeleteRow(companyID);
                ShowCompanyInformation();
            }

            else if (e.CommandName.Equals("Select"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());

                txtCompanyID.Text = companyGrid.Rows[selectedIndex].Cells[2].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[2].Text;
                txtCompanyName.Text = companyGrid.Rows[selectedIndex].Cells[3].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[3].Text;
                txtCompanyAddress1.Text = companyGrid.Rows[selectedIndex].Cells[4].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[4].Text;
                txtCompanyAddress2.Text = companyGrid.Rows[selectedIndex].Cells[5].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[5].Text;
                txtCompanyAddress3.Text = companyGrid.Rows[selectedIndex].Cells[6].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[6].Text;
                txtContactPersonAddress.Text = companyGrid.Rows[selectedIndex].Cells[7].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[7].Text;
                txtContactPersonEmail.Text = companyGrid.Rows[selectedIndex].Cells[8].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[8].Text;
                txtPhoneNumber.Text = companyGrid.Rows[selectedIndex].Cells[9].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[9].Text;
                txtFax.Text = companyGrid.Rows[selectedIndex].Cells[10].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[10].Text;
                txtEmail.Text = companyGrid.Rows[selectedIndex].Cells[11].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[11].Text;
                txtURL.Text = companyGrid.Rows[selectedIndex].Cells[12].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[12].Text;
                txtTIN.Text = companyGrid.Rows[selectedIndex].Cells[13].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[13].Text;
                txtRegNo.Text = companyGrid.Rows[selectedIndex].Cells[14].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[14].Text;
                txtVATNo.Text = companyGrid.Rows[selectedIndex].Cells[15].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[15].Text;
                txtInsurance.Text = companyGrid.Rows[selectedIndex].Cells[16].Text.Equals("&nbsp;") ? string.Empty : companyGrid.Rows[selectedIndex].Cells[16].Text;

                btnSave.Text = "Update";
            }
        }

        protected void companyGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void companyGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}