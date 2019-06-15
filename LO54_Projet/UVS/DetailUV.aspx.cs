using LO54_Projet.Controllers;
using LO54_Projet.Entities;
using LO54_Projet.Models;
using LO54_Projet.Repository;
using System;
using System.Web;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.UVS
{
    public partial class DetailUV : System.Web.UI.Page
    {
        private static UVDb uvContext = UVDb.GetInstance();
        private static IdentityDb userContext = new IdentityDb();
        private UV cUV;
        private DownloadFile fileController;

        protected void Page_Load(object sender, EventArgs e)
        {
            cUV = uvContext.GetByDenomination(Request.Params.Get("uv"));

            if (!Context.User.IsInRole(UserType.Teacher.ToString()))
            {
                Uploadfile1.Visible = false;
            }
            else
                Uploadfile1.Visible = true;

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

            // check if owner for edit button
            Button_Update_UV.Visible = Context.User.Identity.GetUserId() == cUV.Owner;
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
    }
}