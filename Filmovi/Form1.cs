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
    public partial class Form1 : Form
    {

        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        SqlCommand komanda;
        SqlDataReader reader;
        SqlDataAdapter da;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void lbCreateAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
                frmCreateAccount frmCreateAccount = new frmCreateAccount();
                frmCreateAccount.ShowDialog();
            
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbUserName.Text))
            {
                errorProvider1.SetError(tbUserName, "Required");
                tbUserName.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Required");
                tbPassword.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ProvjeraPassworda())
            {
                frmListaFilmova frmListaFilmova = new frmListaFilmova();
                frmListaFilmova.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }

        private bool ProvjeraPassworda()
        {
            bool tacno = false;

            komanda = new SqlCommand("select * from korisnik where ime=@ime and password=@password",konekcija);
            komanda.Parameters.AddWithValue("@ime",tbUserName.Text);
            komanda.Parameters.AddWithValue("@password",tbPassword.Text);
            try
            {
                konekcija.Open();
                ds = new DataSet();
                da = new SqlDataAdapter(komanda);
                da.Fill(ds);

            }
            catch(Exception ex)
            {
                MessageBox.Show("greska btn login",ex.Message);
                
            }
            finally
            {
                konekcija.Close();
            }
            bool loginSuccessful = ((ds.Tables.Count>0)&&(ds.Tables[0].Rows.Count>0));

            if (loginSuccessful)
            {
                tacno= true;
            }
            else
            {
                tacno= false;
            }
            return tacno;
        }

    }
}
