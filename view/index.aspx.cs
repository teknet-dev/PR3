using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.Mail;
using System.Web.UI;

namespace PR3.view
{
    public partial class index : System.Web.UI.Page
    {
        private const string mailEnvoyeur = "you@moov.mg";
        private const string sujetMail = "Récupération du mot de passe. A ne pas répondre" ;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionModel.SessionID == "")
            {
                try
                {
                    Page.Session.Add("info",true);
                }
                catch { }
            }

            if ((SessionModel.SessionID == Session.SessionID) && (SessionModel.Connecté))
            {
                Response.Redirect("clp.aspx");
            }
            else if (SessionModel.SessionID != Session.SessionID)
            {
                SessionModel.Connecté = false;
                SessionModel.SessionID = Session.SessionID;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            login.Text = "";
            passe.Text = "";
        }
        private bool IsValide()
        {
            bool retval = (passe.Text.Length >= 1) && (login.Text.Length >= 1) ;

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

                string query = "SELECT  * FROM user  where loginUser='" + log + "'and mdpUser='" + pass + "' ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!SessionModel.Set(conn,reader))
                    {
                        // Cet utilisateur est déjà connecté en ce moment
                        // Codez ici pour gérer cela
                    }


                    Response.Redirect("clp.aspx");
                }
                else
                {
                    SessionModel.Connecté = false;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('incorrect!');</script>");
                }
            }
        }

        protected void LinkForgotten_Click(object sender, EventArgs e)
        {
            passe.Text = "";
            EditerIndex(true);
        }

        private void EditerIndex(bool oubli=false)
        {
            lMOub.Visible = oubli;
            Mdp.Visible = !oubli;
            lMail.Visible = oubli;
            passe.Visible = !oubli;
            mail.Visible = oubli;
            Button1.Visible = !oubli;
            Button2.Visible = !oubli;
            Button3.Visible = oubli;
            Button4.Visible = oubli;
            LinkForgotten.Visible = !oubli;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string loginClient = login.Text;
            string adresseClient = mail.Text;

            if ((loginClient == "") || (adresseClient == ""))
            {
                ClientScript.RegisterStartupScript(GetType(),"Erreur","alert('Les champs \"login\" et \"Adresse e-mail\"sont obligatoires')",true);
                return;
            }

            MailMessage email = new MailMessage();
            email.From = mailEnvoyeur;
            email.To = adresseClient ;
            email.Subject = sujetMail;
            email.Body = "Ceci est un test provenant du site web \"calepinage\", est-ce-que tu l'a reçu?\nOK\nA bientôt..." ;
            email.Priority = MailPriority.High;
            SmtpMail.SmtpServer = "smtp.moov.mg" ;
            try
            {
                SmtpMail.Send(email);
            }
            catch (Exception ex)
            {
                lMOub.Text = ex.Message;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EditerIndex();
        }
    }
}