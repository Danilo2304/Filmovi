using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmovi
{
    public partial class frmListaFilmova : Form
    {
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        SqlCommand komanda;
        SqlDataReader reader;
        SqlDataAdapter da;
        DataSet ds;
        
        

        public frmListaFilmova()
        {
            InitializeComponent();
            
        }

        private void frmListaFilmova_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'filmoviDataSet.Film' table. You can move, or remove it, as needed.
            this.filmTableAdapter.Fill(this.filmoviDataSet.Film);

        }

        private DataTable CitajTabeluFilmovi()
        {
            ds = new DataSet();
            string s = "%" + tbSearch.Text + "%";
            komanda = new SqlCommand("select * from film where naziv like @naziv",konekcija);
            komanda.Parameters.AddWithValue("@naziv",s);
            try
            {
                konekcija.Open();
                da = new SqlDataAdapter(komanda);
                da.Fill(ds);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("greska citaj tabelu filmovi",ex.Message);
                
            }
            finally
            {
                konekcija.Close();
            }
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        private DataTable CitajTabeluFilmoviPoZanru()
        {
            ds = new DataSet();
            string s = "%" + cbZanr.Text + "%";
            komanda = new SqlCommand("select * from film where zanr like @zanr", konekcija);
            komanda.Parameters.AddWithValue("@zanr", s);
            try
            {
                konekcija.Open();
                da = new SqlDataAdapter(komanda);
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                MessageBox.Show("greska citaj tabelu filmovi", ex.Message);

            }
            finally
            {
                konekcija.Close();
            }
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }



        private void PuniDataGrid()
        {
            dataGridView1.DataSource = CitajTabeluFilmovi();
            
            dataGridView1.Columns.RemoveAt(dataGridView1.Columns.IndexOf(dataGridView1.Columns[0]));
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                PuniDataGrid(); 
            }
        }

        private void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource=CitajTabeluFilmoviPoZanru();
            dataGridView1.Columns.RemoveAt(dataGridView1.Columns.IndexOf(dataGridView1.Columns[0]));
            
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                string nazivFilma = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                frmFilm frmFilm = new frmFilm(nazivFilma);
                frmFilm.ShowDialog();

            }

        }

        
    }
}
