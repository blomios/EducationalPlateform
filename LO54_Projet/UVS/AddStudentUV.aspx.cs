using LO54_Projet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace LO54_Projet.UVS
{
    public partial class AddStudentUV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

        }
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                string prenom="";
                string nom="";
                string email;
                string pwd;
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    string line;
                    System.IO.StreamReader file =
                    new System.IO.StreamReader(Server.MapPath("~/") + filename);
                    while ((line = file.ReadLine()) != null)
                    {
                        Regex regex = new Regex(@"(?<=;)(\w*)(?=;)");
                        MatchCollection match = regex.Matches(line);
                        if (match.Count != 2){
                            continue;
                        }
                        int i = 0;
                        foreach (Match m in match)
                        {
                            if (i == 0) { prenom = m.Value; }
                            if (i == 1) { nom = m.Value; }
                            i++;
                        }
                        Regex rx = new Regex(@"(?<=;)(\w*)$");
                        Match mpwd = rx.Match(line);
                        var user = new ApplicationUser(nom,prenom ) ;
                        IdentityResult result = manager.Create(user,mpwd.Value );
                        if (result.Succeeded)
                        {
                            
                        }
                        else
                        {
                            ErrorMessage.Text = result.Errors.FirstOrDefault();
                        }
                    }

                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }   
        }
    }
}