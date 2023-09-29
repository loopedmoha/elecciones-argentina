using DatosEleccionesArgentina.controllers;
using System;
using System.Collections.Generic;
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

            textBoxes.Add(LLAText);

            textBoxes.Add(LLAText);
            textBoxes.Add(JCText);
            textBoxes.Add(UPText);
            textBoxes.Add(HNPText);
            textBoxes.Add(FITUText);

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
                partidoController.UpdatePartido(1, double.Parse(LLAText.Text));
                partidoController.SavePartidos();
            }
                
                
        }
    }
}
