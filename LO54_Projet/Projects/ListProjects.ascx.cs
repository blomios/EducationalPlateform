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

namespace LO54_Projet.Controllers
{
    public partial class ListProjects : System.Web.UI.UserControl
    {
        public ClientScriptManager clientScript;
        private ProjectDb projectContext = ProjectDb.GetInstance();
        public int uvId;

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource_Projects.SelectCommand = "SELECT p.[IdProject], p.[Name], p.[Description], usr.[Email], p.[OwnerId]"
                                                   + " FROM[Projects] p INNER JOIN[AspNetUsers] usr ON p.ownerId = usr.id"
                                                   + " WHERE p.IdUV = " + uvId;
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isOwner = IsOwner(DataBinder.Eval(e.Row.DataItem, "OwnerId").ToString());

                // display action buttons if user is owner
                TableCell actionCell = e.Row.Cells[e.Row.Cells.Count - 1];
                actionCell.FindControl("btn_edit").Visible = isOwner;
                actionCell.FindControl("btn_del").Visible = isOwner;


                // project detail on row click, except for the last cell with the action buttons
                for (int i = 0; i < e.Row.Cells.Count - 1; i++)
                {
                    e.Row.Cells[i].Attributes["onclick"] = clientScript.GetPostBackClientHyperlink(GridView_Projects, "Select$" + e.Row.RowIndex);
                    e.Row.Cells[i].Attributes.Add("style", "cursor: pointer");
                }
                e.Row.Attributes.Add("idProject", DataBinder.Eval(e.Row.DataItem, "IdProject").ToString());
            }
        }

        protected void GridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //string projectId = GridView_Projects.Rows[GridView_Projects.SelectedIndex].Cells[0].Text;
            string projectId = GridView_Projects.Rows[GridView_Projects.SelectedIndex].Attributes["idProject"];
            Response.Redirect("/Projects/DetailProject.aspx?project=" + projectId, true);
        }

        protected void GridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    // go to formProject
                    Response.Redirect("/Projects/FormProject.aspx?uv=" + uvId + "&project=" + e.CommandArgument, true);
                    break;

                case "del":
                    // delete and refresh
                    projectContext.Delete(int.Parse(e.CommandArgument.ToString()));
                    this.Response.Redirect(Request.RawUrl);
                    break;
            }

        }

        protected bool IsOwner(string ownerId)
        {
            return ownerId == Context.User.Identity.GetUserId();
        }
    }
}