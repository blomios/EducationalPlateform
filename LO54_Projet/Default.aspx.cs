using LO54_Projet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using System.Web.UI.WebControls;
using LO54_Projet.UVS;
using LO54_Projet.Tools;

namespace LO54_Projet
{
    public partial class _Default : Page
    {

        /*
         * ATTENTION :
         * 
         *          SI VOUS VOULEZ REDIRIGER VERS UNE PAGE
         *          UTILISEZ RESPONSE.REDIRECT  (Et non pas Server.transfer)
         *          C EST PRIMORDIAL POUR LE MECANISME DE "POSTBACK"
         *          
         *          JE VOUS INVITE FORTEMENT A ALLER VOIR : https://docs.microsoft.com/en-us/previous-versions/ms178472(v=vs.140)
         *          (déso pour le caps lock, mais c est important,
         *          j'ai passé 2h à essayer de comprendre un pb qui n'existait pas)
         * * * * * * * * * * * * * * * * * * * * * * * * * */
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new IdentityDb();
            Quizz.Visible = context.GetUserRole(Context.User.Identity.GetUserId()) == CustomRoles.roles.Prof.ToString();
            AddStudent.Visible = context.GetUserRole(Context.User.Identity.GetUserId()) == CustomRoles.roles.Prof.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Transfer("UVS/ListUV.aspx");
            Response.Redirect("UVS/ListUV.aspx", true);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("QUIZZ/CreateQuizz.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UVS/AddStudentUV.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin/SetTeacher.aspx");
        }

        protected void refresh()
        {
            this.Response.Redirect(Request.RawUrl);
        }

        protected void GridViewToto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}