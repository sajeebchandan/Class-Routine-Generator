using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Routine_Generator
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            HttpCookie cookieGenerator = new HttpCookie("EmptySlotGenerator");
            cookieGenerator["dept"] = GetEmptyTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());

            Response.Cookies.Add(cookieGenerator);
            Response.Redirect("View Empty Slot.aspx");
        }

        #region Get Empty Table Name By Selected Department
        private string GetEmptyTableNameByDept(string dept)
        {
            if (dept == "SWE")
            {
                return "Routine_Empty";
            }
            else if (dept == "CSE")
            {
                return "RoutineCSE_Empty";
            }
            else if (dept == "MCT")
            {
                return "RoutineMCT_Empty";
            }
            else if (dept == "Pharmacy")
            {
                return "RoutinePharmacy_Empty";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}