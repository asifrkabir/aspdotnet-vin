using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
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
                //LoadAllCompanies();
                //LoadAllOfficeLocations();
                //LoadAllDepartments();
                ShowSectionInformation();
            }
        }

        private void ShowSectionInformation()
        {
            var dataTable = sectionDataAccess.GetSectionInformation();
            sectionGrid.DataSource = dataTable;
            sectionGrid.DataBind();
        }

        protected void btnSaveSection_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnClearDepartment_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void sectionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void sectionGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void sectionGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}