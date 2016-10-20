using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace PR3.view
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            login.Text = "";
            passe.Text = "";
        }
        private bool IsValide()
        {
            bool retval = true;


            if (passe.Text.Length < 1) retval = false;
            if (login.Text.Length < 1) retval = false;

            return retval;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (!IsValide())
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Champ Obligatoire!');</script>");


            }
            else
            {
                string log = login.Text;
                string pass = passe.Text;
                MySqlConnection conn = null;
                string _strConn = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
                conn = new MySqlConnection(_strConn);
                conn.Open();

                string query = "SELECT  * FROM user  where login='" + log + "'and pass='" + pass + "' ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

             
                    if (reader.Read())
                    {

                        Response.Redirect("clp.aspx");


                    }
                    else
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('incorrect!');</script>");


                    }
                
            }
        }
    }
}