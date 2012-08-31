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
            SqlCommand myCommand = null;
            String Sqltext = "";
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-6LM7OUC6HFS\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            cnn.Open();

            if (Request["option"] == "load")
            {
                Sqltext = "INSERT INTO Messages (Message) VALUES ('" + Request["message"] + "');";
                myCommand = new SqlCommand(Sqltext, cnn);
                myCommand.ExecuteNonQuery();
            }
            else
            {
                int request = Convert.ToInt32(Request["updateVersion"]);
                Sqltext += "SELECT * FROM Messages WHERE LineID > " + request + " ORDER BY LineID DESC;";

                myCommand = new SqlCommand(Sqltext, cnn);
                myReader = myCommand.ExecuteReader();
                bool x = true;
                while (myReader.Read())
                {
                    HtmlGenericControl hgc = new HtmlGenericControl("div");
                    output.Controls.Add(hgc);
                    if (x)
                    {
                        no.InnerHtml = "" + myReader[0];
                        x = false;
                    }
                    hgc.InnerHtml = (String)myReader[1];
                }
                myReader.Close();
                cnn.Close();
            }
        }
    }
}