using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Routine_Generator
{
    public partial class Routine_By_Course_Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(RadioButtonListDept.SelectedItem.Text.ToString()))
                {
                    if (calculateCredit() >= 6)
                    {
                        if (calculateCredit() <= 15)
                        {
                            HttpCookie cookieGenerator = new HttpCookie("CourseCodes");

                            if (!String.IsNullOrEmpty(TextBoxCourse1.Text.ToString().Replace(" ", "")))
                            {
                                cookieGenerator["course1"] = TextBoxCourse1.Text.ToString();
                            }
                            else
                            {
                                cookieGenerator["course1"] = "NULL";
                            }


                            if (!String.IsNullOrEmpty(TextBoxCourse2.Text.ToString().Replace(" ", "")))
                            {
                                cookieGenerator["course2"] = TextBoxCourse2.Text.ToString();
                            }
                            else
                            {
                                cookieGenerator["course2"] = "NULL";
                            }


                            if (!String.IsNullOrEmpty(TextBoxCourse3.Text.ToString().Replace(" ", "")))
                            {
                                cookieGenerator["course3"] = TextBoxCourse3.Text.ToString();
                            }
                            else
                            {
                                cookieGenerator["course3"] = "NULL";
                            }


                            if (!String.IsNullOrEmpty(TextBoxCourse4.Text.ToString().Replace(" ", "")))
                            {
                                cookieGenerator["course4"] = TextBoxCourse4.Text.ToString();
                            }
                            else
                            {
                                cookieGenerator["course4"] = "NULL";
                            }


                            if (!String.IsNullOrEmpty(TextBoxCourse5.Text.ToString().Replace(" ", "")))
                            {
                                cookieGenerator["course5"] = TextBoxCourse5.Text.ToString();
                            }
                            else
                            {
                                cookieGenerator["course5"] = "NULL";
                            }

                            cookieGenerator["dept"] = GetTableNameByDept(RadioButtonListDept.SelectedItem.Text.ToString());
                            cookieGenerator["semester"] = "";
                            Response.Cookies.Add(cookieGenerator);

                            Response.Redirect("View Routine.aspx", false);
                        }
                        else
                        {
                            LabelMsg.Visible = true;
                            LabelMsg.Text = "Limit exceeded. MAX Credit 15";
                            LabelMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        LabelMsg.Visible = true;
                        LabelMsg.Text = "Enter 2 courses. MIN Credit 6";
                        LabelMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    LabelMsg.Visible = true;
                    LabelMsg.Text = "Select department";
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

        protected void TextBoxCourse1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LabelMsg.Visible = false;
                LabelCourseCounter.Text = calculateCredit().ToString();
                TextBoxCourse2.Focus();
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

        protected void TextBoxCourse2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LabelMsg.Visible = false;
                LabelCourseCounter.Text = calculateCredit().ToString();
                TextBoxCourse3.Focus();
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

        protected void TextBoxCourse3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LabelMsg.Visible = false;
                LabelCourseCounter.Text = calculateCredit().ToString();
                TextBoxCourse4.Focus();
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

        protected void TextBoxCourse4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LabelMsg.Visible = false;
                LabelCourseCounter.Text = calculateCredit().ToString();
                TextBoxCourse5.Focus();
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

        protected void TextBoxCourse5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LabelMsg.Visible = false;
                LabelCourseCounter.Text = calculateCredit().ToString();
                TextBoxCourse1.Focus();
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


        //List of all EXTERNEL METHODS

        #region EXTERNAL METHODS

        #region Get Table Name By Selected Department
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

        #region Get Course Credit By Course Code
        public int GetCourseCredit(string CourseCode)
        {
            if (CourseCode.Contains("SWE112"))
                return 4;
            else if (CourseCode.Contains("SWE111"))
                return 3;
            else if (CourseCode.Contains("PHY114"))
                return 4;
            else if (CourseCode.Contains("ENG123"))
                return 3;
            else if (CourseCode.Contains("MAT113"))
                return 3;
            else if (CourseCode.Contains("SWE121"))
                return 3;
            else if (CourseCode.Contains("SWE122"))
                return 4;
            else if (CourseCode.Contains("MAT221"))
                return 3;
            else if (CourseCode.Contains("SWE231"))
                return 3;
            else if (CourseCode.Contains("SWE133"))
                return 4;
            else if (CourseCode.Contains("STA101"))
                return 3;
            else if (CourseCode.Contains("SWE132"))
                return 4;
            else if (CourseCode.Contains("SWE213"))
                return 4;
            else if (CourseCode.Contains("SWE211"))
                return 4;
            else if (CourseCode.Contains("SWE233"))
                return 4;
            else if (CourseCode.Contains("SWE222"))
                return 3;
            else if (CourseCode.Contains("SWE223"))
                return 4;
            else if (CourseCode.Contains("SWE224"))
                return 4;
            else if (CourseCode.Contains("SWE131"))
                return 3;
            else if (CourseCode.Contains("SWE232"))
                return 3;
            else if (CourseCode.Contains("SWE212"))
                return 3;
            else if (CourseCode.Contains("ACC124"))
                return 3;
            else if (CourseCode.Contains("SWE323"))
                return 3;
            else if (CourseCode.Contains("SWE312"))
                return 3;
            else if (CourseCode.Contains("SWE322"))
                return 3;
            else if (CourseCode.Contains("SWE313"))
                return 4;
            else if (CourseCode.Contains("SWE321"))
                return 4;
            else if (CourseCode.Contains("SWE333"))
                return 4;
            else if (CourseCode.Contains("SWE311"))
                return 3;
            else if (CourseCode.Contains("SWE413"))
                return 3;
            else if (CourseCode.Contains("SWE412"))
                return 3;
            else if (CourseCode.Contains("SWE331"))
                return 3;
            else if (CourseCode.Contains("SWE422"))
                return 4;
            else if (CourseCode.Contains("SWE424"))
                return 4;
            else if (CourseCode.Contains("SWE423"))
                return 4;
            else if (CourseCode.Contains("SWE425"))
                return 4;
            else if (CourseCode.Contains("SWE426"))
                return 4;
            else if (CourseCode.Contains("SWE332"))
                return 3;
            else if (CourseCode.Contains("SWE411"))
                return 4;
            else if (CourseCode.Contains("SWE431"))
                return 3;

            else
                return 0;
        }
        #endregion

        #region Calculate Credit
        private int calculateCredit()
        {
            if (!String.IsNullOrEmpty(TextBoxCourse1.Text.ToString()))
            {
                ViewState["course1"] = GetCourseCredit(TextBoxCourse1.Text.ToString());
            }
            else
            {
                ViewState["course1"] = 0;
            }

            if (!String.IsNullOrEmpty(TextBoxCourse2.Text.ToString()))
            {
                ViewState["course2"] = GetCourseCredit(TextBoxCourse2.Text.ToString());
            }
            else
            {
                ViewState["course2"] = 0;
            }

            if (!String.IsNullOrEmpty(TextBoxCourse3.Text.ToString()))
            {
                ViewState["course3"] = GetCourseCredit(TextBoxCourse3.Text.ToString());
            }
            else
            {
                ViewState["course3"] = 0;
            }

            if (!String.IsNullOrEmpty(TextBoxCourse4.Text.ToString()))
            {
                ViewState["course4"] = GetCourseCredit(TextBoxCourse4.Text.ToString());
            }
            else
            {
                ViewState["course4"] = 0;
            }

            if (!String.IsNullOrEmpty(TextBoxCourse5.Text.ToString()))
            {
                ViewState["course5"] = GetCourseCredit(TextBoxCourse5.Text.ToString());
            }
            else
            {
                ViewState["course5"] = 0;
            }

            int total = Convert.ToInt32(ViewState["course1"].ToString()) + Convert.ToInt32(ViewState["course2"].ToString()) + Convert.ToInt32(ViewState["course3"].ToString()) + Convert.ToInt32(ViewState["course4"].ToString()) + Convert.ToInt32(ViewState["course5"].ToString());
            return total;
        } 
        #endregion

        #endregion
    }
}