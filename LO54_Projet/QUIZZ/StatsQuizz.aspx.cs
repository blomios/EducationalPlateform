using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Repository;
using Microsoft.AspNet.Identity;


namespace LO54_Projet.QUIZZ
{
    public partial class StatsQuizz : System.Web.UI.Page
    {
        private QuizzDb quizzContext = QuizzDb.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }

            string quizzId = Request.Params.Get("quizz");
            if (quizzId == null || quizzContext.GetByIdString(quizzId) == null)
            {
                Response.Redirect("/Errors/403.aspx", true);
            }

            SqlDataSource_Quizz.SelectCommand = "SELECT uq.[Score], uq.[ScoreMax], u.[UserName]"
                                                + " FROM [User_Quizz] uq JOIN [AspNetUsers] u ON uq.UserId = u.Id"
                                                + " WHERE uq.QuizzId = " + quizzId;
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    bool isOwner = IsOwner(DataBinder.Eval(e.Row.DataItem, "Owner").ToString());

            //    // display action buttons if user is owner
            //    TableCell actionCell = e.Row.Cells[e.Row.Cells.Count - 1];
            //    actionCell.FindControl("btn_del").Visible = isOwner;

            //    bool quizzTaken = !(e.Row.Cells[1].Text.Equals("&nbsp;")); // pour le NULL

            //    // project detail on row click, except for the last cell with the action buttons

            //    // Only if the quizz has not been done yet
            //    if (!quizzTaken)
            //    {
            //        for (int i = 0; i < e.Row.Cells.Count - 1; i++)
            //        {
            //            e.Row.Cells[i].Attributes["onclick"] = clientScript.GetPostBackClientHyperlink(GridView_Projects, "Select$" + e.Row.RowIndex);
            //            e.Row.Cells[i].Attributes.Add("style", "cursor: pointer");
            //        }
            //    }
            //    e.Row.Attributes.Add("IdQuizz", DataBinder.Eval(e.Row.DataItem, "IdQuizz").ToString());
            //}
        }

        protected void GridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //string projectId = GridView_Projects.Rows[GridView_Projects.SelectedIndex].Cells[0].Text;
            //string IdQuizz = GridView_Projects.Rows[GridView_Projects.SelectedIndex].Attributes["IdQuizz"];
            //Response.Redirect("/QUIZZ/DetailQuizz.aspx?quizz=" + IdQuizz, true);
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            string url = ViewState["RefUrl"] == null ? "listUV.aspx" : (string)ViewState["RefUrl"];
            Response.Redirect(url, true);
        }
    }
}