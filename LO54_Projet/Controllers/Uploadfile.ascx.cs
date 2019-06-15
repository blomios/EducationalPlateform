using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
        public int id;
        public FileType fileType;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Files is folder Name
            if (Page.IsValid)
            {
                Guid guid = Guid.NewGuid();
                fuSample.SaveAs(Server.MapPath("~") + "/DataDirectory/" + guid + "_"+ fuSample.FileName);
                lblMessage.Text = "File Successfully Uploaded";
                lblMessage.ForeColor = System.Drawing.Color.FromArgb(54, 204, 43);


                var context = new FileDb(); // Uv db c'est la classe qui correspond à la table en bd 
                File file = new File(fuSample.FileName, Server.MapPath("~") + "/DataDirectory/" + guid + "_" + fuSample.FileName, id, fileType); // On créé une nouvelle UV
                
                lblMessage.Text = "";
                context.Files.Add(file); // On l'ajoute à la liste d'uv de UVDB
                try
                {
                    context.SaveChanges(); // On sauvegarde les changements
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                    {
                        // Get entry

                        DbEntityEntry entry = item.Entry;
                        string entityTypeName = entry.Entity.GetType().Name;

                        // Display or log error messages

                        foreach (DbValidationError subItem in item.ValidationErrors)
                        {
                            string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                        subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                            System.Diagnostics.Debug.WriteLine(message);
                        }
                    }
                }

                Response.Redirect(Request.RawUrl);

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
    }
}