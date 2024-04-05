using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegisterForCcpap
{
    public partial class Register : System.Web.UI.Page
    {
        private static string userName = Environment.UserName;
        private static string connectionString = ConfigurationManager.ConnectionStrings["AuthConnectionString"].ToString();
        private SqlConnection cnn = new SqlConnection(connectionString);
        private SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InsererPersonne();
           
        }

        protected void InsererPersonne()
        {
            List<Personne> Personnes = new List<Personne> { };


            Personne personne = new Personne(txtNom.Text, txtPrenom.Text, txtAdresse.Text, txtDdn.Text, txtNumero.Text, DateTime.Now.ToString("d"));

            string insertSql = "INSERT INTO Personne (Nom, Prenom, Adresse, DatedeNaissance, NumeroTelephone, InsererParUsername, DateInserer) " +
                                       "VALUES (@Nom, @Prenom, @Adresse, @DatedeNaissance, @NumeroTelephone, @InsererParUsername, @DateInserer)";

            cmd = new SqlCommand(insertSql, cnn);

            cmd.Parameters.AddWithValue("@Nom", personne.Nom);
            cmd.Parameters.AddWithValue("@Prenom", personne.Prenom);
            cmd.Parameters.AddWithValue("@Adresse", personne.Adresse);
            cmd.Parameters.AddWithValue("@DatedeNaissance", personne.Datedenaissance);
            cmd.Parameters.AddWithValue("@NumeroTelephone", personne.Telephone);
            cmd.Parameters.AddWithValue("@InsererParUsername", userName);
            cmd.Parameters.AddWithValue("@DateInserer", personne.Datecree);

            try
            {
                cnn.Open();

                if (IsDataValid())
                {


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        EmptyTextbox();
                        lblMessage.Text = "Data saved successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        lblMessage.Text = "Data save failed.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Probleme d'Enregistrement: " + ex.Message;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyTextbox();
        }

        protected bool IsDataValid()
        {
            if (txtNom.Text.Trim() == String.Empty)
            {
                lblMessage.Text = " Le champ Nom ne peut pas être vide";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtNom.Focus();
                return false;
            }

            if (txtPrenom.Text.Trim() == String.Empty)
            {
                lblMessage.Text = "Le champ Prenom ne peut pas être vide";
                txtNom.Focus();
                return false;
            }

            if (txtAdresse.Text.Trim() == String.Empty)
            {
                lblMessage.Text = "Le champ Adresse ne peut pas être vide";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtNom.Focus();
                return false;
            }

            if (txtDdn.Text.Trim() == String.Empty)
            {
                lblMessage.Text = "Le champ Date de Naissance ne peut pas être vide";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtNom.Focus();
                return false;
            }

            if (txtNumero.Text.Trim() == String.Empty)
            {
                lblMessage.Text = "Le champ Numéro ne peut pas être vide, si vous n'avez pas de numéro tapez '<b>pas de numéro</b>' ";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtNom.Focus();
                return false;
            }
            return true;
        }

        protected void EmptyTextbox()
        {
            txtNom.Text = String.Empty;
            txtPrenom.Text = String.Empty;
            txtAdresse.Text = String.Empty;
            txtDdn.Text = String.Empty;
            txtNumero.Text = String.Empty;
        }
    }
}