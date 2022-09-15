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
        public static string OfficeLocationCode { get; set; }
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
                LoadAllOfficeLocations();
                ShowDepartmentInformation();
            }
        }

        protected void CompanyDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = CompanyDDList.SelectedValue.ToString();
            LoadAllOfficeLocations();
        }

        private void ShowDepartmentInformation()
        {
            var dataTable = departmentDataAccess.GetDepartmentInformation();
            departmentGrid.DataSource = dataTable;
            departmentGrid.DataBind();
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

        private void LoadAllOfficeLocations()
        {
            var dataTable = officeLocationDataAccess.GetOfficeLocationInformation(CompanyId);
            OfficeLocationDDList.Items.Clear();

            if (dataTable.Rows.Count > 0)
            {
                OfficeLocationDDList.Items.Insert(0, new ListItem("Select Office Location", "-1"));

                foreach (DataRow dr in dataTable.Rows)
                {
                    var listItem = new ListItem();
                    listItem.Text = dr["OfficeLocationName"].ToString();
                    listItem.Value = dr["OfficeLocationCode"].ToString();
                    OfficeLocationDDList.Items.Add(listItem);
                }
            }
            else
            {
                OfficeLocationDDList.Items.Insert(0, new ListItem("Select Office Location", "-1"));
                OfficeLocationCode = "";
            }
        }

        protected void OfficeLocationDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeLocationCode = OfficeLocationDDList.SelectedValue.ToString();
        }

        protected void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            if (btnSaveDepartment.Text.Equals("Save"))
            {
                SaveDepartment();
            }
            else if (btnSaveDepartment.Text.Equals("Update"))
            {
                UpdateDepartmentInformation();
                btnSaveDepartment.Text = "Save";
            }

            ShowDepartmentInformation();
            ClearAllInputs();
        }

        private void UpdateDepartmentInformation()
        {
            throw new NotImplementedException();
        }

        private void SaveDepartment()
        {
            var departmentInfo = new List<string>();
            departmentInfo.Add(CompanyId);
            departmentInfo.Add(OfficeLocationCode);
            departmentInfo.Add(txtDepartmentCode.Text);
            departmentInfo.Add(txtDepartmentName.Text);
            departmentInfo.Add(txtDepartmentLocation.Text);
            departmentInfo.Add(txtHeadOfDepartment.Text);
            departmentInfo.Add(txtSubHeadOfDepartment.Text);

            departmentDataAccess.Save(departmentInfo);
        }

        private void ClearAllInputs()
        {
            LoadAllCompanies();
            LoadAllOfficeLocations();

            txtDepartmentCode.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
            txtDepartmentLocation.Text = string.Empty;
            txtHeadOfDepartment.Text = string.Empty;
            txtSubHeadOfDepartment.Text = string.Empty;
        }

        protected void btnClearDepartment_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
        }
    }
}