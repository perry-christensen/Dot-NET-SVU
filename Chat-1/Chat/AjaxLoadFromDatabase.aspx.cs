using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.UI.HtmlControls;

namespace Chat
{
    public partial class AjaxLoadFromDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader myReader = null;
            String Sqltext = "";
            SqlConnection cnn = new SqlConnection(@"Data Source=PERRY-PC\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            //SqlConnection cnn = new SqlConnection(@"Data Source=WIN-6LM7OUC6HFS\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            cnn.Open();

            //String currentScript = Request["script"];
            String request = Request["updateVersion"];
            //Sqltext += "SELECT * FROM tbl_ajax WHERE ajaxName = '" + currentScript + "';";
            Sqltext += "SELECT * FROM Messages WHERE MessageID > " + request + ";";

            SqlCommand myCommand = new SqlCommand(Sqltext, cnn);
            myReader = myCommand.ExecuteReader();
            
            //myReader.Read();
            //output.InnerHtml = (String)myReader["ajaxHtml"];

            //ContentPlaceHolder myContent = (ContentPlaceHolder) this.FindControl("BodyContent");
            //HtmlGenericControl op = (HtmlGenericControl) this.FindControl("output");

            while (myReader.Read())
            {
                HtmlGenericControl hgc = new HtmlGenericControl("div");
                output.Controls.Add(hgc);
                hgc.InnerHtml = (String) myReader[1];
            }
            //output.InnerHtml = (String)myReader["Message"];
            HtmlGenericControl no = new HtmlGenericControl("div");
            no.ID = "no";
            no.InnerHtml = (String) myReader[0];
            output.Controls.Add(no);
            
            myReader.Close();
        }
    }
}