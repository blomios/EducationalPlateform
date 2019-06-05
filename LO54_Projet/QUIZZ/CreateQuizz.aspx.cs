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

namespace LO54_Projet.QUIZZ
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private bool first;
        private UVDb myUvDb = new UVDb();
        private List<UV> linkedUvs = new List<UV>();
        private int questionsCreated;
        const string VIEWSTATEKEY_DYNCONTROL = "DynamicControlSelection";
        private string DynamicControlSelection
        {
            get
            {
                string result = ViewState[VIEWSTATEKEY_DYNCONTROL].ToString();
                if (result == null)
                    // doing things like this lets us access this property without
                    // worrying about this property returning null/Nothing
                    return string.Empty;
                else
                    return result;
            }
            set
            {
                ViewState[VIEWSTATEKEY_DYNCONTROL] = value;
            }
        }
      

     
        protected void Page_Load(object sender, EventArgs e) 
        {

            if (!IsPostBack) // la page ne se recharge pas
            {
                init();
            }
            else // la page se recharge
            {
                makePostBackControls();              
            }


        }

        private void makePostBackControls()
        {
            string vsFirst = ViewState["first"].ToString();
            Boolean.TryParse(vsFirst, out first);
            if (first)
            {
                questionsCreated =0;
            }
            else questionsCreated = Convert.ToInt32(ViewState["questionsCreated"]);
            ViewState["first"] = Boolean.FalseString;
            if (questionsCreated > 0) createControls();
            
        }

        private void init()
        {
            ViewState["first"] = Boolean.TrueString;
            linkedUvs = myUvDb.getLinkedUvs(User.Identity.GetUserId());
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
            // d'abord un nouveau panel, pour pouvoir foutre ça au bon endroit :)
            Panel p = new Panel();
            p.ID = "Panel_Question_" + id;
            p.Attributes.CssStyle.Add("margin-bottom", "10px");
            // on le raccroche au conteneur
            panel_Questions_Container.Controls.Add(p);

            // Ensuite, un label, pour pas que l'utilisateur soit paumé 
            // on pourrait aussi mettre un placeholder dans la textbox, c est comme vous le sentez
            Label l = new Label();
            l.ID = "Label_Question_" + id;
            l.Text = "Enonce " + (id+1);
            p.Controls.Add(l);

            // Ensuite
            // nouvelle textbox
            TextBox t = new TextBox();
            t.Text = "Some random text just for fun" + id;
            t.Attributes["value"] = t.Text;
            t.TextMode = TextBoxMode.MultiLine;
            // pour avoir un rendu sympa :)
            t.CssClass = "form-control";

            t.ID = "TextBox_Question" + id;
            //t.EnableViewState = false;
            //t.ViewStateMode = ViewStateMode.Disabled;

            /*
                        < asp:RequiredFieldValidator runat = "server" ControlToValidate = "QuizzName"
                        CssClass = "text-danger" ErrorMessage = "Le champ nom est obligatoire." />
            Il faudra penser à rajouter ça tout de même :)
             */

            p.Controls.Add(t);
            // ENSUITE, réponses :D
            // On va créer un autre panel je pense 
            Panel pReps = new Panel();
            pReps.ID = "Reponses_Question_" + id;
            pReps.BorderStyle = BorderStyle.Solid;
            pReps.BorderWidth = 1;
            

            /* On créée au moins un champ de réponse*/
            p.Controls.Add(pReps);
            

            // on va créer 4 champs de réponse
            // et en afficher 1, quand l'utilisateur aura cliqué sur + on affichera le second, puis le troisième ... 
            // On va utiliser le viewState
            int numberOfRepsToBeShown = -1;
            int.TryParse(ViewState["reponseQuestion" + id.ToString()].ToString(), out numberOfRepsToBeShown) ;
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


            pReps.Controls.Add(addRep);
            // On va utiliser une autre fonction pourqu'a chaque fois que l'on clique sur le bouton
            // Un nouveau champ texte apparaisse 
            addRep.Click += (s,e)=> 
                    {
                        Button_Add_Rep_click(pReps);
                    };

            Button rmRep = new Button();
            rmRep.CssClass = "btn active";
            rmRep.ID = "btn_remRep_" + id; // l'id de la question
            rmRep.Text = "-";
            rmRep.CausesValidation = false;
            if (numberOfRepsToBeShown == 1) rmRep.Enabled = false;
            pReps.Controls.Add(rmRep);

            rmRep.Click += (s, e) =>
            {
                Button_Rem_Rep_click(pReps);
            };

            // Enfin
        }

        protected void Button_Add_Rep_click(Panel parent)
        {
            string questionID = parent.ID.Substring(18); // id du panel parent
            int numberOfShownAnswers = -1;
            string viewStateName = "reponseQuestion" + questionID;
            int.TryParse(ViewState[viewStateName].ToString(),out numberOfShownAnswers) ;
            if(numberOfShownAnswers<4) numberOfShownAnswers++;
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

        protected void addAnswer(Panel parent,int questionId, int answerId,bool visible)
        {
            TextBox tRep = new TextBox();
            tRep.Text = "Some random text just for fun rep" + answerId;
            tRep.Attributes["value"] = tRep.Text;
            tRep.TextMode = TextBoxMode.MultiLine;
            // pour avoir un rendu sympa :)
            tRep.CssClass = "form-control";

            tRep.ID = "TextBox_Question_Reponse_" + questionId + "_" + answerId;
            tRep.EnableViewState = true;
            tRep.ViewStateMode = ViewStateMode.Enabled;
            //tRep.EnableViewState = false;
            //tRep.ViewStateMode = ViewStateMode.Disabled;
            if (!visible) tRep.Visible = false;
            parent.Controls.Add(tRep);
        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            // cest une nouvelle question
            questionsCreated++;
            

            ViewState["questionsCreated"] = questionsCreated.ToString();
            ViewState["reponseQuestion" + (questionsCreated-1).ToString()] = 1;
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
    }
}