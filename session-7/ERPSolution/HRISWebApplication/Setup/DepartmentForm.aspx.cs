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
    public partial class DepartmentForm : System.Web.UI.Page
    {
        public static string CompanyId { get; set; }
        private OfficeLocationDataAccess officeLocationDataAccess;
        private CompanyDataAccess companyDataAccess;
        private DepartmentDataAccess departmentDataAccess;

        public DepartmentForm()
        {
            officeLocationDataAccess = new OfficeLocationDataAccess();
            companyDataAccess = new CompanyDataAccess();
            departmentDataAccess = new DepartmentDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllCompanies();
                //ShowOfficeLocationInformation();
            }
        }

        protected void CompanyDDList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadAllCompanies()
        {
            var dataTable = companyDataAccess.GetCompanyInformation();
            CompanyDDList.Items.Clear();

            if (dataTable.Rows.Count > 0)
            {
                CompanyDDList.Items.Insert(0, new ListItem("Select Company ID", "-1"));

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
                CompanyDDList.Items.Insert(0, new ListItem("Select Company ID", "-1"));
                CompanyId = "";
            }
        }
    }
}