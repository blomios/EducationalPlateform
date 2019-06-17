using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Entities;
using LO54_Projet.Repository;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class FormUV : System.Web.UI.Page
    {

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

                // prevent from executing the following code when a button is clicked on the page (like "save" for example)
                if (!IsPostBack)
                {
                    Denomination.Text = cUV.Denomination;
                    Name.Text = cUV.Name;
                    Description.Text = cUV.Description;
                }
            }
        }

        protected void Button_Creer_UV_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UV uv = new UV();
                uv = new UV(Denomination.Text, Name.Text, Description.Text, User.Identity.GetUserId());
                uv.IdUv = cUV != null ? cUV.IdUv : 0;

                if (cUV != null || uvContext.GetByDenomination(Denomination.Text) == null)
                {
                    ErrorMessage.Text = "";
                    uvContext.SaveOrUpdate(uv);
                    Response.Redirect("/UVS/DetailUV.aspx?uv=" + Denomination.Text, true);
                } // else

                ErrorMessage.Text = "Cette UV existe déjà !";
                /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
                /* ATTENTION :                                                                                     */
                /*                                                                                                 */
                /* POUR QUE LES CHANGEMENTS SOIENT PRIS EN COMPTE :                                                */
                /* Il faut que le fichier LO54_DB.mdf du dossier "App_Data"                                        */
                /* ait dans la propriété : Copier dans le répertoire de sortie ----> Copier si plus récent         */
                /*                                                                                                 */
                /*                                                                                                 */
                /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

            }
        }

        protected void Button_Back(object sender, EventArgs e)
        {
            string url = ViewState["RefUrl"] == null ? "listUV.aspx" : (string)ViewState["RefUrl"];
            Response.Redirect(url, true);
        }

        // Validation de la dénomination de l'UV
        protected void CustomValidatorDenomination_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = UV.IsValidDenomination(args.Value);
            if (!args.IsValid)
            {
                ErrorMessage.Text = "";
            }
        }

        protected void CustomValidatorDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ErrorMessage.Text = "";
            args.IsValid = (args.Value.Length != 0);
        }
    }
}