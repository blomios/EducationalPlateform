using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using LO54_Projet.Repository;
using LO54_Projet.Models;
using Microsoft.AspNet.Identity;
using LO54_Projet.Entities;
using System.Security.Principal;
using LO54_Projet.Tools;

namespace LO54_Projet.Controllers
{
    public partial class ListQuizzes : System.Web.UI.UserControl
    {
        public ClientScriptManager clientScript;
        private QuizzDb quizzContext = QuizzDb.GetInstance();
        private IdentityDb identityContext = IdentityDb.GetInstance();
        public int uvId;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource_Projects.SelectCommand = "SELECT p.[IdQuizz], p.[Name], p.[idUv], uq.[Score],uq.[ScoreMax],uq.[UserId],uv.[Owner]"
                                                   + " FROM [Quizzs] p LEFT OUTER JOIN [User_Quizz] uq ON((uq.QuizzId=p.IdQuizz) AND ((uq.UserId='" + Context.User.Identity.GetUserId() + "')))"
                                                   + " LEFT OUTER JOIN [UVs] uv ON (p.IdUv = uv.IdUv) "
                                                   + " WHERE p.idUV = " + uvId;
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isOwner = IsOwner(DataBinder.Eval(e.Row.DataItem, "Owner").ToString());

                // display action buttons if user is owner
                TableCell actionCell = e.Row.Cells[e.Row.Cells.Count - 1];
                actionCell.FindControl("btn_del").Visible = isOwner;

                bool quizzTaken = !(e.Row.Cells[1].Text.Equals("&nbsp;")); // pour le NULL

                // project detail on row click, except for the last cell with the action buttons

                // Only if the quizz has not been done yet
                if (!quizzTaken)
                {
                    for (int i = 0; i < e.Row.Cells.Count - 1; i++)
                    {
                        e.Row.Cells[i].Attributes["onclick"] = clientScript.GetPostBackClientHyperlink(GridView_Projects, "Select$" + e.Row.RowIndex);
                        e.Row.Cells[i].Attributes.Add("style", "cursor: pointer");
                    }
                }
                e.Row.Attributes.Add("IdQuizz", DataBinder.Eval(e.Row.DataItem, "IdQuizz").ToString());
            }
        }

        protected void GridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //string projectId = GridView_Projects.Rows[GridView_Projects.SelectedIndex].Cells[0].Text
            string IdQuizz = GridView_Projects.Rows[GridView_Projects.SelectedIndex].Attributes["IdQuizz"];
            string url = identityContext.GetUserRole(Context.User.Identity.GetUserId()) == CustomRoles.roles.Prof.ToString()
                         ? "/QUIZZ/StatsQuizz.aspx?quizz=" + IdQuizz
                         : "/QUIZZ/DetailQuizz.aspx?quizz=" + IdQuizz;
            Response.Redirect(url, true);
        }

        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    // go to formProject
                    //Response.Redirect("/Projects/FormProject.aspx?uv=" + uvId + "&project=" + e.CommandArgument, true);
                    break;

                case "del":
                    // delete and refresh
                    quizzContext.Delete(e.CommandArgument.ToString());
                    this.Response.Redirect(Request.RawUrl);
                    break;
            }

        }

        protected void delete()
        {
            
        }

        protected bool IsOwner(string ownerId)
        {
            return ownerId == Context.User.Identity.GetUserId();
        }
    }
}