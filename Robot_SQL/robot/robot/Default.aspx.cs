using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace robot
{
    public partial class _Default : System.Web.UI.Page
    {
        String robot1 = @"C:\Users\Administrator.WIN-6LM7OUC6HFS\Documents\Visual Studio 2010\Projects\robot\robot\robot1.xml", robot2 = @"C:\Users\Administrator.WIN-6LM7OUC6HFS\Documents\Visual Studio 2010\Projects\robot\robot\robot2.xml";
        Robot r1 = new Robot(), r2 = new Robot();
        XmlDocument xml1 = new XmlDocument(), xml2 = new XmlDocument();
        SqlConnection cnn = new SqlConnection(@"Data Source=WIN-6LM7OUC6HFS\MYSQL;Initial Catalog=Robot;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            String select = "Select RobotID, name from robot;";
            SqlCommand myCommand = new SqlCommand(select, cnn);
            OpenConnection();
            SqlDataReader myReader = myCommand.ExecuteReader();
            String name = "";
            int id = 0;
            ListItemCollection home = RobotHome.Items;
            ListItemCollection away = RobotAway.Items;
            ListItem def = new ListItem("Select robot");
            home.Add(def);
            away.Add(def);
            while (myReader.Read())
            {
                id = (int) myReader[0]; 
                name = (String) myReader[1];
                home.Add(name + " (ID:" + id + ")");
                away.Add(name + " (ID:" + id + ")");
            }
            ListItemCollection rounds = Rounds.Items;
            for (int i = 1; i < 11; i++)
            {
                rounds.Add("" + i);
            }           
        }

        private void OpenConnection()
        {
            cnn.Open();
        }

        private void CloseConnection()
        {
            cnn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            readFiles();
            Robot_War rw = new Robot_War();
            int rounds = Convert.ToInt32(TextBox1.Text);
            String output = rw.play(r1, r2, rounds);
            writeToFile();
            Label1.Text = output;
        }

        private void writeToFile()
        {
            //XmlDocument xml1 = new XmlDocument();
            //XmlDocument xml2 = new XmlDocument();
            xml1.GetElementsByTagName("tab").Item(0).InnerText = "" + r1.Tab;
            xml1.GetElementsByTagName("sejre").Item(0).InnerText = "" + r1.Sejre;
            xml1.GetElementsByTagName("uafgjort").Item(0).InnerText = "" + r1.Uafgjorte;
            xml2.GetElementsByTagName("tab").Item(0).InnerText = "" + r2.Tab;
            xml2.GetElementsByTagName("sejre").Item(0).InnerText = "" + r2.Sejre;
            xml2.GetElementsByTagName("uafgjort").Item(0).InnerText = "" + r2.Uafgjorte;
            xml1.Save(robot1);
            xml2.Save(robot2);
            String updateString = robotStr(r1);
            updateString += robotStr(r2);
            updateRobots(updateString);
        }

        private void updateRobots(String query)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-6LM7OUC6HFS\MYSQL;Initial Catalog=Robot;Integrated Security=True");
            cnn.Open();
            SqlCommand myCommand = new SqlCommand(query, cnn);
            myCommand.Transaction = cnn.BeginTransaction();
            myCommand.ExecuteNonQuery();
            myCommand.Transaction.Commit();
            cnn.Close();
        }

        private void readFiles()
        {
            FileUpload1.SaveAs(robot1);
            FileUpload2.SaveAs(robot2);
            //XmlDocument xml1 = new XmlDocument();
            //XmlDocument xml2 = new XmlDocument();
            xml1.Load(robot1);
            xml2.Load(robot2);
            r1 = parseFiles(xml1);
            r2 = parseFiles(xml2);
        }

        private Robot parseFiles(XmlDocument xml)
        {
            String navn = xml.GetElementsByTagName("navn").Item(0).InnerText;
            XmlNodeList list = xml.GetElementsByTagName("runde");
            int[][] skjold_vaaben = new int[list.Count][];

            for (int i = 0; i < list.Count; i++)
            {
                XmlAttributeCollection attr = list[i].Attributes;
                int[] x = new int[2];
                //skjold_vaaben[i][0] = Convert.ToInt32(attr[0].Value);
                //skjold_vaaben[i][1] = Convert.ToInt32(attr[1].Value);
                x[0] = Convert.ToInt32(attr[0].Value);
                x[1] = Convert.ToInt32(attr[1].Value);
                skjold_vaaben[i] = x;
            }
            int tab = Convert.ToInt32(xml.GetElementsByTagName("tab").Item(0).InnerText);
            int sejre = Convert.ToInt32(xml.GetElementsByTagName("sejre").Item(0).InnerText);
            int liv = Convert.ToInt32(xml.GetElementsByTagName("liv").Item(0).InnerText);
            int uafgjorte = Convert.ToInt32(xml.GetElementsByTagName("uafgjort").Item(0).InnerText);

            Robot r = new Robot();
            r.Liv = liv;
            r.Tab = tab;
            r.Sejre = sejre;
            r.Uafgjorte = uafgjorte;
            r.Skjold_Vaaben = skjold_vaaben;
            r.Name = navn;
            saveRobotToDatabase(r);
            return r;
        }

        private String robotStr(Robot r)
        {
            return "Update Robot Set Win = " + r.Sejre + ", Draw = " + r.Uafgjorte + ", Loose = " + r.Tab + " where RobotID = " + r.RID + ";";
        }

        /// <summary>
        /// This function saves new robots to the database
        /// </summary>
        /// <param name="r"></param>
        private void saveRobotToDatabase(Robot r)
        {
            String select = "SELECT TOP 1 robotID FROM robot ORDER BY robotID DESC;";
            String insertRobot = "INSERT INTO robot (Name, Life, Win, Draw, Loose) VALUES ('" + r.Name + "', " + r.Liv + ", " + r.Sejre + ", " + r.Uafgjorte + ", " + r.Tab + ");";
            String insertRound = "";
            SqlConnection cnn = new SqlConnection(@"Data Source=WIN-6LM7OUC6HFS\MYSQL;Initial Catalog=Robot;Integrated Security=True");
            cnn.Open();

            SqlCommand myCommand = new SqlCommand(insertRobot, cnn);
            myCommand.ExecuteNonQuery();
            myCommand = new SqlCommand(select, cnn);
            SqlDataReader myReader = myCommand.ExecuteReader();
            myReader.Read();
            int rID = (int)myReader["RobotID"];
            myReader.Close();

            for (int i = 0; i < r.Skjold_Vaaben.Length; i++)
            {
                insertRound += "Insert INTO round (RobotID, RoundID, Shield, Weapon) VALUES (" + rID + ", " + (i + 1) + ", " + r.Skjold_Vaaben[i][0] + ", " + r.Skjold_Vaaben[i][1] + ");";
            }

            SqlTransaction tn = cnn.BeginTransaction();
            myCommand = new SqlCommand(insertRound, cnn);
            myCommand.Transaction = tn;
            myCommand.ExecuteNonQuery();
            tn.Commit();
            cnn.Close();
            r.RID = rID;
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            readFiles();
            Regex regex = new Regex(@"\d+");
            String rID1 = RobotHome.SelectedValue;
            String rID2 = RobotAway.SelectedValue;
            Match m = regex.Match(rID1);
            int rid1 = Convert.ToInt32(m.Value);
            m = regex.Match(rID2);
            int rid2 = Convert.ToInt32(m.Value);
            int rounds = Convert.ToInt32(Rounds.Text);
            String select = GetRobot(rid1) + GetRobot(rid2);
            
            SqlCommand myCommand = new SqlCommand(select, cnn);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (rid1 == Convert.ToInt32(myReader[0]))
                {
                    r1.RID = Convert.ToInt32(myReader[0]);
                    r1.Name = Convert.ToString(myReader[1]);
                    r1.Liv = Convert.ToInt32(myReader[2]);
                    r1.Sejre = Convert.ToInt32(myReader[3]);
                    r1.Uafgjorte = Convert.ToInt32(myReader[4]);
                    r1.Tab = Convert.ToInt32(myReader[5]);
                }
                else
                {
                    r2.RID = Convert.ToInt32(myReader[0]);
                    r2.Name = Convert.ToString(myReader[1]);
                    r2.Liv = Convert.ToInt32(myReader[2]);
                    r2.Sejre = Convert.ToInt32(myReader[3]);
                    r2.Uafgjorte = Convert.ToInt32(myReader[4]);
                    r2.Tab = Convert.ToInt32(myReader[5]);
                }
            }
            int rID = (int)myReader["RobotID"];
            myReader.Close();
            //Robot_War rw = new Robot_War();
            //String output = rw.play(r1, r2, rounds);
            //Label1.Text = output;
        }

        public String GetRobot(int id)
        {
            return "Select r.RobotID, Name, Life, Win, Draw, Loose, Shield, Weapon from Robot r, Round o where r.RobotID = o.RobotID and r.RobotID = " + id + ";";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
