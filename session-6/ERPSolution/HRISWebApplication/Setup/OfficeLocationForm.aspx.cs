using HRISWebApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRISWebApplication.Setup
{
    public partial class OfficeLocationForm : System.Web.UI.Page
    {
        private CompanyDataAccess companyDataAccess;
        public OfficeLocationForm()
        {
            companyDataAccess = new CompanyDataAccess();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveOfficeLocation_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearOfficeLocation_Click(object sender, EventArgs e)
        {

        }
    }
}