using LO54_Projet.Controllers;
using LO54_Projet.Entities;
using LO54_Projet.Repository;
using LO54_Projet.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.QUIZZ
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        QuestionQuizzForm questionModel;
        static List<QuestionQuizzForm> quiestionsQuizz = new List<QuestionQuizzForm>();

        override protected void OnInit(EventArgs e)
        {
            foreach (QuestionQuizzForm q in quiestionsQuizz)
            {
                Panel2.Controls.Add(q);
            }
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("je suis ici");
                questionModel =
                (QuestionQuizzForm)LoadControl("/Controllers/QuestionQuizzForm.ascx");
                questionModel.ID = quiestionsQuizz.Count.ToString() + "question";
                //Adding user control inside the form element.
                quiestionsQuizz.Add(questionModel);

                this.Response.Redirect(Request.RawUrl);
           
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
           saveQuizz();

        }

        protected void rptreceipt_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


        void saveQuizz()
        {

            var context = new QuizzDb(); // Uv db c'est la classe qui correspond à la table en bd

            List<Question> questions = new List<Question>();
            AnswereType answereType;
            Question question;

            foreach(QuestionQuizzForm q in Panel2.Controls.OfType<QuestionQuizzForm>())
            {
                string name = "";
                List<Answer> answeres = new List<Answer>();
                answereType = AnswereType.QCM;

                foreach(AnswereForm a in q.Controls.OfType<AnswereForm>())
                {
                    
                    foreach(Control c in a.Controls)
                    {
                        string answereName;
                        bool isGoodAnswere;

                        if(c.ID == "AnswereText")
                        {
                            answereName = ((TextBox) c).Text;
                        }
                        else if(c.ID == "GoodAnswereCheckBox")
                        {
                            isGoodAnswere = ((CheckBox)c).Checked;
                        }
                    }
                }

                foreach(Control c in q.Controls.OfType<TextBox>())
                {
                    if(c.ID == "QuestionText")
                    {
                        name = ((TextBox)c).Text;
                    }
                }

                //question = new Question(name, answeres.ToArray(), answereType);
               // questions.Add(question);
            }

            //Quizz quizz = new Quizz(QuizzName.Text, questions.ToArray()); // On créé un nouveau quizz
           // context.Quizzes.Add(quizz);
            context.SaveChanges(); // On sauvegarde les changements

        //    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        //    /* ATTENTION :                                                                                     */
        //    /*                                                                                                 */
        //    /* POUR QUE LES CHANGEMENTS SOIENT PRIS EN COMPTE :                                                */
        //    /* Il faut que le fichier LO54_DB.mdf du dossier "App_Data"                                        */
        //    /* ait dans la propriété : Copier dans le répertoire de sortie ----> Copier si plus récent         */
        //    /*                                                                                                 */
        //    /*                                                                                                 */
        //    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

            refresh();
        }

        private void refresh()
        {
            this.Response.Redirect(Request.RawUrl);
        }
    }
}