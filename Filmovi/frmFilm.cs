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
    public partial class frmFilm : Form
    {
        SqlConnection konekcija = new SqlConnection(Konekcija.konString);
        SqlCommand komanda;
        SqlDataReader reader;
        SqlDataAdapter da;
        DataSet ds;

        public frmFilm(string nazivFilma)
        {
            InitializeComponent();
            Image i = Image.FromFile(@"C:\Users\Danilo\Downloads\" + nazivFilma + ".jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = i;
            komanda = new SqlCommand("select * from film where naziv=@naziv",konekcija);
            try
            {
                konekcija.Open();
                komanda.Parameters.AddWithValue("@naziv",nazivFilma);
                reader = komanda.ExecuteReader();
                while(reader.Read())
                {
                    richTextBox1.AppendText(reader[1].ToString() + " (" + reader[3].ToString()
                        + ")\nGenres: " + reader[2].ToString() + "\nRuntime: " + reader[4].ToString() +
                        " minutes\nRating: " + reader[5].ToString());

                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska frmfilm", ex.Message);
                return;
            }
            finally
            {
                konekcija.Close();
            }
            richTextBox1.Font = new Font("Calibri", 18);
            
        }








        
    }
}
