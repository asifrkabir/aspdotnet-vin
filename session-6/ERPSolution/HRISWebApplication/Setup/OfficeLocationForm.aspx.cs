using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Setup
{
    public partial class OfficeLocationForm : System.Web.UI.Page
    {
        public static string CompanyId { get; set; }
        private OfficeLocationDataAccess officeLocationDataAccess;
        private CompanyDataAccess companyDataAccess;

        public OfficeLocationForm()
        {
            officeLocationDataAccess = new OfficeLocationDataAccess();
            companyDataAccess = new CompanyDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllCompanies();
                ShowOfficeLocationInformation();
            }
        }

        private void SaveOfficeLocation()
        {
            var officeLocationInfo = new List<string>();
            officeLocationInfo.Add(CompanyDDList.SelectedValue);
            officeLocationInfo.Add(txtOfficeLocationCode.Text);
            officeLocationInfo.Add(txtOfficeLocationName.Text);
            officeLocationInfo.Add(txtOfficeLocation.Text);
            officeLocationInfo.Add(txtOfficeAddress1.Text);
            officeLocationInfo.Add(txtOfficeAddress2.Text);
            officeLocationInfo.Add(txtOfficeAddress3.Text);

            officeLocationDataAccess.Save(officeLocationInfo);
        }

        private void UpdateOfficeLocationInformation()
        {
            var officeLocationInfo = new List<string>();
            officeLocationInfo.Add(CompanyDDList.SelectedValue);
            officeLocationInfo.Add(txtOfficeLocationCode.Text);
            officeLocationInfo.Add(txtOfficeLocationName.Text);
            officeLocationInfo.Add(txtOfficeLocation.Text);
            officeLocationInfo.Add(txtOfficeAddress1.Text);
            officeLocationInfo.Add(txtOfficeAddress2.Text);
            officeLocationInfo.Add(txtOfficeAddress3.Text);

            officeLocationDataAccess.Update(officeLocationInfo);
        }

        private void ShowOfficeLocationInformation()
        {
            var dataTable = officeLocationDataAccess.GetOfficeLocationInformation();
            officeLocationGrid.DataSource = dataTable;
            officeLocationGrid.DataBind();
        }

        private void LoadAllCompanies()
        {
            var dataTable = companyDataAccess.GetCompanyInformation();
            CompanyDDList.Items.Clear();

            if (dataTable.Rows.Count > 0)
            {
                CompanyDDList.Items.Insert(0, new ListItem("--- Select Company ID ---", "-1"));

                foreach (DataRow dr in dataTable.Rows)
                {
                    var listItem = new ListItem();
                    listItem.Text = dr["CompanyName"].ToString();
                    listItem.Value = dr["CompanyId"].ToString();
                    CompanyDDList.Items.Add(listItem);
                }
            }
            else
            {
                CompanyDDList.Items.Insert(0, new ListItem("--- Select Company ID ---", "-1"));
                CompanyId = "";
            }
        }

        protected void btnSaveOfficeLocation_Click(object sender, EventArgs e)
        {
            if (btnSaveOfficeLocation.Text.Equals("Save"))
            {
                SaveOfficeLocation();
            }
            else if (btnSaveOfficeLocation.Text.Equals("Update"))
            {
                UpdateOfficeLocationInformation();
                btnSaveOfficeLocation.Text = "Save";
            }

            ShowOfficeLocationInformation();
            ClearAllInputs();
        }

        protected void btnClearOfficeLocation_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
        }

        private void ClearAllInputs()
        {
            LoadAllCompanies();

            txtOfficeLocationCode.Text = string.Empty;
            txtOfficeLocationName.Text = string.Empty;
            txtOfficeLocation.Text = string.Empty;
            txtOfficeAddress1.Text = string.Empty;
            txtOfficeAddress2.Text = string.Empty;
            txtOfficeAddress3.Text = string.Empty;
        }

        protected void CompanyDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = CompanyDDList.SelectedValue;
        }

        protected void officeLocationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());
                var officeLocationCode = officeLocationGrid.Rows[selectedIndex].Cells[3].Text;
                officeLocationDataAccess.DeleteRow(officeLocationCode);
                ShowOfficeLocationInformation();
            }

            else if (e.CommandName.Equals("Select"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());

                CompanyDDList.SelectedValue = officeLocationGrid.Rows[selectedIndex].Cells[2].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[2].Text;
                CompanyId = CompanyDDList.SelectedValue;
                txtOfficeLocationCode.Text = officeLocationGrid.Rows[selectedIndex].Cells[3].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[3].Text;
                txtOfficeLocationName.Text = officeLocationGrid.Rows[selectedIndex].Cells[4].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[4].Text;
                txtOfficeLocation.Text = officeLocationGrid.Rows[selectedIndex].Cells[5].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[5].Text;
                txtOfficeAddress1.Text = officeLocationGrid.Rows[selectedIndex].Cells[6].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[6].Text;
                txtOfficeAddress2.Text = officeLocationGrid.Rows[selectedIndex].Cells[7].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[7].Text;
                txtOfficeAddress3.Text = officeLocationGrid.Rows[selectedIndex].Cells[8].Text.Equals("&nbsp;") ? string.Empty : officeLocationGrid.Rows[selectedIndex].Cells[8].Text;

                btnSaveOfficeLocation.Text = "Update";
            }
        }

        protected void officeLocationGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void officeLocationGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}