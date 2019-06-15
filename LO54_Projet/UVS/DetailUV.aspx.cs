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
    public partial class DetailUV : System.Web.UI.Page
    {
        private static UVDb uvContext = UVDb.GetInstance();
        private static IdentityDb userContext = new IdentityDb();
        private UV cUV;
        private ListProjects projectController;
        private DownloadFile fileController;

        protected void Page_Load(object sender, EventArgs e)
        {
            cUV = uvContext.GetByDenomination(Request.Params.Get("uv"));

            var context = new IdentityDb();
            Uploadfile1.Visible = context.GetUserRole(Context.User.Identity.GetUserId()) == CustomRoles.roles.Prof.ToString();

            if (cUV == null)
            {
                Response.Redirect("/Errors/403.aspx");
            }
            // else

            Page.Title = cUV.Denomination + ": " + cUV.Name;
            LB_Owner.Text = userContext.GetUsername(cUV.Owner);
            LB_Desc.Text = cUV.Description;
            Uploadfile1.idUv = cUV.IdUv;

            showFileList();
            ShowProjectList();

            // check if owner for edit button
            Button_Update_UV.Visible = Context.User.Identity.GetUserId() == cUV.Owner;
        }

        private void ShowProjectList()
        {
            projectController = (ListProjects)Page.LoadControl("~/Projects/ListProjects.ascx");
            projectController.uvId = cUV.IdUv;
            projectController.clientScript = ClientScript;
            ProjectList.Controls.Add(projectController);
        }

        private void showFileList()
        {
            var context = new FileDb();
            foreach(File f in context.Files)
            {
                
                if (f.idUv == cUV.IdUv)
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
        
        protected void Button_RedirectToListUV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UVS/ListUV.aspx", true);
        }

        protected void Button_Update_UV_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UVS/FormUV.aspx?uv=" + cUV.Denomination, true);
        }


        protected void Button_Add_Project_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Projects/FormProject.aspx?uv=" + cUV.IdUv, true);
        }
    }
}