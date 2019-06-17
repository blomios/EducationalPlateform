using LO54_Projet.Entities;
using LO54_Projet.Models;
using LO54_Projet.Repository;
using LO54_Projet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.Admin
{
    public partial class SetTeacher : System.Web.UI.Page
    {
        private static IdentityDb identityContext = IdentityDb.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ApplicationUser user = identityContext.GetByEmailEager(Email.Text);
                identityContext.setRole(user.Id, CustomRoles.roles.Prof.ToString());
            }
        }

        protected void Button_Back(object sender, EventArgs e)
        {
            RedirectToDefault();
        }

        private void RedirectToDefault()
        {
            Response.Redirect("~/Default.aspx", true);
        }
    }
}