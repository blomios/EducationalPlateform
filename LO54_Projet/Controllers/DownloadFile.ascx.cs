using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using LO54_Projet.Repository;
using LO54_Projet.Models;
using Microsoft.AspNet.Identity;
using LO54_Projet.Tools;

namespace LO54_Projet.Controllers
{
    public partial class DownloadFile : System.Web.UI.UserControl
    {
        public string filePath;
        public string fileName;
        public int fileID;

        public void setFileName(string name)
        {
            NameFile.Text = name;
            fileName = name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new IdentityDb();
            if (!(context.GetUserRole(Context.User.Identity.GetUserId()) == CustomRoles.roles.Prof.ToString()))
            {
                Button2.Visible = false;
            }
            else
                Button2.Visible = true;
        }

        protected void GreetingBtn_Click(object sender, EventArgs e)
        {

            string extension = Path.GetExtension(filePath);

            switch(extension)
            {
                case ".html":
                    Response.ContentType = "text/HTML";
                    break;

                case ".htm":
                    Response.ContentType = "text/HTML";
                    break;

                case ".txt":
                    Response.ContentType = "text/plain";
                    break;

                case ".doc":
                    Response.ContentType = "Application/msword";
                    break;

                case ".rtf":
                    Response.ContentType = "Application/msword";
                    break;

                case ".docx":
                    Response.ContentType = "Application/msword";
                    break;

                case ".xls":
                    Response.ContentType = "Application/x-msexcel";
                    break;

                case ".xlsx":
                    Response.ContentType = "Application/x-msexcel";
                    break;

                case ".jpg":
                    Response.ContentType = "image/jpeg";
                    break;

                case ".jpeg":
                    Response.ContentType = "image/jpeg";
                    break;

                case ".gif":
                    Response.ContentType = "image/GIF";
                    break;

                case ".pdf":
                    Response.ContentType = "application/pdf";
                    break;

            }
            
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            
            var context = new FileDb(); // Uv db c'est la classe qui correspond à la table en bd  // On créé une nouvelle UV
            foreach(LO54_Projet.Entities.File f in context.Files)
            {
                if(f.IdFile == fileID)
                {
                    File.Delete(f.FilePath);
                    try
                    {
                        context.Files.Remove(f);
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("DELETE");
                    }
                }
            }

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
        }
    }
}