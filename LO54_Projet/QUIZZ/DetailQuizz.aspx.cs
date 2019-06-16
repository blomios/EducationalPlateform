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
    public partial class DetailQuizz : System.Web.UI.Page
    {
        private static QuizzDb quizzContext = QuizzDb.GetInstance();
        private Quizz cQuizz;

        protected void Page_Load(object sender, EventArgs e)
        {
            cQuizz = quizzContext.GetByIdString(Request.Params.Get("quizz"));
        }
    }
}