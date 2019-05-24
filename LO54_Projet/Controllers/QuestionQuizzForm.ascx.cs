using LO54_Projet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.Controllers
{
    public partial class QuestionQuizzForm : System.Web.UI.UserControl
    {
        
        static List<AnswereForm> answereForms = new List<AnswereForm>();
        AnswereForm modelAnswere;

        override protected void OnInit(EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            foreach (AnswereForm a in answereForms)
            {
                Panel1.Controls.Add(a);
            }
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            modelAnswere =
            (AnswereForm)LoadControl("/Controllers/AnswereForm.ascx");
            modelAnswere.ID = answereForms.Count.ToString() + "answere" + ID + "question";
            //Adding user control inside the form element.
            answereForms.Add(modelAnswere);

            this.Response.Redirect(Request.RawUrl);
        }

        /*
        public Question getQuestion()
        {
            string questionText = QuestionText.Text;
            List<Answere> answeres = new List<Answere>();

            foreach(AnswereForm a in answereForms)
            {
                answeres.Add(a.getAnswere());
            }

            //Question question = new Question(questionText, answeres.ToArray(), AnswereTypeForm1.GetSelectedAnswereType());
            return question;
        }*/
    }
}