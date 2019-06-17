using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Entities;
using LO54_Projet.Models;
using LO54_Projet.Repository;
using LO54_Projet.Tools;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class ListUV : System.Web.UI.Page
    {
        private UVDb uvDb = UVDb.GetInstance();
        private IdentityDb identityDb = IdentityDb.GetInstance();

        private ApplicationUser currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = identityDb.GetByIdEager(Context.User.Identity.GetUserId());
            Button_Go_Add_UV.Visible = currentUser.Role == CustomRoles.roles.Prof.ToString();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Visible = currentUser.HasAccessToUV(int.Parse(DataBinder.Eval(e.Row.DataItem, "IdUv").ToString()));
                bool isOwner = IsOwner(DataBinder.Eval(e.Row.DataItem, "OwnerId").ToString());

                // display action buttons if user is owner
                TableCell actionCell = e.Row.Cells[e.Row.Cells.Count - 1];
                actionCell.FindControl("btn_edit").Visible = isOwner;
                actionCell.FindControl("btn_del").Visible = isOwner;


                // uv detail on row click, except for the last cell with the action buttons
                for (int i = 0; i < e.Row.Cells.Count - 1; i++)
                {
                    e.Row.Cells[i].Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView_UVs, "Select$" + e.Row.RowIndex);
                    e.Row.Cells[i].Attributes.Add("style", "cursor: pointer");
                }
            }
        }

        protected void GridView_UVs_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string uvDenomination = GridView_UVs.Rows[GridView_UVs.SelectedIndex].Cells[0].Text;
            Response.Redirect("/UVS/DetailUV.aspx?uv=" + uvDenomination, true);
        }

        protected void GridView_UVs_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    // go to formUV
                    Response.Redirect("/UVS/FormUV.aspx?uv=" + e.CommandArgument, true);
                    break;

                case "del":
                    // delete and refresh
                    uvDb.DeleteByDenomination(e.CommandArgument.ToString());
                    this.Response.Redirect(Request.RawUrl);
                    break;
            } 
            
        }

        protected bool IsOwner(string ownerId)
        {
            return ownerId == Context.User.Identity.GetUserId();
        }

        protected void Button_Go_Add_UV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UVS/FormUV.aspx", true);
        }

        protected void Button_Go_Edit_UV_Click(object sender, EventArgs e)
        {
            
        }
    }
}