using DatosEleccionesArgentina.models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEleccionesArgentina.controllers
{
    internal class ProvinciaController
    {
        private List<string> partidos = new List<string>();
        private static ProvinciaController instance;
        private List<Provincia> provincias;
        private string rutaCsv = "C:\\TrabajosIPF\\EleccionesArgentina\\provincias.csv";
        private string rutaExcel = "C:\\TrabajosIPF\\EleccionesArgentina\\provincias.xlsx";


        public static ProvinciaController GetInstance()
        {
            if (instance == null)
                instance = new ProvinciaController();
            return instance;
        }

        
        public ProvinciaController()
        {
            partidos.Add("LLA");
            partidos.Add("JxC");
            partidos.Add("UP");
            partidos.Add("HNP");
            partidos.Add("FIT-U");

            provincias = new List<Provincia>();
        }


        public void SaveProvincias()
        {
            var listaLineas = "";
            //provincias = partidos.OrderByDescending(x => x.Voto).ToList();
            foreach (var provincia in provincias)
            {
                listaLineas += provincia.ToString();
            }
            Console.WriteLine(listaLineas);
            File.WriteAllText(rutaCsv, listaLineas);

            //escribir excel
            WriteExcel();
        }
        public List<Provincia> LoadProvincias()
        {
            var list = new List<Provincia>();
            var lines = File.ReadAllLines(rutaCsv);
            foreach (var line in lines)
            {
                var fields = line.Split(';');
                var winner = fields[2];
                if(winner == null || winner == "")
                {
                    winner = "0";
                }
                var provincia = new Provincia(
                    int.Parse(fields[0]), fields[1], int.Parse(winner));

                provincias.Add(provincia);
            }
            return list;
        }
        public void UpdateProvincia(int id, string partido)
        {
            switch (partido)
            {
                case "LLA":
                    provincias[id - 1].Ganador = 1;
                    break;
                case "JxC":
                    provincias[id - 1].Ganador = 2;
                    break;
                case "UP":
                    provincias[id - 1].Ganador = 3;
                    break;
                case "HNP":
                    provincias[id - 1].Ganador = 4;
                    break;
                case "FIT-U":
                    provincias[id - 1].Ganador = 5;
                    break;
                default:
                    break;
            }
        }

        public void WriteExcel()
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Provincias");

            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Id");
            headerRow.CreateCell(1).SetCellValue("Nombre");
            headerRow.CreateCell(2).SetCellValue("Ganador");
       

            int rowIdx = 1;
            foreach (var provincia in provincias)
            {
                IRow row = sheet.CreateRow(rowIdx++);
                row.CreateCell(0).SetCellValue(provincia.Id);
                row.CreateCell(1).SetCellValue(provincia.Nombre);
                row.CreateCell(2).SetCellValue(provincia.Ganador);
         
            }

            using (FileStream fs = new FileStream(rutaExcel, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }

        }
    }
}
