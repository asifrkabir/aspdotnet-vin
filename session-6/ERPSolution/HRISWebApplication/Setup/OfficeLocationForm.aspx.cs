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
            SaveOfficeLocation();
            ShowOfficeLocationInformation();
        }

        protected void btnClearOfficeLocation_Click(object sender, EventArgs e)
        {
            
        }

        protected void CompanyDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = CompanyDDList.SelectedValue;
        }
    }
}