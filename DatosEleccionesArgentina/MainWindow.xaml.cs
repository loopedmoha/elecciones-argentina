using DatosEleccionesArgentina.controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatosEleccionesArgentina
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string rutaCsv = "";
        string rutaExcel = "";
        PartidoController partidoController;
        List<TextBox> textBoxes = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
            rutaCsv = "C:\\TrabajosIPF\\EleccionesArgentina\\datos.csv";
            rutaExcel = "C:\\TrabajosIPF\\EleccionesArgentina\\datos.xlsx";
            partidoController = PartidoController.GetInstance();


            textBoxes.Add(LLAText); //0
            textBoxes.Add(JCText); //1 
            textBoxes.Add(UPText); //2
            textBoxes.Add(HNPText); //3
            textBoxes.Add(FITUText); //4

            PartidosList.ItemsSource = partidoController.GetPartidos();
            
        }


        private bool CheckFormat()
        {
            foreach (var textBox in textBoxes)
            {
                if (textBox.Text != null)
                {
                    textBox.Text = textBox.Text.Replace(',', '.');
                    try
                    {
                        var votos = double.Parse(textBox.Text);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"{textBox.Name} NO ESTA BIEN");
                        return false;
                    }
                }
            }
            return true;
        }
        private void savePartidos_Click(object sender, RoutedEventArgs e)
        {
          
            if (CheckFormat())
            {
                for(int i = 0; i<textBoxes.Count; i++)
                {
                    var a = textBoxes[i].Text;
                    partidoController.UpdatePartido(i, double.Parse(textBoxes[i].Text, CultureInfo.InvariantCulture));

                }

                partidoController.SavePartidos();
                PartidosList.Items.Refresh();
            }
                
                
        }
    }
}
