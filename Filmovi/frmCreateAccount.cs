using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmovi
{
    public partial class frmCreateAccount : Form
    {
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        SqlCommand komanda;

        public frmCreateAccount()
        {
            InitializeComponent();
            
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbPassword.Text)
                && !string.IsNullOrEmpty(tbConfPass.Text))
            {
                if (tbPassword.Text == tbConfPass.Text)
                {
                    try
                    {
                        konekcija.Open();
                        komanda = new SqlCommand("insert into korisnik(ime,password) values (@ime,@password)", konekcija);
                        komanda.Parameters.AddWithValue("@ime", tbUsername.Text);
                        komanda.Parameters.AddWithValue("@password", tbPassword.Text);
                        komanda.ExecuteNonQuery();
                        MessageBox.Show("Welcome " + tbUsername.Text + "!");
                        frmListaFilmova frmListaFilmova = new frmListaFilmova();
                        frmListaFilmova.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greska btn create", ex.Message);
                        return;
                    }
                    finally
                    {
                        konekcija.Close();
                    }
                }
                else
                {
                    errorProvider1.SetError(tbConfPass, "Passwords don't match");
                }
            }
        }
    }
}
