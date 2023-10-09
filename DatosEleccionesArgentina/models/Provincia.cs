using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.models
{

    //ID;Estado;Ganador
    class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Ganador { get; set; }

        public Provincia() { }
        public Provincia(int Id, string Nombre, int Ganador) { 
            this.Id = Id;
            this.Nombre = Nombre;
            this.Ganador = Ganador;
        }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Ganador}\n";
        }
    }
}
