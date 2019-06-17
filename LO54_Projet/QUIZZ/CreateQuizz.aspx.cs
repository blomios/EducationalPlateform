using LO54_Projet.Entities;
using LO54_Projet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Data.Entity.Validation;

namespace LO54_Projet.QUIZZ
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private bool first;
        private UVDb myUvDb = UVDb.GetInstance();
        private List<UV> linkedUvs = new List<UV>();
        private int questionsCreated;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) // la page ne se recharge pas
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                successDiv.Visible = false;
                init();
            }
            else // la page se recharge
            {
                makePostBackControls();
            }


        }

        private void makePostBackControls()
        {

            if (ViewState["first"] == null)
            {
                first = true;
                questionsCreated = 0;
            }
            else
            {
                string vsFirst = ViewState["first"].ToString();
                Boolean.TryParse(vsFirst, out first);
                if (first)
                {
                    questionsCreated = 0;
                    successDiv.Visible = false;
                }
                else questionsCreated = Convert.ToInt32(ViewState["questionsCreated"]);
            }
            
            ViewState["first"] = Boolean.FalseString;
            if (questionsCreated > 0) createControls();
        }

        private void init()
        {
            ViewState["first"] = Boolean.TrueString;
            linkedUvs = myUvDb.GetLinkedUvs(User.Identity.GetUserId());
            if (linkedUvs.Count > 0)
            {
                RadioButtonList_ChoixUV.Items.Clear();
                foreach (UV u in linkedUvs)
                {
                    RadioButtonList_ChoixUV.Items.Add(u.Denomination);
                }
            }
        }

        private void createControls()
        {
            panel_Questions_Container.Controls.Clear();
            for (int i = 0; i < questionsCreated; i++)
            {
                createQuestion(i);
            }
        }

        private void createQuestion(int id)
        {
            // d'abord un nouveau panel, pour pouvoir mettre ça au bon endroit :)
            Panel p = new Panel();
            p.ID = "Panel_Question_" + id;
            p.Attributes.CssStyle.Add("margin-bottom", "10px");
            

            // Ensuite, un label, pour pas que l'utilisateur soit paumé 
            Label l = new Label();
            l.ID = "Label_Question_" + id;
            l.Text = "Enoncé " + (id + 1);
            l.Font.Size = 14;
            l.Font.Bold = true;

            // Ensuite
            // nouvelle textbox
            TextBox t = new TextBox();
            //t.Text = "Some random text just for fun" + id;
            t.Attributes.Add("placeholder", "Ecrivez votre question ici ...");
            t.Attributes["value"] = t.Text;
            t.TextMode = TextBoxMode.MultiLine;
            // pour avoir un rendu sympa :)
            t.CssClass = "form-control";

            t.ID = "TextBox_Question" + id;
            t.Attributes.CssStyle.Add("margin-bottom", "10px");

            // Le text validator
            RequiredFieldValidator rfv = new RequiredFieldValidator();
            rfv.ID = "requiredFieldValidator_Enonce_" + id;
            rfv.ControlToValidate = t.ID;
            rfv.CssClass = "text-danger";
            rfv.ErrorMessage = "L'énoncé de la question " + (id + 1) + " est vide";
            rfv.Display = ValidatorDisplay.Dynamic;


            // ENSUITE, réponses :D
            // On va créer un autre panel je pense 
            Panel pReps = new Panel();
            pReps.ID = "Reponses_Question_" + id;
            
            /* On créée au moins un champ de réponse*/
            // on va créer 4 champs de réponse
            // et en afficher 1, quand l'utilisateur aura cliqué sur + on affichera le second, puis le troisième ... 
            // On va utiliser le viewState
            int numberOfRepsToBeShown = -1;
            int.TryParse(ViewState["reponseQuestion" + id.ToString()].ToString(), out numberOfRepsToBeShown);
            for (int i = 0; i < 4; i++)
            {
                if (i < numberOfRepsToBeShown)
                {
                    addAnswer(pReps, id, i, true);
                }
                else addAnswer(pReps, id, i, false);
            }

            // Et ensuite, on ajoute un boutton pour ajouter des réponses :D
            Button addRep = new Button();
            addRep.CssClass = "btn active";
            addRep.ID = "btn_addRep_" + id; // l'id de la question
            addRep.Text = "+";
            addRep.CausesValidation = false;
            if (numberOfRepsToBeShown == 4) addRep.Enabled = false;


            // On va utiliser une autre fonction pourqu'a chaque fois que l'on clique sur le bouton
            // Un nouveau champ texte apparaisse 
            addRep.Click += (s, e) =>
            {
                Button_Add_Rep_click(pReps);
            };

            Button rmRep = new Button();
            rmRep.CssClass = "btn active";
            rmRep.ID = "btn_remRep_" + id; // l'id de la question
            rmRep.Text = "-";
            rmRep.CausesValidation = false;
            if (numberOfRepsToBeShown == 1) rmRep.Enabled = false;

            rmRep.Click += (s, e) =>
            {
                Button_Rem_Rep_click(pReps);
            };


            Literal hr = new Literal() { ID = "hr_" + id, Text = "<hr size='1' color='black'/>" };
            panel_Questions_Container.Controls.Add(p);
            p.Controls.Add(l);
            p.Controls.Add(t);
            p.Controls.Add(rfv);
            p.Controls.Add(hr);
            p.Controls.Add(pReps);
            pReps.HorizontalAlign = HorizontalAlign.Left;
            pReps.Controls.Add(addRep);
            pReps.Controls.Add(rmRep);
            // Enfin
        }

        protected void Button_Add_Rep_click(Panel parent)
        {
            string questionID = parent.ID.Substring(18); // id du panel parent
            int numberOfShownAnswers = -1;
            string viewStateName = "reponseQuestion" + questionID;
            int.TryParse(ViewState[viewStateName].ToString(), out numberOfShownAnswers);
            if (numberOfShownAnswers < 4) numberOfShownAnswers++;
            ViewState[viewStateName] = numberOfShownAnswers.ToString();
            forcePostBack();
        }

        protected void Button_Rem_Rep_click(Panel parent)
        {
            string questionID = parent.ID.Substring(18); // id du panel parent
            int numberOfShownAnswers = -1;
            string viewStateName = "reponseQuestion" + questionID;
            int.TryParse(ViewState[viewStateName].ToString(), out numberOfShownAnswers);
            if (numberOfShownAnswers > 1) numberOfShownAnswers--;
            ViewState[viewStateName] = numberOfShownAnswers.ToString();
            forcePostBack();
        }

        protected void addAnswer(Panel parent, int questionId, int answerId, bool visible)
        {
            Label lbRep = new Label();
            //lbRep.ID = "label_Question_" + questionId + "_Reponse_" + answerId;
            lbRep.Text = "Réponse " + (answerId + 1);
            lbRep.Font.Size = 12;
            lbRep.Font.Bold = true;

            TextBox tRep = new TextBox();
            //tRep.Text = "Some random text just for fun rep" + answerId;

            tRep.Attributes.Add("placeholder", "Ecrivez votre réponse ici ...");
            tRep.Attributes["value"] = tRep.Text;
            tRep.TextMode = TextBoxMode.MultiLine;
            // pour avoir un rendu sympa :)
            tRep.CssClass = "form-control";

            tRep.ID = "TextBox_Question_Reponse_" + questionId + "_" + answerId;
            tRep.EnableViewState = true;
            tRep.ViewStateMode = ViewStateMode.Enabled;

            // Field validator
            RequiredFieldValidator rfv = new RequiredFieldValidator();
            rfv.ID = "requiredFieldValidator_Question_" + questionId + "_Answer_" + answerId;
            rfv.ControlToValidate = tRep.ID;
            rfv.CssClass = "text-danger";
            rfv.ErrorMessage = "La réponse "+(answerId+1)+" de la question "+ (questionId+1) +" est vide";
            rfv.Attributes.Add("runat", "server");
            rfv.Display = ValidatorDisplay.Dynamic;

            // Puis la checkbox (pour chaque réponse, faut savoir si elle est vraie ou non)
            CheckBox isGoodAnswer = new CheckBox();
            isGoodAnswer.CssClass = "checkbox";
            isGoodAnswer.ID = "chb_isGood_" + questionId + "_" + answerId;
            isGoodAnswer.Text = "Bonne réponse";
            isGoodAnswer.Attributes.CssStyle.Add("margin-left", "21px");
            isGoodAnswer.TextAlign = TextAlign.Right;
            //isGoodAnswer.LabelAttributes.Add("display", "inline-block!important");
            isGoodAnswer.CausesValidation = false;

            if (!visible)
            {
                isGoodAnswer.Visible = false;
                tRep.Visible = false;
                lbRep.Visible = false;
                rfv.Visible = false;
            }
         
            
            parent.Controls.Add(lbRep);
            parent.Controls.Add(tRep);
            parent.Controls.Add(rfv);
            parent.Controls.Add(isGoodAnswer);
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            // cest une nouvelle question
            questionsCreated++;


            ViewState["questionsCreated"] = questionsCreated.ToString();
            ViewState["reponseQuestion" + (questionsCreated - 1).ToString()] = 1;
            foreach (Control ctrl in panel_Questions_Container.Controls)
            {
                foreach (Control ct in ctrl.Controls)
                {
                    if (ct is TextBox)
                    {
                        TextBox mt = (TextBox)ct;
                        mt.Attributes["value"] = mt.Text;
                    }
                }
            }
            forcePostBack();
        }

        protected void Button_Rem_Click(object sender, EventArgs e)
        {
            // cest une question de moins
            questionsCreated--;

            ViewState["questionsCreated"] = questionsCreated.ToString();
            foreach (Control ctrl in panel_Questions_Container.Controls)
            {
                foreach (Control ct in ctrl.Controls)
                {
                    if (ct is TextBox)
                    {
                        TextBox mt = (TextBox)ct;
                        mt.Attributes["value"] = mt.Text;
                    }
                }
            }
            forcePostBack();
        }

        private void forcePostBack()
        {
            StringBuilder sbScript = new StringBuilder();

            sbScript.Append("<script language='JavaScript' type='text/javascript'>\n");
            sbScript.Append("<!--\n");
            sbScript.Append(GetPostBackEventReference(this, "PBArg") + ";\n");
            sbScript.Append("// -->\n");
            sbScript.Append("</script>\n");

            RegisterStartupScript("AutoPostBackScript", sbScript.ToString());
        }

        protected void Button_Creer_UV_Click(object sender, EventArgs e)
        {
            List<Panel> panes = new List<Panel>();
            //On va parcourir chaque panel de question
            foreach (Control ctrl in panel_Questions_Container.Controls)
            {
                if (ctrl.ID != null)
                {
                    if (ctrl.ID.Contains("Panel_Question_")) // on a à faire a un panel contenant questions + Réponses
                    {
                        Panel pane = (Panel)ctrl;
                        if (!panes.Contains(pane)) panes.Add(pane);
                    }
                }
            }


            // on a récupéré les panels des questions/réponses
            // on va les parcourir, pour créer en même temps question ET réponse
            int id = -1;
            bool hasOne=false;

            UVDb uvs = new UVDb();
            int selectedUv = uvs.UVs.First(u =>
                                        u.Denomination == this.RadioButtonList_ChoixUV.SelectedItem.Value).IdUv;

            Quizz q = new Quizz(QuizzName.Text.Trim(),selectedUv);

            List<Question> questions = new List<Question>();

            foreach (Panel p in panes)
            {
                string questionID = p.ID.Substring(15);
                int.TryParse(questionID, out id); // On a récupéré l'id de la question

                //la textbox de la question
                TextBox tbQuestion = p.FindControl("TextBox_Question" + id) as TextBox;


                // On va créer des questions et des réponses
                Question question = new Question(q, tbQuestion.Text, AnswereType.QCM);

                // les textbox / checkbox des réponses :
                // C est ce panel qui contient les questions
                Panel pReps = p.FindControl("Reponses_Question_" + id) as Panel;

                List<TextBox> answers = new List<TextBox>();
                List<CheckBox> isAnswer = new List<CheckBox>();
                // On va le parcourir, et trouver les textbox réponses contenues qui ne sont pas "hidden"
                // Ainsi que les checkBox "bonne rép"
                foreach (Control ctrl in pReps.Controls)
                {
                    if (ctrl.ID != null)
                    {
                        // On récupère par l'ID
                        //  tRep.ID = "TextBox_Question_Reponse_" + questionId + "_" + answerId;
                        if (ctrl.ID.Contains("TextBox_Question_Reponse_" + id))
                        {
                            // C est une des réponses
                            TextBox tRep = (TextBox)ctrl;
                            if (tRep.Visible)
                            {
                                if (!answers.Contains(tRep)) answers.Add(tRep);
                            }
                        }
                        else if (ctrl.ID.Contains("chb_isGood_" + id))
                        {
                            // C est une checkbox
                            CheckBox cbRep = (CheckBox)ctrl;
                            if (cbRep.Visible)
                            {
                                if (!isAnswer.Contains(cbRep)) isAnswer.Add(cbRep);
                            }
                        }
                    }
                }

                // On a maintenant toutes les réponses pour la question en cours 
                // il faut vérifier qu'on a au moins une "bonne réponse" pour la dite question en cours
                hasOne = false;
                foreach (CheckBox cb in isAnswer)
                {
                    if (cb.Checked)
                    {
                        hasOne = true;
                        break;
                    }
                }

                // On a au moins une bonne rép
                if (hasOne)
                {

                    foreach (TextBox rep in answers)
                    {
                        // on récupére l'id de la réponse
                        // tRep.ID = "TextBox_Question_Reponse_" + questionId + "_" + answerId;
                        int offset = 25 + id.ToString().Length + 1;
                        int reponseId = -1;
                        string answerId = rep.ID.Substring(offset);
                        int.TryParse(answerId, out reponseId);

                        // Ensuite on regarde si c est une bonne réponse ou non
                        bool isGoodAnswer = isAnswer.First(cb =>
                                                            cb.ID.Equals("chb_isGood_" + id + "_" + answerId)).Checked;
                        // Ce code est censé faire : 
                        // Parmi les checkbox je récupère le premier dont l'id vaut : cb.ID.Equals("chb_isGood_" + id + "_" + answerId
                        // Et j'attribue sa valeur "Checked" à "isGoodAnswer"

                        // On peut maintenant créer la réponse
                        Answer answere = new Answer(rep.Text, isGoodAnswer);
                        question.OtherAnsweres.Add(answere);
                        
                    }

                }
                else
                {
                    Label_manqueRep.Visible = true;
                    break;
                }

                questions.Add(question);
            } // end for each

            if (hasOne)
            {
                Label_manqueRep.Visible = false;
                q.Questions = questions;
                QuizzDb qdb = new QuizzDb();
                qdb.Quizzes.Add(q);

                try
                {
                    Console.WriteLine("-------------------- HEEEEEREEEEEEEEEE ------------------------");
                    qdb.Database.Log = Console.WriteLine;
                    qdb.SaveChanges();
                    successDiv.Visible = true;
                    clearUi();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        private void clearUi()
        {
            ViewState.Clear();
            questionsCreated = 0;
            QuizzName.Text = "";
            RadioButtonList_ChoixUV.ClearSelection();
            forcePostBack();
        }

        protected void Button_Back(object sender, EventArgs e)
        {
            string url = ViewState["RefUrl"] == null ? "listUV.aspx" : (string)ViewState["RefUrl"];
            Response.Redirect(url, true);
        }
    }

}