using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Routine_Generator
{
    public partial class View_Routine : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Get The HeaderText For the GridView && GridViewMin
        public string HeaderText()
        {
            HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
            try
            {
                if (gatheredCookie["semester"].ToString() == "")
                {
                    //GridViewWeekDay.ShowFooter = false;
                    //GridViewMin.ShowFooter = false;
                    return "";
                }
                else
                {
                    return gatheredCookie["semester"].ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    Logger.Log(ex);
                    Server.ClearError();
                    Server.Transfer("~/Application Error.aspx");
                }
                return "";
            }
        }
        #endregion
    }
}