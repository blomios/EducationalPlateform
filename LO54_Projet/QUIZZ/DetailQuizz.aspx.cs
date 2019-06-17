using LO54_Projet.Entities;
using LO54_Projet.Models;
using LO54_Projet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace LO54_Projet.QUIZZ
{
    public partial class DetailQuizz : System.Web.UI.Page
    {
        private static UVDb uvContext = UVDb.GetInstance();
        private UV linkedUv;

        private static IdentityDb identityContext = IdentityDb.GetInstance();
        private ApplicationUser user;
        private bool isProf = false;

        private static QuizzDb quizzContext = QuizzDb.GetInstance();
        private Quizz cQuizz;


        protected void Page_Load(object sender, EventArgs e)
        {
            cQuizz = quizzContext.GetByIdStringEager(Request.Params.Get("quizz"));
            linkedUv = uvContext.GetById(cQuizz.IdUv);
            user = identityContext.GetById(Context.User.Identity.GetUserId());

            isProf = user.Role.Equals("Prof");
            Button_Rep_Quizz.Enabled = !isProf;

            setQuizzInfos();


            int count = 1;
            foreach (Question question in cQuizz.Questions)
            {
                string questionNumber = count.ToString();
                setQuestion(panel_Questions_Container, question,questionNumber);
                count++; 
            }
        }

        private void setQuizzInfos()
        {
            QuizzName.Text = cQuizz.Name;
            RadioButtonList_ChoixUV.Items.Add(linkedUv.Denomination);
            RadioButtonList_ChoixUV.Items[0].Selected = true;
        }

        private void setQuestion(Panel parent, Question q,string numQuestion)
        {
            // d'abord un nouveau panel, pour pouvoir mettre ça au bon endroit :)
            Panel p = new Panel();
            p.ID = "Panel_Question_" + q.IdQuestion;
            p.Attributes.CssStyle.Add("margin-bottom", "10px");


            // Ensuite, un label, pour pas que l'utilisateur soit paumé 
            Label l = new Label();
            l.ID = "Label_Question_" + (q.IdQuestion+1);
            l.Text = "Enoncé " + numQuestion;
            l.Font.Size = 14;
            l.Font.Bold = true;

            // Ensuite
            // nouvelle textbox
            TextBox t = new TextBox();
            t.Text = q.Enonce;
            t.Enabled = false;
            t.Attributes["value"] = t.Text;
            t.TextMode = TextBoxMode.MultiLine;
            t.CssClass = "form-control";

            t.ID = "TextBox_Question" + (q.IdQuestion + 1);
            t.Attributes.CssStyle.Add("margin-bottom", "10px");

            // ENSUITE, réponses :D
            // On va créer un autre panel je pense 
            Panel pReps = new Panel();
            pReps.ID = "Reponses_Question_" + (q.IdQuestion + 1);

            int countAnswer = 1;
            foreach (Answer answer in q.OtherAnsweres)
            {
                setAnswer(pReps, answer,countAnswer.ToString());
                countAnswer++;
            }
            
            Literal hr = new Literal() { ID = "hr_" + (q.IdQuestion + 1), Text = "<hr size='1' color='black'/>" };
            panel_Questions_Container.Controls.Add(p);
            p.Controls.Add(l);
            p.Controls.Add(t);
            p.Controls.Add(hr);
            p.Controls.Add(pReps);
            pReps.HorizontalAlign = HorizontalAlign.Left;
        }

        private void setAnswer(Panel parent, Answer a,string numReponse)
        {
            Label lbRep = new Label();
            int answerId = a.IdAnswere;
            lbRep.Text = "Réponse " + numReponse;
            lbRep.Font.Size = 12;
            lbRep.Font.Bold = true;

            TextBox tRep = new TextBox();
            tRep.Text = a.answere;            
            tRep.Attributes["value"] = tRep.Text;
            tRep.Enabled = false;
            tRep.TextMode = TextBoxMode.MultiLine;
            // pour avoir un rendu sympa :)
            tRep.CssClass = "form-control";

            tRep.ID = "TextBox_Question_Reponse_" + a.questionRelated + "_" + answerId;
            tRep.EnableViewState = true;
            tRep.ViewStateMode = ViewStateMode.Enabled;
            

            // Puis la checkbox (pour chaque réponse, faut savoir si elle est vraie ou non)
            CheckBox isGoodAnswer = new CheckBox();
            isGoodAnswer.CssClass = "checkbox";
            isGoodAnswer.ID = "chb_isGood_" + a.questionRelated + "_" + answerId;
            isGoodAnswer.Text = "Bonne réponse";
            isGoodAnswer.Attributes.CssStyle.Add("margin-left", "21px");
            isGoodAnswer.TextAlign = TextAlign.Right;
            isGoodAnswer.Enabled = !isProf;
            if(isProf)
                isGoodAnswer.Checked = a.isGoodAnswere;
            else
                isGoodAnswer.Checked = false;

            isGoodAnswer.CausesValidation = false;


            parent.Controls.Add(lbRep);
            parent.Controls.Add(tRep);
            parent.Controls.Add(isGoodAnswer);
        }

        protected void Button_Rep_Quizz_Click(object sender, EventArgs e)
        {
            int score = 0;
            int nbQuestions = cQuizz.Questions.Count;
            bool allGood = true;
            foreach (Question question in cQuizz.Questions)
            {
                Panel pQuestion = panel_Questions_Container.FindControl("Panel_Question_" + question.IdQuestion) as Panel;
                foreach (Answer answer in question.OtherAnsweres)
                {
                    CheckBox cbAnswer = pQuestion.FindControl("chb_isGood_" + question.IdQuestion + "_" + answer.IdAnswere) as CheckBox;
                    allGood = (cbAnswer.Checked == answer.isGoodAnswere);
                    if (!allGood) break;
                }
                if (allGood) score++;
            }


            ApplicationUser user = identityContext.GetByIdEager(User.Identity.GetUserId());
            if (user != null)
            {
                identityContext.addQuizzTaken(user.Id, cQuizz.IdQuizz, score, nbQuestions);
            }

            labelScore.Text = "Score final : "+score+"/"+nbQuestions;
            labelScore.Visible = true;
        }

        protected void Button_Ret_Click(object sender, EventArgs e)
        {
            UV uV = uvContext.GetById(cQuizz.IdUv);
            RedirectToUV(uV.Denomination);
        }

        private void RedirectToUV(string uvDenom)
        {
            Response.Redirect("/UVS/DetailUV.aspx?uv=" + uvDenom, true);
        }
    }
}