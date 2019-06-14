using LO54_Projet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.Controllers
{
    public partial class AnswereForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AnswereText_TextChanged(object sender, EventArgs e)
        {

        }

        public Answer getAnswere()
        {
            Answer answere = new Answer(AnswereText.Text, GoodAnswereCheckBox.Checked);
            return answere;
        }

        public void setAnswere(Answer answere)
        {
            AnswereText.Text = answere.answere;
            GoodAnswereCheckBox.Checked = answere.isGoodAnswere;
        }
    }
}