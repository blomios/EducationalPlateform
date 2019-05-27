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
    public partial class AddUV : System.Web.UI.Page
    {

        protected void Button_Creer_UV_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var context = new UVDb(); // Uv db c'est la classe qui correspond à la table en bd 
                UV uv = new UV();
                using (var identityDbContext = new IdentityDb())
                {
                    uv = new UV(Denomination.Text, Description.Text, identityDbContext.getUserMail(User.Identity.GetUserId())); // On créé une nouvelle UV
                }

                if (context.UVs.Any(o => o.Denomination == Denomination.Text))
                {
                    ErrorMessage.Text = "Cette UV existe déjà !";
                }
                else
                {
                    ErrorMessage.Text = "";
                    context.UVs.Add(uv); // On l'ajoute à la liste d'uv de UVDB
                    context.SaveChanges(); // On sauvegarde les changements
                    RedirectToListUV();
                }
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