using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Routine_Generator
{
    public partial class View_Routine_By_Course_Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                    LoadData(gatheredCookie["dept"].ToString());
                    LoadDataMin(gatheredCookie["dept"].ToString());
                }

                if (IsPostBack || !IsPostBack)
                {
                    HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                    LABloader(gatheredCookie["course1"].ToString(), gatheredCookie["course2"].ToString(), gatheredCookie["course3"].ToString(), gatheredCookie["course4"].ToString(), gatheredCookie["course5"].ToString(), gatheredCookie["dept"].ToString());
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



        protected void GridViewWeekDay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                RowDataBound(gatheredCookie["course1"].ToString(), gatheredCookie["course2"].ToString(), gatheredCookie["course3"].ToString(), gatheredCookie["course4"].ToString(), gatheredCookie["course5"].ToString(), gatheredCookie["dept"].ToString());
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

        protected void LinkButtonLAB1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                LoadDataLAB1(gatheredCookie["dept"].ToString());
                RowDataBoundLAB1(gatheredCookie["course1"].ToString().Replace(" ", ""), gatheredCookie["course2"].ToString().Replace(" ", ""), gatheredCookie["course3"].ToString().Replace(" ", ""), gatheredCookie["course4"].ToString().Replace(" ", ""), gatheredCookie["course5"].ToString().Replace(" ", ""), gatheredCookie["dept"].ToString().Replace(" ", ""));
                RowDataBoundLAB1Min(gatheredCookie["course1"].ToString().Replace(" ", ""), gatheredCookie["course2"].ToString().Replace(" ", ""), gatheredCookie["course3"].ToString().Replace(" ", ""), gatheredCookie["course4"].ToString().Replace(" ", ""), gatheredCookie["course5"].ToString().Replace(" ", ""), gatheredCookie["dept"].ToString().Replace(" ", ""));
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

        protected void LinkButtonLAB2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(2000);
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                LoadDataLAB2(gatheredCookie["dept"].ToString());
                RowDataBoundLAB2(gatheredCookie["course1"].ToString().Replace(" ", ""), gatheredCookie["course2"].ToString().Replace(" ", ""), gatheredCookie["course3"].ToString().Replace(" ", ""), gatheredCookie["course4"].ToString().Replace(" ", ""), gatheredCookie["course5"].ToString().Replace(" ", ""), gatheredCookie["dept"].ToString().Replace(" ", ""));
                RowDataBoundLAB2Min(gatheredCookie["course1"].ToString().Replace(" ", ""), gatheredCookie["course2"].ToString().Replace(" ", ""), gatheredCookie["course3"].ToString().Replace(" ", ""), gatheredCookie["course4"].ToString().Replace(" ", ""), gatheredCookie["course5"].ToString().Replace(" ", ""), gatheredCookie["dept"].ToString().Replace(" ", ""));
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

        protected void GridViewMin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                RowDataBoundMin(gatheredCookie["course1"].ToString(), gatheredCookie["course2"].ToString(), gatheredCookie["course3"].ToString(), gatheredCookie["course4"].ToString(), gatheredCookie["course5"].ToString(), gatheredCookie["dept"].ToString());
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


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewMin.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "onClickbtnMin()", true);
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
            //GridViewMin.Visible = false;
        }




        //List of all EXTERNEL METHODS

        #region ALL EXTERNAL METHODS

        #region Load Data Into GridView
        private void LoadData(string dept)
        {
            try
            {
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string sql = "SELECT DISTINCT Day, DayID FROM " + dept + " WHERE Course LIKE @course1 OR Course LIKE @course2 OR Course LIKE @course3 OR Course LIKE @course4 OR Course LIKE @course5 ORDER BY DayID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@course1", "%" + gatheredCookie["course1"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course2", "%" + gatheredCookie["course2"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course3", "%" + gatheredCookie["course3"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course4", "%" + gatheredCookie["course4"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course5", "%" + gatheredCookie["course5"].ToString() + "%");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridViewWeekDay.DataSource = rdr;
                GridViewWeekDay.DataBind();
                con.Close();
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
        #endregion

        #region Load Data into GridViewMin
        private void LoadDataMin(string dept)
        {
            try
            {
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string sql = "SELECT DISTINCT Day, DayID FROM " + dept + " WHERE Course LIKE @course1 OR Course LIKE @course2 OR Course LIKE @course3 OR Course LIKE @course4 OR Course LIKE @course5 ORDER BY DayID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@course1", "%" + gatheredCookie["course1"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course2", "%" + gatheredCookie["course2"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course3", "%" + gatheredCookie["course3"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course4", "%" + gatheredCookie["course4"].ToString() + "%");
                cmd.Parameters.AddWithValue("@course5", "%" + gatheredCookie["course5"].ToString() + "%");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridViewMin.DataSource = rdr;
                GridViewMin.DataBind();
                con.Close();
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
        #endregion

        #region Load Data into GridView For LAB1
        private void LoadDataLAB1(string dept)
        {
            try
            {
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string sql = "SELECT DISTINCT Day, DayID FROM " + dept + " WHERE Course = @course1 OR Course = @course2 OR Course = @course3 OR Course = @course4 OR Course = @course5 OR Course = @course1lab OR Course = @course2lab OR Course = @course3lab OR Course = @course4lab OR Course = @course5lab OR Course = @course1l OR Course = @course2l OR Course = @course3l OR Course = @course4l OR Course = @course5l  ORDER BY DayID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@course1", gatheredCookie["course1"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course2", gatheredCookie["course2"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course3", gatheredCookie["course3"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course4", gatheredCookie["course4"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course5", gatheredCookie["course5"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course1lab", gatheredCookie["course1"].ToString().Replace(" ", "") + "LAB1");
                cmd.Parameters.AddWithValue("@course2lab", gatheredCookie["course2"].ToString().Replace(" ", "") + "LAB1");
                cmd.Parameters.AddWithValue("@course3lab", gatheredCookie["course3"].ToString().Replace(" ", "") + "LAB1");
                cmd.Parameters.AddWithValue("@course4lab", gatheredCookie["course4"].ToString().Replace(" ", "") + "LAB1");
                cmd.Parameters.AddWithValue("@course5lab", gatheredCookie["course5"].ToString().Replace(" ", "") + "LAB1");
                cmd.Parameters.AddWithValue("@course1l", gatheredCookie["course1"].ToString().Replace(" ", "") + "1");
                cmd.Parameters.AddWithValue("@course2l", gatheredCookie["course2"].ToString().Replace(" ", "") + "1");
                cmd.Parameters.AddWithValue("@course3l", gatheredCookie["course3"].ToString().Replace(" ", "") + "1");
                cmd.Parameters.AddWithValue("@course4l", gatheredCookie["course4"].ToString().Replace(" ", "") + "1");
                cmd.Parameters.AddWithValue("@course5l", gatheredCookie["course5"].ToString().Replace(" ", "") + "1");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridViewWeekDay.DataSource = rdr;
                GridViewWeekDay.DataBind();
                con.Close();
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
        #endregion

        #region Load Data into GridView For LAB2
        private void LoadDataLAB2(string dept)
        {
            try
            {
                HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string sql = "SELECT DISTINCT Day, DayID FROM " + dept + " WHERE Course = @course1 OR Course = @course2 OR Course = @course3 OR Course = @course4 OR Course = @course5 OR Course = @course1lab OR Course = @course2lab OR Course = @course3lab OR Course = @course4lab OR Course = @course5lab OR Course = @course1l OR Course = @course2l OR Course = @course3l OR Course = @course4l OR Course = @course5l  ORDER BY DayID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@course1", gatheredCookie["course1"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course2", gatheredCookie["course2"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course3", gatheredCookie["course3"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course4", gatheredCookie["course4"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course5", gatheredCookie["course5"].ToString().Replace(" ", ""));
                cmd.Parameters.AddWithValue("@course1lab", gatheredCookie["course1"].ToString().Replace(" ", "") + "LAB2");
                cmd.Parameters.AddWithValue("@course2lab", gatheredCookie["course2"].ToString().Replace(" ", "") + "LAB2");
                cmd.Parameters.AddWithValue("@course3lab", gatheredCookie["course3"].ToString().Replace(" ", "") + "LAB2");
                cmd.Parameters.AddWithValue("@course4lab", gatheredCookie["course4"].ToString().Replace(" ", "") + "LAB2");
                cmd.Parameters.AddWithValue("@course5lab", gatheredCookie["course5"].ToString().Replace(" ", "") + "LAB2");
                cmd.Parameters.AddWithValue("@course1l", gatheredCookie["course1"].ToString().Replace(" ", "") + "2");
                cmd.Parameters.AddWithValue("@course2l", gatheredCookie["course2"].ToString().Replace(" ", "") + "2");
                cmd.Parameters.AddWithValue("@course3l", gatheredCookie["course3"].ToString().Replace(" ", "") + "2");
                cmd.Parameters.AddWithValue("@course4l", gatheredCookie["course4"].ToString().Replace(" ", "") + "2");
                cmd.Parameters.AddWithValue("@course5l", gatheredCookie["course5"].ToString().Replace(" ", "") + "2");
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridViewWeekDay.DataSource = rdr;
                GridViewWeekDay.DataBind();
                con.Close();
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
        #endregion

        #region Load Link Button For LAB Separation
        private void LABloader(string course1, string course2, string course3, string course4, string course5, string dept)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                string sql = "SELECT * FROM " + dept + " WHERE Course LIKE'%" + course1 + "%' OR Course LIKE'%" + course2 + "%' OR Course LIKE'%" + course3 + "%' OR Course LIKE'%" + course4 + "%' OR Course LIKE'%" + course5 + "%'";
                DataTable dtlabloader = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dtlabloader);


                foreach (DataRow dtlabloaderRow in dtlabloader.Rows)
                {

                    if (dtlabloaderRow["Course"].ToString().Contains(course1 + "LAB1") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '1')
                    {
                        LinkButtonLAB1.Text = "Filter Routine by LAB1";
                    }
                    if (dtlabloaderRow["Course"].ToString().Contains(course1 + "LAB2") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '2')
                    {
                        LinkButtonLAB2.Text = "Filter Routine by LAB2";
                    }

                    if (dtlabloaderRow["Course"].ToString().Contains(course2 + "LAB1") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '1')
                    {
                        LinkButtonLAB1.Text = "Filter Routine by LAB1";
                    }
                    if (dtlabloaderRow["Course"].ToString().Contains(course2 + "LAB2") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '2')
                    {
                        LinkButtonLAB2.Text = "Filter Routine by LAB2";
                    }

                    if (dtlabloaderRow["Course"].ToString().Contains(course3 + "LAB1") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '1')
                    {
                        LinkButtonLAB1.Text = "Filter Routine by LAB1";
                    }
                    if (dtlabloaderRow["Course"].ToString().Contains(course3 + "LAB2") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '2')
                    {
                        LinkButtonLAB2.Text = "Filter Routine by LAB2";
                    }

                    if (dtlabloaderRow["Course"].ToString().Contains(course4 + "LAB1") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '1')
                    {
                        LinkButtonLAB1.Text = "Filter Routine by LAB1";
                    }
                    if (dtlabloaderRow["Course"].ToString().Contains(course4 + "LAB2") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '2')
                    {
                        LinkButtonLAB2.Text = "Filter Routine by LAB2";
                    }
                    if (dtlabloaderRow["Course"].ToString().Contains(course5 + "LAB1") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '1')
                    {
                        LinkButtonLAB1.Text = "Filter Routine by LAB1";
                    }
                    if (dtlabloaderRow["Course"].ToString().Contains(course5 + "LAB2") || dtlabloaderRow["Course"].ToString()[dtlabloaderRow["Course"].ToString().Length - 1] == '2')
                    {
                        LinkButtonLAB2.Text = "Filter Routine by LAB2";
                    }
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
        #endregion

        #region GridView RowDataBound
        private void RowDataBound(string course1, string course2, string course3, string course4, string course5, string dept)
        {

            try
            {
                foreach (GridViewRow row in GridViewWeekDay.Rows)
                {
                    Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                    GridView GridChild = (GridView)row.FindControl("GridViewChild");
                    string WeekDay = WeekDayLabel.Text.ToString();
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                    DataTable dtOld = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dtOld);
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("Course Code");
                    dtNew.Columns.Add("Teacher Initial");
                    dtNew.Columns.Add("Class Time");
                    dtNew.Columns.Add("Room No");
                    foreach (DataRow OldRow in dtOld.Rows)
                    {

                        if (OldRow["Course"].ToString().Contains(course1))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE423DLAB1"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        //if (OldRow["Course"].ToString().Contains("SWE423DLAB2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course2))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE425DLAB1"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        //if (OldRow["Course"].ToString().Contains("SWE425DLAB2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course3))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE426DLAB1"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        //if (OldRow["Course"].ToString().Contains("SWE426DLAB2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course4))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE332D2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course5))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                    }
                    GridChild.DataSource = dtNew;
                    GridChild.DataBind();
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
        #endregion

        #region GridViewMin RowDataBound
        private void RowDataBoundMin(string course1, string course2, string course3, string course4, string course5, string dept)
        {

            try
            {
                foreach (GridViewRow row in GridViewMin.Rows)
                {
                    Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                    GridView GridChild = (GridView)row.FindControl("GridViewChild");
                    string WeekDay = WeekDayLabel.Text.ToString();
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                    DataTable dtOld = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dtOld);
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("Course Code");
                    dtNew.Columns.Add("Teacher Initial");
                    dtNew.Columns.Add("Class Time");
                    dtNew.Columns.Add("Room No");
                    foreach (DataRow OldRow in dtOld.Rows)
                    {

                        if (OldRow["Course"].ToString().Contains(course1))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE423DLAB1"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        //if (OldRow["Course"].ToString().Contains("SWE423DLAB2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course2))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE425DLAB1"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        //if (OldRow["Course"].ToString().Contains("SWE425DLAB2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course3))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE426DLAB1"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        //if (OldRow["Course"].ToString().Contains("SWE426DLAB2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course4))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //if (OldRow["Course"].ToString().Contains("SWE332D2"))
                        //{
                        //    DataRow NewRow = dtNew.NewRow();
                        //    NewRow["Course Code"] = OldRow["Course"].ToString();
                        //    NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                        //    NewRow["Course Title"] = OldRow["Course"].ToString();
                        //    NewRow["Class Time"] = OldRow["Schedule"].ToString();

                        //    dtNew.Rows.Add(NewRow);
                        //}
                        if (OldRow["Course"].ToString().Contains(course5))
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();
                            //NewRow["Course Title"] = OldRow["Course"].ToString();
                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                    }
                    GridChild.DataSource = dtNew;
                    GridChild.DataBind();
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
        #endregion

        #region GridView RowDataBound For LAB1
        private void RowDataBoundLAB1(string course1, string course2, string course3, string course4, string course5, string dept)
        {
            try
            {
                foreach (GridViewRow row in GridViewWeekDay.Rows)
                {
                    Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                    GridView GridChild = (GridView)row.FindControl("GridViewChild");
                    string WeekDay = WeekDayLabel.Text.ToString();
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                    DataTable dtOld = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dtOld);
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("Course Code");
                    dtNew.Columns.Add("Teacher Initial");
                    dtNew.Columns.Add("Class Time");
                    dtNew.Columns.Add("Room No");
                    foreach (DataRow OldRow in dtOld.Rows)
                    {
                        //Course1
                        if (OldRow["Course"].ToString() == course1.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course1.ToString() + "1" || OldRow["Course"].ToString() == course1.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 2
                        if (OldRow["Course"].ToString() == course2.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course2.ToString() + "1" || OldRow["Course"].ToString() == course2.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 3
                        if (OldRow["Course"].ToString() == course3.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course3.ToString() + "1" || OldRow["Course"].ToString() == course3.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 4
                        if (OldRow["Course"].ToString() == course4.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course4.ToString() + "1" || OldRow["Course"].ToString() == course4.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                        //Course 5
                        if (OldRow["Course"].ToString() == course5.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course5.ToString() + "1" || OldRow["Course"].ToString() == course5.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                    }
                    GridChild.DataSource = dtNew;
                    GridChild.DataBind();
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
        #endregion

        #region GridView RowDataBound For LAB2
        private void RowDataBoundLAB2(string course1, string course2, string course3, string course4, string course5, string dept)
        {
            try
            {
                foreach (GridViewRow row in GridViewWeekDay.Rows)
                {
                    Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                    GridView GridChild = (GridView)row.FindControl("GridViewChild");
                    string WeekDay = WeekDayLabel.Text.ToString();
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                    DataTable dtOld = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dtOld);
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("Course Code");
                    dtNew.Columns.Add("Teacher Initial");
                    dtNew.Columns.Add("Class Time");
                    dtNew.Columns.Add("Room No");
                    foreach (DataRow OldRow in dtOld.Rows)
                    {
                        //Course1
                        if (OldRow["Course"].ToString() == course1.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course1.ToString() + "2" || OldRow["Course"].ToString() == course1.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 2
                        if (OldRow["Course"].ToString() == course2.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course2.ToString() + "2" || OldRow["Course"].ToString() == course2.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 3
                        if (OldRow["Course"].ToString() == course3.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course3.ToString() + "2" || OldRow["Course"].ToString() == course3.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 4
                        if (OldRow["Course"].ToString() == course4.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course4.ToString() + "2" || OldRow["Course"].ToString() == course4.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                        //Course 5
                        if (OldRow["Course"].ToString() == course5.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course5.ToString() + "2" || OldRow["Course"].ToString() == course5.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                    }
                    GridChild.DataSource = dtNew;
                    GridChild.DataBind();
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
        #endregion

        #region GridViewMin RowDataBound For LAB1
        private void RowDataBoundLAB1Min(string course1, string course2, string course3, string course4, string course5, string dept)
        {
            try
            {
                foreach (GridViewRow row in GridViewMin.Rows)
                {
                    Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                    GridView GridChild = (GridView)row.FindControl("GridViewChild");
                    string WeekDay = WeekDayLabel.Text.ToString();
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                    DataTable dtOld = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dtOld);
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("Course Code");
                    dtNew.Columns.Add("Teacher Initial");
                    dtNew.Columns.Add("Class Time");
                    dtNew.Columns.Add("Room No");
                    foreach (DataRow OldRow in dtOld.Rows)
                    {
                        //Course1
                        if (OldRow["Course"].ToString() == course1.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course1.ToString() + "1" || OldRow["Course"].ToString() == course1.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 2
                        if (OldRow["Course"].ToString() == course2.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course2.ToString() + "1" || OldRow["Course"].ToString() == course2.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 3
                        if (OldRow["Course"].ToString() == course3.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course3.ToString() + "1" || OldRow["Course"].ToString() == course3.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 4
                        if (OldRow["Course"].ToString() == course4.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course4.ToString() + "1" || OldRow["Course"].ToString() == course4.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                        //Course 5
                        if (OldRow["Course"].ToString() == course5.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course5.ToString() + "1" || OldRow["Course"].ToString() == course5.ToString() + "LAB1")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                    }
                    GridChild.DataSource = dtNew;
                    GridChild.DataBind();
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
        #endregion

        #region GridViewMin RowDataBound For LAB2
        private void RowDataBoundLAB2Min(string course1, string course2, string course3, string course4, string course5, string dept)
        {
            try
            {
                foreach (GridViewRow row in GridViewMin.Rows)
                {
                    Label WeekDayLabel = (Label)row.FindControl("LabelDistinctDay");
                    GridView GridChild = (GridView)row.FindControl("GridViewChild");
                    string WeekDay = WeekDayLabel.Text.ToString();
                    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection con = new SqlConnection(CS);
                    string sql = "SELECT * FROM " + dept + " WHERE Day='" + WeekDay + "'";
                    DataTable dtOld = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dtOld);
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("Course Code");
                    dtNew.Columns.Add("Teacher Initial");
                    dtNew.Columns.Add("Class Time");
                    dtNew.Columns.Add("Room No");
                    foreach (DataRow OldRow in dtOld.Rows)
                    {
                        //Course1
                        if (OldRow["Course"].ToString() == course1.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course1.ToString() + "2" || OldRow["Course"].ToString() == course1.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 2
                        if (OldRow["Course"].ToString() == course2.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course2.ToString() + "2" || OldRow["Course"].ToString() == course2.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 3
                        if (OldRow["Course"].ToString() == course3.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course3.ToString() + "2" || OldRow["Course"].ToString() == course3.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }


                        //Course 4
                        if (OldRow["Course"].ToString() == course4.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course4.ToString() + "2" || OldRow["Course"].ToString() == course4.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        //Course 5
                        if (OldRow["Course"].ToString() == course5.ToString())
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }
                        if (OldRow["Course"].ToString() == course5.ToString() + "2" || OldRow["Course"].ToString() == course5.ToString() + "LAB2")
                        {
                            DataRow NewRow = dtNew.NewRow();
                            NewRow["Course Code"] = OldRow["Course"].ToString();
                            NewRow["Teacher Initial"] = OldRow["Teacher"].ToString();

                            NewRow["Class Time"] = OldRow["Schedule"].ToString();
                            NewRow["Room No"] = OldRow["Class"].ToString();

                            dtNew.Rows.Add(NewRow);
                        }

                    }
                    GridChild.DataSource = dtNew;
                    GridChild.DataBind();
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
        #endregion

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
            else if (ti == "AST")
                return "Atia Sanjida Talukdar";
            else if (ti == "SMR")
                return "Syed Mizanur Rahman";
            else if (ti == "RK")
                return "Rashed Karim";
            else if (ti == "DAK")
                return "Dr. Sk. Abdul Kader Arafin";
            else if (ti == "MIH")
                return "Mohammad Ikbal Hossain";
            else if (ti == "DNPB")
                return "Dr. Neil P. Balba";
            else if (ti == "TBA")
                return "To be announced";
            else
                return "";
        }
        #endregion

        #region Get The HeaderText For the GridView && GridViewMin
        public string HeaderText()
        {
            HttpCookie gatheredCookie = Request.Cookies["CourseCodes"];
            try
            {
                if (gatheredCookie["semester"].ToString() == "")
                {
                    GridViewWeekDay.ShowHeader = false;
                    GridViewMin.ShowHeader = false;
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

        #endregion
    }
}