using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Chat
{
    public partial class AjaxLoadFromDatabase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataReader myReader = null;
            String Sqltext = "";
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-6LM7OUC6HFS\MYSQL;Initial Catalog=HelloWorld;Integrated Security=True");
            cnn.Open();

            String currentScript = Request["script"];
            Sqltext += "SELECT * FROM tbl_ajax WHERE ajaxName = '" + currentScript + "';";

            SqlCommand myCommand = new SqlCommand(Sqltext, cnn);
            myReader = myCommand.ExecuteReader();
            
            String tmpText = "";
            myReader.Read();
            output.InnerHtml = (String)myReader["ajaxHtml"];
            
            myReader.Close();
        }
    }
}