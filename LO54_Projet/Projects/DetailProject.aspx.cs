using LO54_Projet.Controllers;
using LO54_Projet.Entities;
using LO54_Projet.Models;
using LO54_Projet.Repository;
using System;
using System.Web;
using Microsoft.AspNet.Identity;
using LO54_Projet.Tools;

namespace LO54_Projet.UVS
{
    public partial class DetailProject : System.Web.UI.Page
    {
        private static ProjectDb projectContext = ProjectDb.GetInstance();
        private static UVDb uvContext = UVDb.GetInstance();
        private static IdentityDb userContext = new IdentityDb();
        private Project cProject;
        private DownloadFile fileController;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cProject = projectContext.GetById(int.Parse(Request.Params.Get("project")));

                Page.Title = "Project: " + cProject.Name;
                LB_Owner.Text = userContext.GetUsername(cProject.OwnerId);
                LB_Desc.Text = cProject.Description;
                Uploadfile1.id = cProject.IdProject;
                Uploadfile1.fileType = FileType.Project;
            }
            catch (Exception)
            {
                Response.Redirect("/Errors/403.aspx");
            }

            //Uploadfile1.Visible = Context.User.IsInRole(UserType.Teacher.ToString());

            var context = new IdentityDb();
            //Uploadfile1.Visible = context.GetUserRole(Context.User.Identity.GetUserId()) == CustomRoles.roles.Prof.ToString();

            if (cProject == null)
            {
                Response.Redirect("/Errors/403.aspx");
            }
            // else

            showFileList();

            // check if owner for edit button
            Button_Update.Visible = Context.User.Identity.GetUserId() == cProject.OwnerId;
        }

        private void showFileList()
        {
            var context = new FileDb();
            foreach (File f in context.Files)
            {

                if (f.idUv == cProject.IdProject && f.fileType == FileType.Project)
                {
                    showFile(f);
                }
            }
        }

        private void showFile(File file)
        {
            fileController = (DownloadFile)Page.LoadControl("~/Controllers/DownloadFile.ascx");

            fileController.fileName = file.Name;
            fileController.filePath = file.FilePath;
            fileController.fileID = file.IdFile;
            fileController.setFileName(file.Name);
            FileList.Controls.Add(fileController);
        }
        
        protected void Button_RedirectToDetailUV_Click(object sender, EventArgs e)
        {
            string uv = uvContext.GetById(cProject.IdUV).Denomination;
            Response.Redirect("/UVS/DetailUV.aspx?uv=" + uv, true);
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Projects/FormProject.aspx?uv=" + cProject.IdUV + "&project=" + cProject.IdProject, true);
        }
    }
}