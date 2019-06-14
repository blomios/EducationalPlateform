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
            Response.Redirect("/UVS/FormUV.aspx", true);
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // uv detail
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView_UVs, "Select$" + e.Row.RowIndex);
                e.Row.Attributes.Add("style", "cursor: pointer");
            }
        }

        protected void GridView_UVs_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string uvDenomination = GridView_UVs.Rows[GridView_UVs.SelectedIndex].Cells[0].Text;
            Response.Redirect("/UVS/DetailUV.aspx?uv=" + uvDenomination, true);
        }
    }
}