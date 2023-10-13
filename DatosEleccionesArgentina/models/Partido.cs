using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.models
{
    class Partido
    {
        public int Id { get; set; }
        public string Candidato { get; set; }
        public string Apellido { get; set; }
        public string Color { get; set; }
        public double Voto { get; set; }


        public Partido()
        {

        }

        public Partido(int Id, string Candidato,string Apellido, string Color, double Voto)
        {
            this.Id = Id;
            this.Candidato = Candidato;
            this.Apellido = Apellido;
            this.Color = Color;
            this.Voto = Voto;
        }

        public override string ToString()
        {
            return $"{Id};{Candidato};{Apellido};{Color};{Voto}\n";
        }
    }


}
