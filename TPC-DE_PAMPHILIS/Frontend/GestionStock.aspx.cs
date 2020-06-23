using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Frontend
{
    public partial class GestionStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDown.Items.Add("Menos que");
            DropDown.Items.Add("Mas que");
        }
    }
}