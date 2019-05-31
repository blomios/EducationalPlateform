using LO54_Projet.Entities;
using LO54_Projet.Services;
using System;
using System.Web;

namespace LO54_Projet.UVS
{
    public partial class DetailUV : System.Web.UI.Page
    {
        private static UVService uvService = new UVService();
        private UV cUV;

        protected void Page_Load(object sender, EventArgs e)
        {
            cUV = uvService.getByDenomination(Request.Params.Get("uv"));

            if (cUV == null)
            {
                Response.Redirect("/Errors/403.aspx");
            }
            // else

            LB_Denom.Text = cUV.Denomination;
            LB_Desc.Text = cUV.Description;
        }

        private void RedirectToListUV()
        {
            Response.Redirect("/UVS/ListUV.aspx", true);
        }

        protected void Button_RedirectToListUV(object sender, EventArgs e)
        {
            RedirectToListUV();
        }
    }
}