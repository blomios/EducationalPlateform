using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.Controllers
{
    public partial class Uploadfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Files is folder Name
            try
            {
                fuSample.SaveAs(Server.MapPath("~") + "/DataDirectory/" + fuSample.FileName);
                lblMessage.Text = "File Successfully Uploaded";
                lblMessage.ForeColor = System.Drawing.Color.FromArgb(54, 204, 43);
            }
            catch
            {
                lblMessage.ForeColor = System.Drawing.Color.FromArgb(230, 12, 12);
                lblMessage.Text = "Error";
            }
        }
    }
}