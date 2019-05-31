using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Entities;
using LO54_Projet.Repository;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class ListUV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlDataSource_UVs.SelectParameters["@UserId"].DefaultValue = User.Identity.GetUserId();
        }

        protected void Button_Go_Add_UV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UVS/AddUV.aspx", true);
        }

        private void refresh()
        {
            this.Response.Redirect(Request.RawUrl);
        }

        protected void SqlDataSource_UVs_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            // Assign the currently logged on user's UserId to the @UserId parameter
            //e.Command.Parameters["@UserId"].Value = User.Identity.GetUserId();
        }

        protected bool IsOwner(string ownerId)
        {
            return ownerId == Context.User.Identity.GetUserId();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool isOwner = IsOwner(DataBinder.Eval(e.Row.DataItem, "OwnerId").ToString());

                // edit buton
                var editButton = (LinkButton)e.Row.Cells[0].Controls[0];
                editButton.Visible = isOwner;

                // uv detail
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView_UVs, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView_UVs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OrderedDictionary oldOd = (OrderedDictionary)e.OldValues;
            string oldDenomination = oldOd[0].ToString();

            OrderedDictionary newOd = (OrderedDictionary)e.NewValues;
            string denomination = newOd[0].ToString();
            string description = newOd[1].ToString();

            if (!UV.IsValidDenomination(denomination))
            {
                ErrorMessage.Text = "Wrong denomination";
                return;
            }

            SqlDataSource_UVs.UpdateCommand = " UPDATE [UVs] " +
                "SET [Denomination]= '" + denomination + "'" +
                ", [description] = '" + description + "'" +
                " WHERE [Denomination] = '" + oldDenomination + "'";
            SqlDataSource_UVs.Update();
        }

        protected void GridView_UVs_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string uvDenomination = GridView_UVs.Rows[GridView_UVs.SelectedIndex].Cells[1].Text;
            Response.Redirect("/UVS/DetailUV.aspx?uv=" + uvDenomination, true);
        }
    }
}