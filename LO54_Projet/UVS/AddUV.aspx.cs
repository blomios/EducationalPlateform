using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Entities;
using LO54_Projet.Services;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class AddUV : System.Web.UI.Page
    {

        private static UVService uvService = new UVService();

        protected void Button_Creer_UV_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UV uv = new UV();
                uv = new UV(Denomination.Text, Description.Text, User.Identity.GetUserId());

                if (uvService.getByDenomination(Denomination.Text) == null)
                {
                    ErrorMessage.Text = "";
                    uvService.save(uv);
                    RedirectToListUV();
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

        private void RedirectToListUV()
        {
            Response.Redirect("/UVS/ListUV.aspx", true);
        }

        protected void Button_RedirectToListUV(object sender, EventArgs e)
        {
            RedirectToListUV();
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