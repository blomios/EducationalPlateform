using LO54_Projet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LO54_Projet.Controllers
{
    public partial class AnswereTypeForm : System.Web.UI.UserControl
    {
        static AnswereType answereType;

        protected void Page_Load(object sender, EventArgs e)
        {

            Array itemValues = System.Enum.GetValues(typeof(AnswereType));
            Array itemNames = System.Enum.GetNames(typeof(AnswereType));

            for (int i = 0; i <= itemNames.Length - 1; i++)
            {
                ListItem item = new ListItem(itemNames.GetValue(i).ToString(), itemValues.GetValue(i).ToString());
                DropDownList1.Items.Add(item);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            answereType = (AnswereType)DropDownList1.SelectedIndex;
        }

        public AnswereType GetSelectedAnswereType()
        {
            return answereType;
        }
    }
}