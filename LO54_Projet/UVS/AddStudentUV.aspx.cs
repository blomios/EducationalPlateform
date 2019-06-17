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
using LO54_Projet.Repository;
using LO54_Projet.Entities;

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
                string prenom = "";
                string nom = "";
                //string email;
                //string pwd;
                System.IO.StreamReader file;
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    string line;
                    file =
                    new System.IO.StreamReader(Server.MapPath("~/") + filename);
                    IdentityDb id = new IdentityDb();
                    Regex rxc = new Regex(@"^([^.]+)(?=[.])");
                    Match mc = rxc.Match(filename);
                    UVDb u = new UVDb();
                    UV uv = u.GetByDenomination(mc.Value);
                    while ((line = file.ReadLine()) != null)
                    {
                        //continue;
                        Regex regex = new Regex(@"(?<=;)(\w*)(?=;)");
                        MatchCollection match = regex.Matches(line);
                        if (match.Count != 2)
                        {
                            continue;
                        }
                        int i = 0;
                        foreach (Match m in match)
                        {
                            if (i == 0) { prenom = m.Value; }
                            if (i == 1) { nom = m.Value; }
                            i++;
                        }
                        Regex rx = new Regex(@"(?:.(?<!;))+$");
                        Match mpwd = rx.Match(line);
                        Regex rxemail = new Regex(@"^([^;]+)(?=;)");
                        Match memail = rxemail.Match(line);



                        var user = new ApplicationUser(nom, prenom) { UserName = prenom + " " + nom, Email = memail.Value }; ;
                        if (id.Users.FirstOrDefault(usr => usr.UserName == user.UserName) == null)
                        {
                            IdentityResult result = manager.Create(user, mpwd.Value);
                            if (result.Succeeded)
                            {

                                id.AddSharedUV(user.Id, uv.IdUv);

                            }
                            else
                            {
                                ErrorMessage.Text = result.Errors.FirstOrDefault();

                            }
                        }
                        else
                        {
                            ApplicationUser us = id.Users.FirstOrDefault(usr => usr.UserName == user.UserName);
                            //if (!us.HasAccessToUV(uv.IdUv)){
                                id.AddSharedUV(us.Id, uv.IdUv);
                            //}
                            
                        }

                    }
                    file.Close();
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    
                }


            }
        }
        protected void Button_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("/Default");
        }
    }
}