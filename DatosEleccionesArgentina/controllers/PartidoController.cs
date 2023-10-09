using DatosEleccionesArgentina.models;
using Microsoft.Win32;
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

        public List<Partido> partidos;
        public string rutaCsv;
        public string rutaExcel;


        ////////////////////////////////////////////////
        ///    //ID;Partido;Siglas;Candidato;%Voto;Color

        public PartidoController() {

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
                        var n = double.Parse(fields[4]);
                        var partido = new Partido(int.Parse(fields[0]), fields[1], fields[2], fields[3], double.Parse(fields[4]), fields[5]);
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
            foreach (var partido in partidos)
            {
                listaLineas += partido.ToString();
            }
            Console.WriteLine(listaLineas);
            File.WriteAllText(rutaCsv, listaLineas);
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
    }
}
