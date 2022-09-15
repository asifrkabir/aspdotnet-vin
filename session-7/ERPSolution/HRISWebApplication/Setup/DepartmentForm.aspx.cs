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

            btnSaveDepartment.Text = "Save";
        }

        protected void btnClearDepartment_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
        }

        protected void departmentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());
                var departmentCode = departmentGrid.Rows[selectedIndex].Cells[4].Text;
                departmentDataAccess.DeleteRow(departmentCode);
                ShowDepartmentInformation();
            }
            else if (e.CommandName.Equals("Select"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());

                CompanyDDList.SelectedValue = departmentGrid.Rows[selectedIndex].Cells[2].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[2].Text;
                CompanyId = CompanyDDList.SelectedValue.ToString();
                //OfficeLocationDDList.SelectedValue = departmentGrid.Rows[selectedIndex].Cells[3].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[3].Text;
                OfficeLocationCode = OfficeLocationDDList.SelectedValue.ToString();
                txtDepartmentCode.Text = departmentGrid.Rows[selectedIndex].Cells[4].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[4].Text;
                txtDepartmentName.Text = departmentGrid.Rows[selectedIndex].Cells[5].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[5].Text;
                txtDepartmentLocation.Text = departmentGrid.Rows[selectedIndex].Cells[6].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[6].Text;
                txtHeadOfDepartment.Text = departmentGrid.Rows[selectedIndex].Cells[7].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[7].Text;
                txtSubHeadOfDepartment.Text = departmentGrid.Rows[selectedIndex].Cells[8].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[8].Text;
                

                btnSaveDepartment.Text = "Update";
            }
        }

        protected void departmentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void departmentGrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}