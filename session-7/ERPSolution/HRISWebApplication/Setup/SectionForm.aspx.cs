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
    public partial class SectionForm : System.Web.UI.Page
    {
        public static string CompanyId { get; set; }
        public static string OfficeLocationCode { get; set; }
        public static string DepartmentCode { get; set; }
        private OfficeLocationDataAccess officeLocationDataAccess;
        private CompanyDataAccess companyDataAccess;
        private DepartmentDataAccess departmentDataAccess;
        private SectionDataAccess sectionDataAccess;

        public SectionForm()
        {
            officeLocationDataAccess = new OfficeLocationDataAccess();
            companyDataAccess = new CompanyDataAccess();
            departmentDataAccess = new DepartmentDataAccess();
            sectionDataAccess = new SectionDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadAllCompanies();
                LoadAllOfficeLocations();
                LoadAllDepartments();
                ShowSectionInformation();
            }
        }

        protected void btnSaveSection_Click(object sender, EventArgs e)
        {
            if (btnSaveSection.Text.Equals("Save"))
            {
                SaveSection();
            }
            else if (btnSaveSection.Text.Equals("Update"))
            {
                UpdateSectionInformation();
                btnSaveSection.Text = "Save";
            }

            ShowSectionInformation();
            ClearAllInputs();
        }

        protected void btnClearSection_Click(object sender, EventArgs e)
        {
            ClearAllInputs();
        }

        private void UpdateSectionInformation()
        {
            throw new NotImplementedException();
        }

        private void SaveSection()
        {
            var sectionInfo = new List<string>();
            sectionInfo.Add(CompanyId);
            sectionInfo.Add(OfficeLocationCode);
            sectionInfo.Add(DepartmentCode);
            sectionInfo.Add(txtSectionCode.Text);
            sectionInfo.Add(txtSectionName.Text);
            sectionInfo.Add(txtHeadOfSection.Text);
            sectionInfo.Add(txtSubHeadOfSection.Text);

            sectionDataAccess.Save(sectionInfo);
        }

        private void ClearAllInputs()
        {
            LoadAllCompanies();
            LoadAllOfficeLocations();
            LoadAllDepartments();

            txtSectionCode.Text = string.Empty;
            txtSectionName.Text = string.Empty;
            txtHeadOfSection.Text = string.Empty;
            txtSubHeadOfSection.Text = string.Empty;

            btnSaveSection.Text = "Save";
        }

        private void ShowSectionInformation()
        {
            var dataTable = sectionDataAccess.GetSectionInformation();
            sectionGrid.DataSource = dataTable;
            sectionGrid.DataBind();
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

        protected void sectionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());
                var sectionCode = sectionGrid.Rows[selectedIndex].Cells[5].Text;
                sectionDataAccess.DeleteRow(sectionCode);
                ShowSectionInformation();
            }
            else if (e.CommandName.Equals("Select"))
            {
                var selectedIndex = int.Parse(e.CommandArgument.ToString());

                CompanyDDList.SelectedValue = sectionGrid.Rows[selectedIndex].Cells[2].Text.Equals("&nbsp;") ? string.Empty : sectionGrid.Rows[selectedIndex].Cells[2].Text;
                CompanyId = CompanyDDList.SelectedValue.ToString();
                //OfficeLocationDDList.SelectedValue = departmentGrid.Rows[selectedIndex].Cells[3].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[3].Text;
                OfficeLocationCode = OfficeLocationDDList.SelectedValue.ToString();
                //DepartmentDDList.SelectedValue = departmentGrid.Rows[selectedIndex].Cells[4].Text.Equals("&nbsp;") ? string.Empty : departmentGrid.Rows[selectedIndex].Cells[4].Text;
                DepartmentCode = DepartmentDDList.SelectedValue.ToString();
                txtSectionCode.Text = sectionGrid.Rows[selectedIndex].Cells[5].Text.Equals("&nbsp;") ? string.Empty : sectionGrid.Rows[selectedIndex].Cells[5].Text;
                txtSectionName.Text = sectionGrid.Rows[selectedIndex].Cells[6].Text.Equals("&nbsp;") ? string.Empty : sectionGrid.Rows[selectedIndex].Cells[6].Text;
                txtHeadOfSection.Text = sectionGrid.Rows[selectedIndex].Cells[7].Text.Equals("&nbsp;") ? string.Empty : sectionGrid.Rows[selectedIndex].Cells[7].Text;
                txtSubHeadOfSection.Text = sectionGrid.Rows[selectedIndex].Cells[8].Text.Equals("&nbsp;") ? string.Empty : sectionGrid.Rows[selectedIndex].Cells[8].Text;


                btnSaveSection.Text = "Update";
            }
        }

        protected void sectionGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void sectionGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        }
    }
}