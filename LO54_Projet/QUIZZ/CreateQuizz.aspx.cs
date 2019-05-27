using LO54_Projet.Entities;
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

            //IsPostBack -> On "Recharge" la page, on vient pas d'arriver dessus
            if (!IsPostBack)
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
            else // On recharge la page (-> Par exemple en ajoutant une question :D)
            {

                string vsFirst = ViewState["first"].ToString();
                Boolean.TryParse(vsFirst, out first);
                if (first)
                {
                    questionsCreated = 1;
                }
                else questionsCreated = Convert.ToInt32(ViewState["questionsCreated"]);
                ViewState["first"] = Boolean.FalseString;
                panel_Questions_Container.Controls.Clear();
                if (questionsCreated > 0) createControls();
               
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
            l.Text = "Enonce "+id;
            p.Controls.Add(l);

            // Ensuite
            // nouvelle textbox
            TextBox t = new TextBox();
            t.Text = "Some random label just for fun" + id;
            t.Attributes["value"] = t.Text;
            t.TextMode = TextBoxMode.MultiLine;
            // pour avoir un rendu sympa :)
            t.CssClass = "form-control";

            t.ID = "TextBox_Question" + id;

            /*
                        < asp:RequiredFieldValidator runat = "server" ControlToValidate = "QuizzName"
                        CssClass = "text-danger" ErrorMessage = "Le champ nom est obligatoire." />
            Il faudra penser à rajouter ça tout de même :)
             */

            p.Controls.Add(t);
            // ENSUITE, réponses :D
            // On va créer un autre panel je pense 
            Panel pReps = new Panel();
            pReps.ID = "Reponses_Question"+id;
            pReps.Attributes.CssStyle.Add("margin-top", "5px");
            pReps.BorderStyle = BorderStyle.Solid;
            pReps.BorderWidth = 1;
            p.Controls.Add(pReps);
            for (int i = 0; i < 4; i++)
            {
                TextBox tRep = new TextBox();
                tRep.Text = "Some random text just for fun rep" + i;
                tRep.Attributes["value"] = tRep.Text;
                tRep.TextMode = TextBoxMode.MultiLine;
                // pour avoir un rendu sympa :)
                tRep.CssClass = "form-control";
                tRep.Attributes.CssStyle.Add("margin-left", "5px");
                tRep.Attributes.CssStyle.Add("margin-bottom", "5px");
                tRep.Attributes.CssStyle.Add("margin-right", "5px");
                tRep.Attributes.CssStyle.Add("margin-top", "5px");

                tRep.ID = "TextBox_Question_Reponse" + id +"_"+i;
                pReps.Controls.Add(tRep);
            }

        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            // cest une nouvelle question
            questionsCreated++;

            //createQuestion(questionsCreated);

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
        }
    }
}