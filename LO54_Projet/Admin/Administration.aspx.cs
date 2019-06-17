using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Repository;
using LO54_Projet.Tools;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using LO54_Projet.Models;
using LO54_Projet.Tools;

namespace LO54_Projet.Administration
{
    public partial class Administration : System.Web.UI.Page
    {
        private CustomRoles cr = new CustomRoles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser currentUser= manager.FindById(User.Identity.GetUserId());
                if (Request.IsAuthenticated && !cr.isAdmin(currentUser.Role))
                    // This is an unauthorized, authenticated request...
                    Response.Redirect("~/UnauthorizedAccess.aspx");
            }
        }

        protected void GridView_Users_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OrderedDictionary od = (OrderedDictionary)e.NewValues;
            string roleValue = od[2].ToString();
            string id = GridView_Users.Rows[e.RowIndex].Cells[1].Text;
            string email = od[1].ToString();
            string username = od[0].ToString();

            if (username.Contains("'"))
            {
                
                username = username.Replace("'", " ");
            }

            if (!cr.isRole(roleValue))
            {
                e.Cancel = true;
            }
            else
            {
                SqlDataSource_users.UpdateCommand = " UPDATE [AspNetUsers] SET [Email]= '" + email + "'" +
                    ", [UserName] = '" + username + "'" +
                    ",[Role] = '" + roleValue + "'" +
                    " WHERE [Id] = '" + id + "'";
                SqlDataSource_users.Update();
            }
        }
        

        private void updateValues()
        {
        }
    }
}