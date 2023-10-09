using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.controllers
{
    internal class ProvinciaController
    {
        private List<string> partidos = new List<string>();
        public ProvinciaController() {
            partidos.Add("LLA");
            partidos.Add("JxC");
            partidos.Add("UP");
            partidos.Add("HNP");
            partidos.Add("FIT-U");
        }
    }
}
