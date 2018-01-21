using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Routine_Generator
{
    public partial class View_Empty_Slot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie gatheredCookie = Request.Cookies["EmptySlotGenerator"];
                LoadData(gatheredCookie["dept"].ToString());
            }

            //catch (Exception ex)
            //{
            //    if (ex != null)
            //    {
            //        Logger.Log(ex);
            //        Server.ClearError();
            //        Server.Transfer("~/Application Error.aspx");
            //    }
            //}
        }


        //External Methods
        #region Get Course Name By Course Code
        public string GetCourseName(string CourseCode)
        {
            if (CourseCode.Contains("SWE112"))
                return "Computer Fundamentals With Lab";
            else if (CourseCode.Contains("SWE111"))
                return "Introduction to Software Engineering";
            else if (CourseCode.Contains("PHY114"))
                return "Physics With Lab";
            else if (CourseCode.Contains("ENG123"))
                return "English Language";
            else if (CourseCode.Contains("MAT113"))
                return "Mathemetics-I";
            else if (CourseCode.Contains("SWE121"))
                return "Software Requirements Analysis and Design";
            else if (CourseCode.Contains("SWE122"))
                return "Programming Language with Lab-C";
            else if (CourseCode.Contains("MAT221"))
                return "Mathemetics-II";
            else if (CourseCode.Contains("SWE231"))
                return "Software Engineering Project-I (C)";
            else if (CourseCode.Contains("SWE133"))
                return "Data Structure with Lab";
            else if (CourseCode.Contains("STA134"))
                return "Statistics and Probabilities";
            else if (CourseCode.Contains("SWE132"))
                return "Java Programming with Lab";
            else if (CourseCode.Contains("SWE213"))
                return "Computer Algorithms with Lab";
            else if (CourseCode.Contains("SWE211"))
                return "Introduction to Database with Lab";
            else if (CourseCode.Contains("SWE233"))
                return "Object Oriented Design with Lab";
            else if (CourseCode.Contains("SWE222"))
                return "Software Engineering QA and Testing";
            else if (CourseCode.Contains("SWE223"))
                return "Digital Electronics with Lab";
            else if (CourseCode.Contains("SWE224"))
                return "Discrete Mathemetics with Lab";
            else if (CourseCode.Contains("SWE131"))
                return "Documentation of Software Engineering";
            else if (CourseCode.Contains("SWE232"))
                return "Operating System With Lab";
            else if (CourseCode.Contains("SWE212"))
                return "Software Project Management";
            else if (CourseCode.Contains("ACC124"))
                return "Principle of Accounting";
            else if (CourseCode.Contains("SWE323"))
                return "System Analysis and Design";
            else if (CourseCode.Contains("SWE312"))
                return "Theory of Computing";
            else if (CourseCode.Contains("SWE322"))
                return "Software Security";
            else if (CourseCode.Contains("SWE313"))
                return ".NET Programming with Lab";
            else if (CourseCode.Contains("SWE321"))
                return "Data Communication with Lab";
            else if (CourseCode.Contains("SWE333"))
                return "Desktop and Web Programming";
            else if (CourseCode.Contains("SWE311"))
                return "Computer Architechture and Organizations";
            else if (CourseCode.Contains("SWE413"))
                return "Software Engineering and Cyber Laws";
            else if (CourseCode.Contains("SWE412"))
                return "Management Information System";
            else if (CourseCode.Contains("SWE331"))
                return "Object Oriented Software Development";
            else if (CourseCode.Contains("SWE422"))
                return "Numerical Analysis with Lab";
            else if (CourseCode.Contains("SWE424"))
                return "Artificial Intelligence with Lab";
            else if (CourseCode.Contains("SWE423"))
                return "Advance Database with Lab";
            else if (CourseCode.Contains("SWE425"))
                return "Telecommunication Engineering with Lab";
            else if (CourseCode.Contains("SWE426"))
                return "Distributive Computing and Network Security with Lab";
            else if (CourseCode.Contains("SWE332"))
                return "Software Engineering Project-II (Web Programming)";
            else if (CourseCode.Contains("SWE435"))
                return "Business Communication";
            else if (CourseCode.Contains("SWE438"))
                return "Internet Marketing with Lab";
            else if (CourseCode.Contains("SWE439"))
                return "Project/Thesis";

            else
                return "";
        }
        #endregion

        #region Get teacher Name by teacher Initial
        public string getTeacherName(string ti)
        {
            if (ti == "DTB")
                return "Dr. Touhid Bhuiyan";
            else if (ti == "DFH")
                return "Dr. Fokhray Hossain";
            else if (ti == "DAA")
                return "Dr. Md. Asraf Ali";
            else if (ti == "MKS")
                return "M. Khaled Sohel";
            else if (ti == "IM")
                return "Imran Mahmud";
            else if (ti == "SA")
                return "Shikha Anirban";
            else if (ti == "MH")
                return "Maruf Hassan";
            else if (ti == "KMIU")
                return "K M Imtiaz Uddin";
            else if (ti == "DMR")
                return "Dr. Md. Mostafijur Rahman";
            else if (ti == "KS")
                return "Kaushik Sarker";
            else if (ti == "TAC")
                return "Tanvir Ahmed Chowdhury";
            else if (ti == "AS")
                return "Abu Sufian";
            else if (ti == "FBZ")
                return "Fahad Bin Zamal";
            else if (ti == "NN")
                return "Nazia Nishat";
            else if (ti == "IAE")
                return "Iftekharul Alam Efat";
            else if (ti == "AK")
                return "Md Alamgir Kabir";
            else if (ti == "AKS")
                return "Asif Khan Shakir";
            else if (ti == "AB")
                return "Afsana Begum";
            else if (ti == "FS")
                return "Farzana Sadia";
            else if (ti == "NJ")
                return "Nusrat Jahan";
            else if (ti == "SSH")
                return "Syeda Sumbul Hossain Shamma";
            else if (ti == "MAH")
                return "Md. Anwar Hossen";
            else if (ti == "MBTN")
                return "Manan Binte Taz Noor";
            else if (ti == "MR")
                return "Mushfiqur Rahman";
            else if (ti == "LR")
                return "Lamisha Rawshan";
            else if (ti == "KBB")
                return "Md. Khalid Been Bodruzzaman";
            else if (ti == "TRT")
                return "Tapushe Rabaya Toma";
            else if (ti == "RI")
                return "Rayhanul Islam";
            else if (ti == "MSA")
                return "Md. Shohel Arman";
            else if (ti == "SP")
                return "Shayla Parvin";
            else if (ti == "PM")
                return "Priyanka Mandal";
            else if (ti == "MS")
                return "Mobashir Sadat";
            else if (ti == "MMR")
                return "Sheikh Mohammad Motiur Rahman";
            else if (ti == "FBR")
                return "Fatama Binta Rafiq";
            else if (ti == "KMQ")
                return "Khandker M Qaiduzzaman";
            else if (ti == "HR")
                return "Md. Habibur Rahman";
            else if (ti == "FTZ")
                return "Fatema Tuz Zohora";
            else if (ti == "NR")
                return "Nizhum Rahman";
            else if (ti == "BK")
                return "Bari Kahar";
            else if (ti == "DBZ")
                return "Dara Bin Zaid";
            else if (ti == "FR")
                return "Fouzia Rahman";
            else if (ti == "SN")
                return "Samia Nasrin";
            else if (ti == "TRK")
                return "Tasnim Rahman Katha";
            else if (ti == "TBA")
                return "To be announced";
            else
                return "";
        }
        #endregion

        #region Load Data Into GridView
        private void LoadData(string dept)
        {
            HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sql = "SELECT DISTINCT Day, DayID FROM " + dept + " WHERE Course IS NULL AND Teacher IS NULL ORDER BY DayID";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridViewWeekDay.DataSource = rdr;
            GridViewWeekDay.DataBind();
            con.Close();

            //catch (Exception ex)
            //{
            //    if (ex != null)
            //    {
            //        Logger.Log(ex);
            //        Server.ClearError();
            //        Server.Transfer("~/Application Error.aspx");
            //    }

            //}
        }
        #endregion

        #region GridView RowDataBound
        private void RowDataBound(string dept)
        {


            foreach (GridViewRow row in GridViewWeekDay.Rows)
            {
                Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                string WeekDay = WeekDayLabel.Text.ToString();
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridChild.DataSource = ds;
                    GridChild.DataBind();
                }
                else
                {
                    GridChild.DataSource = null;
                    GridChild.DataBind();
                }

            }
            //catch (Exception ex)
            //{
            //    if (ex != null)
            //    {
            //        Logger.Log(ex);
            //        Server.ClearError();
            //        Server.Transfer("~/Application Error.aspx");
            //    }

            //}
        }
        #endregion

        protected void GridViewWeekDay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            HttpCookie gatheredCookie = Request.Cookies["EmptySlotGenerator"];
            RowDataBound(gatheredCookie["dept"].ToString());

            //catch (Exception ex)
            //{
            //    if (ex != null)
            //    {
            //        Logger.Log(ex);
            //        Server.ClearError();
            //        Server.Transfer("~/Application Error.aspx");
            //    }
            //}
        }

        protected void GridViewChild_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CheckAvailability")
            {
                /*Fetching Current Parent GridView Index*/
                GridViewRow ChildGridViewRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                GridView PrentGridView = (GridView)(ChildGridViewRow.Parent.Parent);
                GridViewRow ParentGridViewRow = (GridViewRow)(PrentGridView.NamingContainer);
                int ParentGridViewRowIndex = ParentGridViewRow.RowIndex;


                GridViewRow row = GridViewWeekDay.Rows[ParentGridViewRowIndex];
                GridViewRow RowForIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = RowForIndex.RowIndex;
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                TextBox TextBoxDateOfAvailability = (TextBox)GridChild.Rows[rowIndex].FindControl("TextBoxDateOfAvailability");
                
                Label LabelDay = (Label)GridChild.Rows[rowIndex].FindControl("LabelDay");
                if (!String.IsNullOrEmpty(TextBoxDateOfAvailability.Text))
                {
                    if (GetDayOfDate(TextBoxDateOfAvailability.Text.ToString(), LabelDay.Text.ToString()) == true)
                    {
                        if (CheckAvailability(Convert.ToInt32(e.CommandArgument), TextBoxDateOfAvailability.Text.ToString()) == 0)
                        {
                            ViewState["SelectedDate"] = TextBoxDateOfAvailability.Text.ToString();
                            //foreach (GridViewRow row in GridViewWeekDay.Rows)
                            //{
                            //Label lbl = (Label)GridViewWeekDay.FindControl("LabelParentRowIndex");
                            //int parentId = Convert.ToInt32(lbl.Text.ToString());
                            LinkButton lblMsg = (LinkButton)GridChild.Rows[rowIndex].FindControl("LinkButtonMessage");
                            lblMsg.Text = "Available";
                            lblMsg.CommandName = "TryBook";
                            lblMsg.ForeColor = Color.Green;

                            //}
                        }
                        else
                        {
                            LinkButton lblMsg = (LinkButton)GridChild.Rows[rowIndex].FindControl("LinkButtonMessage");
                            lblMsg.Text = "Not Available";
                            lblMsg.CommandName = "CancelBook";
                            lblMsg.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Date and Time Does not match. Please Select a Date of " + LabelDay.Text.ToString().ToUpper() + "');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Please Enter Date');", true);
                }
            }

            if (e.CommandName == "TryBook")
            {
                GridViewRow ChildGridViewRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                GridView PrentGridView = (GridView)(ChildGridViewRow.Parent.Parent);
                GridViewRow ParentGridViewRow = (GridViewRow)(PrentGridView.NamingContainer);
                int ParentGridViewRowIndex = ParentGridViewRow.RowIndex;
                GridViewRow row = GridViewWeekDay.Rows[ParentGridViewRowIndex];
                GridViewRow RowForIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = RowForIndex.RowIndex;
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                GridChild.EditIndex = rowIndex;

                TextBox TextBoxDateOfAvailability = (TextBox)GridChild.Rows[rowIndex].FindControl("TextBoxDateOfAvailability");
                TextBoxDateOfAvailability.Text = ViewState["SelectedDate"].ToString();
                HttpCookie gatheredCookie = Request.Cookies["EmptySlotGenerator"];
                RowDataBound(gatheredCookie["dept"].ToString());
                ViewState["SelectedDate"]=TextBoxDateOfAvailability.Text;

            }


            if (e.CommandName == "Book")
            {
                GridViewRow ChildGridViewRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                GridView PrentGridView = (GridView)(ChildGridViewRow.Parent.Parent);
                GridViewRow ParentGridViewRow = (GridViewRow)(PrentGridView.NamingContainer);
                int ParentGridViewRowIndex = ParentGridViewRow.RowIndex;


                GridViewRow row = GridViewWeekDay.Rows[ParentGridViewRowIndex];
                GridViewRow RowForIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = RowForIndex.RowIndex;
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                Label LabelId = (Label)GridChild.Rows[rowIndex].FindControl("LabelId");
                Label LabelRoom = (Label)GridChild.Rows[rowIndex].FindControl("LabelRoom");
                AjaxControlToolkit.ComboBox TextBoxCourse = (AjaxControlToolkit.ComboBox)GridChild.Rows[rowIndex].FindControl("ComboBoxCourse");
                AjaxControlToolkit.ComboBox TextBoxTeacherInitial = (AjaxControlToolkit.ComboBox)GridChild.Rows[rowIndex].FindControl("ComboBoxTeacherInitial");
                Label LabelDay = (Label)GridChild.Rows[rowIndex].FindControl("LabelDay");
                Label LabelDayID = (Label)GridChild.Rows[rowIndex].FindControl("LabelDayID");
                Label LabelTime = (Label)GridChild.Rows[rowIndex].FindControl("LabelTime");
                //Label LabelId = (Label)GridChild.Rows[rowIndex].FindControl("LabelId");
                //Label LabelId = (Label)GridChild.Rows[rowIndex].FindControl("LabelId");
                TextBox TextBoxDateOfAvailability = (TextBox)GridChild.Rows[rowIndex].FindControl("TextBoxDateOfAvailability");
                DateTime DateTimeDateID = DateTime.ParseExact(ViewState["SelectedDate"].ToString(), "dd/MM/yyyy", null);
                string str_Date = DateTimeDateID.ToString("dd");

                DateTime DateTimeMonthID = DateTime.ParseExact(ViewState["SelectedDate"].ToString(), "dd/MM/yyyy", null);
                string str_Month = DateTimeMonthID.ToString("MM");
                string MonthSingle = Regex.Replace(str_Month.ToString(), @"^[0]+", "");
                int DateId = Convert.ToInt32(MonthSingle + str_Date);
                //TextBoxDateOfAvailability.Text = ViewState["SelectedDate"].ToString();

                if (!String.IsNullOrEmpty(TextBoxCourse.Text) || !String.IsNullOrEmpty(TextBoxTeacherInitial.Text) || !String.IsNullOrEmpty(ViewState["SelectedDate"].ToString()))
                {
                    //if (GetDayOfDate(TextBoxDateOfAvailability.Text.ToString(), LabelDay.Text.ToString()) == true)
                    //{
                        if (InsertBooking(Convert.ToInt32(LabelId.Text.ToString()), LabelRoom.Text, TextBoxCourse.Text, TextBoxTeacherInitial.Text, LabelTime.Text, LabelDay.Text, Convert.ToInt32(LabelDayID.Text.ToString()), ViewState["SelectedDate"].ToString(), Convert.ToInt32(DateId)) == 1)
                        {
                            GridChild.EditIndex = -1;
                            HttpCookie gatheredCookie = Request.Cookies["EmptySlotGenerator"];
                            RowDataBound(gatheredCookie["dept"].ToString());
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Schedule Booked For the day');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Problem');", true);
                        }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Date and Time Does not match. Please Select a Date of "+LabelDay.Text.ToString().ToUpper()+"');", true);
                    //}
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Please fill all the fields with proper value');", true);
                    //RequiredFieldValidator RequiredFieldValidatorDate = (RequiredFieldValidator)GridChild.Rows[rowIndex].FindControl("RequiredFieldValidatorDate");
                    //RequiredFieldValidator RequiredFieldValidatorTeacher = (RequiredFieldValidator)GridChild.Rows[rowIndex].FindControl("RequiredFieldValidatorTeacher");
                    //RequiredFieldValidator RequiredFieldValidatorCourse = (RequiredFieldValidator)GridChild.Rows[rowIndex].FindControl("RequiredFieldValidatorCourse");

                    //RequiredFieldValidatorCourse.Text = "*";
                    //RequiredFieldValidatorCourse.ForeColor = Color.Red;
                    //RequiredFieldValidatorDate.Text = "*";
                    //RequiredFieldValidatorDate.ForeColor = Color.Red;
                    //RequiredFieldValidatorTeacher.Text = "*";
                    //RequiredFieldValidatorTeacher.ForeColor = Color.Red;
                }
            }

            if (e.CommandName == "CancelBook")
            {
                GridViewRow ChildGridViewRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                GridView PrentGridView = (GridView)(ChildGridViewRow.Parent.Parent);
                GridViewRow ParentGridViewRow = (GridViewRow)(PrentGridView.NamingContainer);
                int ParentGridViewRowIndex = ParentGridViewRow.RowIndex;
                GridViewRow row = GridViewWeekDay.Rows[ParentGridViewRowIndex];
                GridViewRow RowForIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer);
                int rowIndex = RowForIndex.RowIndex;
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                GridChild.EditIndex = -1;


                HttpCookie gatheredCookie = Request.Cookies["EmptySlotGenerator"];
                RowDataBound(gatheredCookie["dept"].ToString());
            }
        }

        private int CheckAvailability(int commandArgument, string date)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Routine_Empty_Book_Slot WHERE Id=@Id AND Dates=@Dates";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", commandArgument);
            cmd.Parameters.AddWithValue("@Dates", date);
            con.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            return i;
        }

        private int InsertBooking(int Id, string Class, string Course, string Teacher, string Schedule, string Day, int DayID, string Dates, int DateId)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = @"INSERT INTO Routine_Empty_Book_Slot 
                            (Id, Class, Course, Teacher, Schedule, Day, DayID, Dates, DateId) VALUES
                            (@Id, @Class, @Course, @Teacher, @Schedule, @Day, @DayID, @Dates, @DateId)";
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Class", Class);
            cmd.Parameters.AddWithValue("@Course", Course);
            cmd.Parameters.AddWithValue("@Teacher", Teacher);
            cmd.Parameters.AddWithValue("@Schedule", Schedule);
            cmd.Parameters.AddWithValue("@Day", Day);
            cmd.Parameters.AddWithValue("@DayID", DayID);
            cmd.Parameters.AddWithValue("@Dates", Dates);
            cmd.Parameters.AddWithValue("@DateId", DateId);

            con.Open();
            int i = Convert.ToInt32(cmd.ExecuteNonQuery());
            return i;
        }

        private bool GetDayOfDate(string SelectedDate, string ValidDateDay)
        {
            bool ret = false;
            DateTime dateValueOne = DateTime.ParseExact(SelectedDate, "dd/MM/yyyy", null);
            string SelectedDateDay = dateValueOne.ToString("dddd");

            if (SelectedDateDay == ValidDateDay)
                ret = true;
            else
                ret = false;

            return ret;
        }

        protected void ButtonGetSlot_Click(object sender, EventArgs e)
        {
            HttpCookie gatheredCookie = Request.Cookies["EmptySlotGenerator"];
            string department= gatheredCookie["dept"].ToString();
            HttpCookie cookieGenerator = new HttpCookie("BookedList");

            if (department == "Routine_Empty")
            {
                cookieGenerator["dept"] = department + "_Book_Slot";
            }
            else if (department== "RoutineCSE_Empty")
            {
                cookieGenerator["dept"] = department + "_Book_Slot";
            }
            else if (department == "RoutineMCT_Empty")
            {
                cookieGenerator["dept"] = department + "_Book_Slot";
            }
            else if (department == "RoutinePharmacy_Empty")
            {
                cookieGenerator["dept"] = department + "_Book_Slot";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Cookie Not Found!');", true);
            }
            Response.Cookies.Add(cookieGenerator);
            Response.Redirect("Booked Slot List.aspx");

        }
    }
}