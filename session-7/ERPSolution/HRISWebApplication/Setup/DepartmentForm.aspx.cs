using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CompanyDDList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}