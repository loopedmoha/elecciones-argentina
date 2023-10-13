using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.models
{
     class DatosComunes
    {
        public double Escrutado { get; set; }
        public double Diferencia { get; set; }

        public DatosComunes() { }

        public DatosComunes(double escrutado, double diferencia)
        {
            Escrutado = escrutado;
            Diferencia = diferencia;
        }
    }
}
