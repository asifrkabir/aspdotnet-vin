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
    public partial class DesignationForm : System.Web.UI.Page
    {
        public static string CompanyId { get; set; }
        public static string OfficeLocationCode { get; set; }
        public static string DepartmentCode { get; set; }
        public static string SectionCode { get; set; }
        private OfficeLocationDataAccess officeLocationDataAccess;
        private CompanyDataAccess companyDataAccess;
        private DepartmentDataAccess departmentDataAccess;
        private SectionDataAccess sectionDataAccess;
        private DesignationDataAccess designationDataAccess;

        public DesignationForm()
        {
            officeLocationDataAccess = new OfficeLocationDataAccess();
            companyDataAccess = new CompanyDataAccess();
            departmentDataAccess = new DepartmentDataAccess();
            sectionDataAccess = new SectionDataAccess();
            designationDataAccess = new DesignationDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllCompanies();
                LoadAllOfficeLocations();
                LoadAllDepartments();
                LoadAllSections();
            }
        }

        protected void btnSaveDesignation_Click(object sender, EventArgs e)
        {
            if (btnSaveDesignation.Text.Equals("Save"))
            {
                SaveDesignation();
            }
            else if (btnSaveDesignation.Text.Equals("Update"))
            {
                UpdateDesignationInformation();
                btnSaveDesignation.Text = "Save";
            }

            ShowDesignationInformation();
            ClearAllInputs();
        }

        protected void btnClearDesignation_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
        }

        private void SaveDesignation()
        {
            var designationInfo = new List<string>();
            designationInfo.Add(CompanyId);
            designationInfo.Add(OfficeLocationCode);
            designationInfo.Add(DepartmentCode);
            designationInfo.Add(SectionCode);
            designationInfo.Add(txtDesignationCode.Text);
            designationInfo.Add(txtDesignationName.Text);

            designationDataAccess.Save(designationInfo);
        }

        private void ClearAllInputs()
        {
            LoadAllCompanies();
            LoadAllOfficeLocations();
            LoadAllDepartments();
            LoadAllSections();

            txtDesignationCode.Text = string.Empty;
            txtDesignationName.Text = string.Empty;

            btnSaveDesignation.Text = "Save";
        }

        private void ShowDesignationInformation()
        {
            var dataTable = designationDataAccess.GetDesignationInformation();
            designationGrid.DataSource = dataTable;
            designationGrid.DataBind();
        }

        private void UpdateDesignationInformation()
        {
            throw new NotImplementedException();
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

        private void LoadAllDepartments()
        {
            var dataTable = departmentDataAccess.GetDepartmentInformation(CompanyId, OfficeLocationCode);
            DepartmentDDList.Items.Clear();

            if (dataTable.Rows.Count > 0)
            {
                DepartmentDDList.Items.Insert(0, new ListItem("Select Department", "-1"));

                foreach (DataRow dr in dataTable.Rows)
                {
                    var listItem = new ListItem();
                    listItem.Text = dr["DepartmentName"].ToString();
                    listItem.Value = dr["DepartmentCode"].ToString();
                    DepartmentDDList.Items.Add(listItem);
                }
            }
            else
            {
                DepartmentDDList.Items.Insert(0, new ListItem("Select Department", "-1"));
                DepartmentCode = "";
            }
        }

        private void LoadAllSections()
        {
            var dataTable = sectionDataAccess.GetSectionInformation(CompanyId, OfficeLocationCode, DepartmentCode);
            SectionDDList.Items.Clear();

            if (dataTable.Rows.Count > 0)
            {
                SectionDDList.Items.Insert(0, new ListItem("Select Section", "-1"));

                foreach (DataRow dr in dataTable.Rows)
                {
                    var listItem = new ListItem();
                    listItem.Text = dr["SectionName"].ToString();
                    listItem.Value = dr["SectionCode"].ToString();
                    SectionDDList.Items.Add(listItem);
                }
            }
            else
            {
                SectionDDList.Items.Insert(0, new ListItem("Select Section", "-1"));
                SectionCode = "";
            }
        }

        protected void CompanyDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyId = CompanyDDList.SelectedValue.ToString();
            LoadAllOfficeLocations();
        }

        protected void OfficeLocationDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OfficeLocationCode = OfficeLocationDDList.SelectedValue.ToString();
            LoadAllDepartments();
        }

        protected void DepartmentDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentCode = DepartmentDDList.SelectedValue.ToString();
            LoadAllSections();
        }

        protected void SectionDDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectionCode = SectionDDList.SelectedValue.ToString();
            //LoadAllSections();
        }

        protected void designationGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());
                var designationCode = designationGrid.Rows[selectedIndex].Cells[6].Text;
                designationDataAccess.DeleteRow(designationCode);
                ShowDesignationInformation();
            }
            else if (e.CommandName.Equals("Select"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());

                CompanyDDList.SelectedValue = designationGrid.Rows[selectedIndex].Cells[2].Text.Equals("&nbsp;") ? string.Empty : designationGrid.Rows[selectedIndex].Cells[2].Text;
                CompanyId = CompanyDDList.SelectedValue.ToString();
                LoadAllOfficeLocations();
                OfficeLocationDDList.SelectedValue = designationGrid.Rows[selectedIndex].Cells[3].Text.Equals("&nbsp;") ? string.Empty : designationGrid.Rows[selectedIndex].Cells[3].Text;
                OfficeLocationCode = OfficeLocationDDList.SelectedValue.ToString();
                LoadAllDepartments();
                DepartmentDDList.SelectedValue = designationGrid.Rows[selectedIndex].Cells[4].Text.Equals("&nbsp;") ? string.Empty : designationGrid.Rows[selectedIndex].Cells[4].Text;
                DepartmentCode = DepartmentDDList.SelectedValue.ToString();
                LoadAllSections();
                SectionDDList.SelectedValue = designationGrid.Rows[selectedIndex].Cells[5].Text.Equals("&nbsp;") ? string.Empty : designationGrid.Rows[selectedIndex].Cells[5].Text;
                SectionCode = SectionDDList.SelectedValue.ToString();
                txtDesignationCode.Text = designationGrid.Rows[selectedIndex].Cells[6].Text.Equals("&nbsp;") ? string.Empty : designationGrid.Rows[selectedIndex].Cells[6].Text;
                txtDesignationName.Text = designationGrid.Rows[selectedIndex].Cells[7].Text.Equals("&nbsp;") ? string.Empty : designationGrid.Rows[selectedIndex].Cells[7].Text;


                btnSaveDesignation.Text = "Update";
            }
        }

        protected void designationGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void designationGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}