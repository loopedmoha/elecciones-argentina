using DatosEleccionesArgentina.models;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatosEleccionesArgentina.controllers
{
    class PartidoController
    {
        private static PartidoController instance;

        public List<Partido> partidos{ get; set; }
        public string rutaCsv;
        public string rutaExcel;


        ////////////////////////////////////////////////
        ///    //ID;Partido;Siglas;Candidato;%Voto;Color

        private PartidoController() {

            rutaCsv = "C:\\TrabajosIPF\\EleccionesArgentina\\partidos.csv";
            rutaExcel = "C:\\TrabajosIPF\\EleccionesArgentina\\partidos.xlsx";

            partidos = new List<Partido>();
            LoadPartidos();
        }

        public static PartidoController GetInstance()
        {
            if (instance == null)
            {
                instance = new PartidoController();
            }
            return instance;
        }

        public void UpdatePartido(int Id, double voto)
        {
            var index = partidos.FindIndex(x =>  x.Id == Id+1);
            partidos[index].Voto = voto;
        }
        public void LoadPartidos()
        {
            bool retry = true;
            do
            {
                try
                {
                    var lines = (File.ReadAllLines(rutaCsv));
                    foreach (var line in lines)
                    {
                        var fields = line.Split(";");
                        //var n = double.Parse(fields[4]);
                        var partido = new Partido(int.Parse(fields[0]), fields[1], fields[2], fields[3], double.Parse(fields[4]));
                        partidos.Add(partido);
                    }
                    retry = false;
                    ShowPartidos();
                }
                catch (Exception)
                {
                  MessageBox.Show("Archivo partidos no encontrado.");
                    
                    
                }
            } while (retry);
            
            
        }


        public void SavePartidos()
        {
            var listaLineas = "";
            partidos = partidos.OrderByDescending(x => x.Voto).ToList();
            foreach (var partido in partidos)
            {
                listaLineas += partido.ToString();
            }
            Console.WriteLine(listaLineas);
            File.WriteAllText(rutaCsv, listaLineas);

            //escribir excel
            //WriteExcel();
        }

        public void ShowPartidos()
        {
            foreach (var partido in partidos)
            {
                Console.Write(partido.ToString());
            }
        }

        public List<Partido> GetPartidos()
        {
            return partidos;
        }

        private void WriteExcel()
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Partidos");

            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Id");
            headerRow.CreateCell(1).SetCellValue("Nombre");
            headerRow.CreateCell(2).SetCellValue("Siglas");
            headerRow.CreateCell(3).SetCellValue("Candidato");
            headerRow.CreateCell(4).SetCellValue("Voto");
            headerRow.CreateCell(5).SetCellValue("Color");

            int rowIdx = 1;
            foreach (var partido in partidos)
            {
                IRow row = sheet.CreateRow(rowIdx++);
                row.CreateCell(0).SetCellValue(partido.Id);
              //  row.CreateCell(1).SetCellValue(partido.Nombre);
               // row.CreateCell(2).SetCellValue(partido.Siglas);
                row.CreateCell(3).SetCellValue(partido.Candidato);
                row.CreateCell(4).SetCellValue(partido.Voto);
                row.CreateCell(5).SetCellValue(partido.Color);
            }

            using (FileStream fs = new FileStream(rutaExcel, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }

        }
    }
}
