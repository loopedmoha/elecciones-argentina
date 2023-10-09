using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.models
{
    //ID;Partido;Siglas;Candidato;%Voto;Color
    class Partido
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Siglas { get; set; }
        public string Candidato { get; set; }
        public double Voto { get; set; }
        public string Color { get; set;}

        public Partido()
        {

        }

        public Partido(int Id, string Nombre, string Siglas, string Candidato, double Voto, string Color)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Siglas = Siglas;
            this.Candidato = Candidato;
            this.Voto = Voto;
            this.Color = Color;
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Siglas};{Candidato};{Voto};{Color}\n";
        }
    }


}
