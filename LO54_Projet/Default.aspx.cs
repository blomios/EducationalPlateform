using LO54_Projet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.UVS;

namespace LO54_Projet
{
    public partial class _Default : Page
    {

        TotoTableDAO tDAO = new TotoTableDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Transfer("UVS/ListUV.aspx");
            Response.Redirect("UVS/ListUV.aspx", true);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("QUIZZ/WebForm1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tDAO.deleteToto();
            refresh();
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