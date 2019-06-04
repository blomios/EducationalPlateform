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

namespace LO54_Projet.Controllers
{
    public partial class Uploadfile : System.Web.UI.UserControl
    {
        public UV uv;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Files is folder Name
            if (Page.IsValid)
            {

                try
                {
                    fuSample.SaveAs(Server.MapPath("~") + "/DataDirectory/" + fuSample.FileName);
                    lblMessage.Text = "File Successfully Uploaded";
                    lblMessage.ForeColor = System.Drawing.Color.FromArgb(54, 204, 43);


                    var context = new FileDb(); // File db c'est la classe qui correspond à la table en bd 
                    File file = new File();
                    using (var identityDbContext = new IdentityDb())
                    {
                        file = new File(fuSample.FileName, Server.MapPath("~") + "/DataDirectory/" + fuSample.FileName, uv); // On créé un nouveau fichier
                    }


                    context.SaveChanges(); // On sauvegarde les changements
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
                catch
                {
                    lblMessage.ForeColor = System.Drawing.Color.FromArgb(230, 12, 12);
                    lblMessage.Text = "Error";
                }
            }
        }
    }
}