using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.controllers
{
    class DatosComunesController
    {
        private static DatosComunesController instance;
        public string rutaCsv;
        public string rutaExcel;

        private DatosComunesController() {
            rutaCsv = "C:\\TrabajosIPF\\EleccionesArgentina\\datos_comunes.csv";
            rutaExcel = "C:\\TrabajosIPF\\EleccionesArgentina\\datos_comunes.xlsx";
        }

        public static DatosComunesController GetInstance()
        {
            if (instance == null)
            {
                instance = new DatosComunesController();
            }
            return instance;
        }

        public void SaveDatosComunes() {
            //Add escrutado desde parte grafica
            string text = NormalizarDecimales(ObtenerDiferencia());
            File.WriteAllText(rutaCsv, text);
        }

        private double ObtenerDiferencia() {
            var partidos = PartidoController.GetInstance().GetPartidos();
            return partidos.Select(p=> p.Voto - partidos[1].Voto).FirstOrDefault();
        }
        private string NormalizarDecimales(double num) { 
            string text = num.ToString();
            if (text.Split(".")[1].Length > 1)
            {
                text = text.Split(".")[0] + text.Split(".")[1][0];
            }
            return text;
        }
    }
}
