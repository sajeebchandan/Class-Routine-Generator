using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Routine_Generator
{
    public partial class Select_Semester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(RadioButtonListSelectSemester.SelectedItem.Text.ToString()) && !String.IsNullOrEmpty(RadioButtonListDept.SelectedItem.Text.ToString()) && !String.IsNullOrEmpty(TextBoxSec.Text.ToString()))
                {
                    HttpCookie cookieGenerator = new HttpCookie("CourseCodes");
                    if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 1 - Term 1")
                    {
                        cookieGenerator["course1"] = "SWE112" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE111" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "PHY114" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "NULL";
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 1 - Term 2")
                    {
                        cookieGenerator["course1"] = "ENG123" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "MAT111" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE121" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "SWE122" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 1 - Term 3")
                    {
                        cookieGenerator["course1"] = "MAT221" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE231" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE133" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "STA134" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 2 - Term 1")
                    {
                        cookieGenerator["course1"] = "SWE132" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE213" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE211" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "NULL";
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 2 - Term 2")
                    {
                        cookieGenerator["course1"] = "SWE233" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE222" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE223" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "SWE224" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 2 - Term 3")
                    {
                        cookieGenerator["course1"] = "SWE131" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE232" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE212" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "ACC124" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 3 - Term 1")
                    {
                        cookieGenerator["course1"] = "SWE323" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE312" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE322" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "SWE313" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 3 - Term 2")
                    {
                        cookieGenerator["course1"] = "SWE321" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE333" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE311" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "SWE413" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 3 - Term 3")
                    {
                        cookieGenerator["course1"] = "SWE412" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE331" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE422" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "SWE424" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 4 - Term 1")
                    {
                        cookieGenerator["course1"] = "SWE423" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE425" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE426" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "SWE332" + TextBoxSec.Text.ToString();
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                    else if (RadioButtonListSelectSemester.SelectedItem.Text == "Level 4 - Term 2")
                    {
                        cookieGenerator["course1"] = "SWE435" + TextBoxSec.Text.ToString();
                        cookieGenerator["course2"] = "SWE438" + TextBoxSec.Text.ToString();
                        cookieGenerator["course3"] = "SWE439" + TextBoxSec.Text.ToString();
                        cookieGenerator["course4"] = "NULL";
                        cookieGenerator["course5"] = "NULL";
                        cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                        cookieGenerator["semester"] = RadioButtonListDept.SelectedItem.Text + "_" + RadioButtonListSelectSemester.SelectedItem.Text + "_" + "(Section " + TextBoxSec.Text + ")";
                        Response.Cookies.Add(cookieGenerator);
                        Response.Redirect("View Routine.aspx");
                    }
                }
                else
                {
                    LabelMsg.Text = "Select Department, Semester and enter Section";
                    LabelMsg.ForeColor = System.Drawing.Color.Red;
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
            }
        }

        #region Get Table Name By Department From Radio Button
        private string GetTableNameByDept(string dept)
        {
            if (dept == "SWE")
            {
                return "Routine";
            }
            else if (dept == "CSE")
            {
                return "RoutineCSE";
            }
            else if (dept == "MCT")
            {
                return "RoutineMCT";
            }
            else if (dept == "Pharmacy")
            {
                return "RoutinePharmacy";
            }
            else
            {
                return "";
            }
        }

        #endregion
    }
}