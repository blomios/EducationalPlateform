using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Entities;
using LO54_Projet.Models;
using LO54_Projet.Repository;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class AddTeacherUV : System.Web.UI.Page
    {
        private static IdentityDb identityContext = IdentityDb.GetInstance();
        private static UVDb uvContext = UVDb.GetInstance();
        private UV cUV;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }

            string uvDenom = Request.Params.Get("uv");
            if (uvDenom != null && uvDenom != "")
            {
                cUV = uvContext.GetByDenomination(uvDenom);
            } 
            else
            {
                Response.Redirect("/Errors/403.aspx");
            }
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ApplicationUser user = identityContext.GetByEmailEager(Email.Text);
                if (user == null)
                {
                    ErrorMessage.Text = "Cet utilisateur n'existe pas";
                }
                else if (user.HasAccessToUV(cUV.IdUv))
                {
                    ErrorMessage.Text = "Cet utilisateur à déjà accès à cette UV";
                }
                else
                {
                    identityContext.AddSharedUV(user.Id, cUV.IdUv);
                    RedirectToUV();
                }
            }
        }

        protected void Button_Back(object sender, EventArgs e)
        {
            RedirectToUV();
        }

        private void RedirectToUV()
        {
            Response.Redirect("/UVS/DetailUV.aspx?uv=" + cUV.Denomination, true);
        }
    }
}