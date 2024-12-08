using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmovi
{
    public class Film
    {
        private int filmID;
        private string naziv, zanr;
        private int godinaIzdanja;
        private float vrijemeTrajanja;
        private float ocjena;
        private Image image;

        public Film()
        {

        }

        Film(int filmID, string naziv, string zanr, int godinaIzdanja, float vrijemeTrajanja, float ocjena, Image image)
        {
            this.filmID = filmID;
            this.naziv = naziv;
            this.zanr = zanr;
            this.godinaIzdanja = godinaIzdanja;
            this.vrijemeTrajanja = vrijemeTrajanja;
            this.ocjena = ocjena;
            this.image = image;
        }

        public int FilmID { get => filmID; set => filmID = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Zanr { get => zanr; set => zanr = value; }
        public int GodinaIzdanja { get => godinaIzdanja; set => godinaIzdanja = value; }
        public float VrijemeTrajanja { get => vrijemeTrajanja; set => vrijemeTrajanja = value; }
        public float Ocjena { get => ocjena; set => ocjena = value; }
        public Image Image { get => image; set => image = value; }

        
    }
}
