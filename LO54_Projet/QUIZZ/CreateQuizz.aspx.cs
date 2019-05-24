using LO54_Projet.Entities;
using LO54_Projet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.QUIZZ
{
    public partial class WebForm2 : System.Web.UI.Page
    {
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
        private bool create = true;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                linkedUvs = myUvDb.getLinkedUvs(User.Identity.Name);
                if (linkedUvs.Count > 0)
                {
                    RadioButtonList_ChoixUV.Items.Clear();
                    foreach (UV u in linkedUvs)
                    {
                        RadioButtonList_ChoixUV.Items.Add(u.Denomination);
                    }
                }
            }
            else
            {
                create = false;
                questionsCreated = Convert.ToInt32(ViewState["questionsCreated"]);
                panel_Questions_Container.Controls.Clear();
                for (int i = 0; i < questionsCreated; i++)
                {
                    createQuestion(i);
                }
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
            t.Text = "Some random text just for fun" + id;
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

            p.Controls.Add(pReps);
            for (int i = 0; i < 4; i++)
            {
                TextBox tRep = new TextBox();
                tRep.Text = "Some random text just for fun rep" + i;
                tRep.TextMode = TextBoxMode.MultiLine;
                // pour avoir un rendu sympa :)
                tRep.CssClass = "form-control";

                tRep.ID = "TextBox_Question_Reponse" + id +"_"+i;
                pReps.Controls.Add(tRep);
            }

        }

        protected void Button_Add_Click(object sender, EventArgs e)
        {
            // cest une nouvelle question
            questionsCreated++;

            createQuestion(questionsCreated);
            
            ViewState["questionsCreated"] =questionsCreated.ToString();
        }
    }
}