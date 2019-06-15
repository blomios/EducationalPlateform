using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LO54_Projet.Entities;
using LO54_Projet.Repository;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class FormProject : System.Web.UI.Page
    {

        private static UVDb uvContext = UVDb.GetInstance();
        private static ProjectDb projectContext = ProjectDb.GetInstance();
        private Project cProject;
        private UV cUV;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }

            try
            {
                cUV = uvContext.GetById(int.Parse(Request.Params.Get("uv")));
                string projectId = Request.Params.Get("project");

                if (projectId != null && projectId != "")
                { 
                    cProject = projectContext.GetById(int.Parse(projectId));

                    // prevent from executing the following code when a button is clicked on the page (like "save" for example)
                    if (!IsPostBack)
                    {
                        Name.Text = cProject.Name;
                        Description.Text = cProject.Description;
                    }
                }
            }
            catch
            {
                Response.Redirect("/Errors/403.aspx", true);
            }
        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Project project = new Project();
                project = new Project(Name.Text, Description.Text, User.Identity.GetUserId(), cUV.IdUv);
                project.IdProject = cProject != null ? cProject.IdProject : 0;
                
                ErrorMessage.Text = "";
                projectContext.SaveOrUpdate(project);
                Response.Redirect("/UVS/DetailUV.aspx?uv=" + cUV.Denomination, true);
            }
        }

        protected void Button_Back(object sender, EventArgs e)
        {
            string url = ViewState["RefUrl"] == null ? "/UVS/DetailUV.aspx?uv=" + cUV.Denomination : (string)ViewState["RefUrl"];
            Response.Redirect(url, true);
        }

        protected void CustomValidatorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ErrorMessage.Text = "";
            args.IsValid = (args.Value.Length != 0);
        }

        protected void CustomValidatorDescription_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ErrorMessage.Text = "";
            args.IsValid = (args.Value.Length != 0);
        }
    }
}