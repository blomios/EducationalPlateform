using LO54_Projet.Entities;
using LO54_Projet.Repository;
using System;
using System.Web;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class DetailUV : System.Web.UI.Page
    {
        private static UVDb uvContext = UVDb.GetInstance();
        private static IdentityDb userContext = new IdentityDb();
        private UV cUV;

        protected void Page_Load(object sender, EventArgs e)
        {
            cUV = uvContext.GetByDenomination(Request.Params.Get("uv"));

            if (cUV == null)
            {
                Response.Redirect("/Errors/403.aspx");
            }
            // else

            Page.Title = cUV.Denomination + ": " + cUV.Name;
            LB_Owner.Text = userContext.GetUsername(cUV.Owner);
            LB_Desc.Text = cUV.Description;

            // check if owner for edit button
            Button_Update_UV.Visible = Context.User.Identity.GetUserId() == cUV.Owner;
        }
        
        protected void Button_RedirectToListUV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UVS/ListUV.aspx", true);
        }

        protected void Button_Update_UV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UVS/FormUV.aspx?uv=" + cUV.Denomination, true);
        }
    }
}