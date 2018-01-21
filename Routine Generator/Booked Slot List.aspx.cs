using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Routine_Generator
{
    public partial class Booked_Slot_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie gatheredCookie = Request.Cookies["BookedList"];
                LoadData(gatheredCookie["dept"].ToString());
                LoadDataMin(gatheredCookie["dept"].ToString());
            }
        }


        #region Load Data Into GridView
        private void LoadData(string dept)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sql = "SELECT DISTINCT Dates, DateId FROM " + dept + " ORDER BY DateId ASC";
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


        #region Load Data Into GridViewMin
        private void LoadDataMin(string dept)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            string sql = "SELECT DISTINCT Dates, DateId FROM " + dept + " ORDER BY DateId ASC";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridViewMin.DataSource = rdr;
            GridViewMin.DataBind();
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

        protected void GridViewWeekDay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            foreach (GridViewRow row in GridViewWeekDay.Rows)
            {
                Label Dates = (Label)row.FindControl("LabelDistinctDates");
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                string sqlcommand = "SELECT * FROM Routine_Empty_Book_Slot WHERE Dates=@Dates ORDER BY DateId ASC";
                SqlCommand cmd = new SqlCommand(sqlcommand, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dates", Dates.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dschild = new DataSet();
                da.Fill(dschild);
                if (dschild.Tables[0].Rows.Count > 0)
                {
                    GridChild.DataSource = dschild;
                    GridChild.DataBind();
                }
                else
                {
                    GridChild.DataSource = null;
                    GridChild.DataBind();
                }
            }
        }

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

        protected void GridViewMin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            foreach (GridViewRow row in GridViewMin.Rows)
            {
                Label Dates = (Label)row.FindControl("LabelDistinctDates");
                GridView GridChild = (GridView)row.FindControl("GridViewChild");
                string sqlcommand = "SELECT * FROM Routine_Empty_Book_Slot WHERE Dates=@Dates ORDER BY DateId ASC";
                SqlCommand cmd = new SqlCommand(sqlcommand, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dates", Dates.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dschild = new DataSet();
                da.Fill(dschild);
                if (dschild.Tables[0].Rows.Count > 0)
                {
                    GridChild.DataSource = dschild;
                    GridChild.DataBind();
                }
                else
                {
                    GridChild.DataSource = null;
                    GridChild.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewMin.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "onClickbtnMin()", true);
        }
    }
}