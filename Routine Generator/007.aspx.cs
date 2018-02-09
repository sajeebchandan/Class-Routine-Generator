using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Routine_Generator
{
    public partial class _007 : System.Web.UI.Page
    {
        OleDbConnection Econ;
        SqlConnection con;

        string constr, Query, sqlconn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void ExcelConn(string FilePath)
        {

            constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1;""", FilePath);
            Econ = new OleDbConnection(constr);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName);
                int fileSize = FileUpload1.PostedFile.ContentLength;
                if (fileSize <= 2097152)
                {
                    if (fileExtension.ToLower() == ".xlsx")
                    {
                        HttpPostedFile postedFiledoc = FileUpload1.PostedFile;
                        string fileNamedoc = Path.GetFileName(postedFiledoc.FileName);
                        postedFiledoc.SaveAs(Server.MapPath("~/") + fileNamedoc);
                        string CurrentFilePath = Server.MapPath(FileUpload1.PostedFile.FileName);
                        InsertExcelRecords(CurrentFilePath);
                    }
                    else
                    {
                        Label1.Text = "Only Excel files are supported. (" + fileExtension + ") files are not supported";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    Label1.Text = "Maximum file size 2MB has been exceeded";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Label1.Text = "Please Select a Microsoft Excel File to Upload";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void connection()
        {
            sqlconn = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            con = new SqlConnection(sqlconn);
        }


        private void InsertExcelRecords(string FilePath)
        {
            ExcelConn(FilePath);

            Query = string.Format("Select [Class] , [Course] , [Teacher] , [Schedule] , [Day], [DayID] FROM [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable Exceldt = ds.Tables[0];
            connection();
            //creating object of SqlBulkCopy    
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //assigning Destination table name    
            objbulk.DestinationTableName = "Routine";
            //Mapping Table column    
            objbulk.ColumnMappings.Add("Class", "Class");
            objbulk.ColumnMappings.Add("Course", "Course");
            objbulk.ColumnMappings.Add("Teacher", "Teacher");
            objbulk.ColumnMappings.Add("Schedule", "Schedule");
            objbulk.ColumnMappings.Add("Day", "Day");
            objbulk.ColumnMappings.Add("DayID", "DayID");
            //inserting Datatable Records to DataBase    
            con.Open();
            objbulk.WriteToServer(Exceldt);
            con.Close();
            InsertNullRecords();
            Label1.ForeColor = System.Drawing.Color.Blue;
            Label1.Text = "Data Injection Successfull";
            HyperLink1.Text = "Click here to see it in action";
            HyperLink1.NavigateUrl = "Home.aspx";
        }

        private void InsertNullRecords()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = "SELECT * FROM Routine WHERE Course IS NULL AND Teacher IS NULL";
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlBulkCopy nullBulk = new SqlBulkCopy(con);
            nullBulk.DestinationTableName = "Routine_Empty";
            nullBulk.ColumnMappings.Add("Class", "Class");
            nullBulk.ColumnMappings.Add("Course", "Course");
            nullBulk.ColumnMappings.Add("Teacher", "Teacher");
            nullBulk.ColumnMappings.Add("Schedule", "Schedule");
            nullBulk.ColumnMappings.Add("Day", "Day");
            nullBulk.ColumnMappings.Add("DayID", "DayID");
            con.Open();
            nullBulk.WriteToServer(dt);
            con.Close();
        }
    }
}