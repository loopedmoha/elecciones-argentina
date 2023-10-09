using DatosEleccionesArgentina.controllers;
using DatosEleccionesArgentina.models;
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
        ProvinciaController provinciaController;
        List<TextBox> textBoxes = new List<TextBox>();
        public List<string> siglasPartidos { get; } = new List<string>
            {
                "LLA", "JxC", "UP", "HNP", "FIT-U"
            };

        public MainWindow()
        {
            InitializeComponent();
            rutaCsv = "C:\\TrabajosIPF\\EleccionesArgentina\\datos.csv";
            rutaExcel = "C:\\TrabajosIPF\\EleccionesArgentina\\datos.xlsx";
            partidoController = PartidoController.GetInstance();
            provinciaController = ProvinciaController.GetInstance();


            textBoxes.Add(LLAText); //0
            textBoxes.Add(JCText); //1 
            textBoxes.Add(UPText); //2
            textBoxes.Add(HNPText); //3
            textBoxes.Add(FITUText); //4


            DataContext = this;


            PartidosList.ItemsSource = partidoController.GetPartidos();
            provinciaController.LoadProvincias();

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
                for (int i = 0; i < textBoxes.Count; i++)
                {
                    var a = textBoxes[i].Text;
                    partidoController.UpdatePartido(i, double.Parse(textBoxes[i].Text, CultureInfo.InvariantCulture));

                }

                partidoController.SavePartidos();
                PartidosList.ItemsSource = partidoController.GetPartidos();
                PartidosList.Items.Refresh();
            }




        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxBuenosAires.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(1, comboBoxBuenosAires.SelectedItem.ToString());
            }

            if (comboBoxCatamarca.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(2, comboBoxCatamarca.SelectedItem.ToString());
            }

            if (comboBoxChaco.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(3, comboBoxChaco.SelectedItem.ToString());
            }
            if (comboBoxChubut.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(4, comboBoxChubut.SelectedItem.ToString());
            }
            if (comboBoxCordoba.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(5, comboBoxCordoba.SelectedItem.ToString());
            }
            if (comboBoxCorrientes.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(6, comboBoxCorrientes.SelectedItem.ToString());
            }
            if (comboBoxEntreRios.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(7, comboBoxEntreRios.SelectedItem.ToString());
            }
            if (comboBoxFormosa.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(8, comboBoxFormosa.SelectedItem.ToString());
            }
            if (comboBoxJujuy.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(9, comboBoxJujuy.SelectedItem.ToString());
            }
            if (comboBoxLaPampa.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(10, comboBoxLaPampa.SelectedItem.ToString());
            }
            if (comboBoxLaRioja.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(11, comboBoxLaRioja.SelectedItem.ToString());
            }
            if (comboBoxMendoza.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(12, comboBoxMendoza.SelectedItem.ToString());
            }
            if (comboBoxMisiones.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(13, comboBoxMisiones.SelectedItem.ToString());
            }
            if (comboBoxNeuquen.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(14, comboBoxNeuquen.SelectedItem.ToString());
            }
            if (comboBoxRioNegro.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(15, comboBoxRioNegro.SelectedItem.ToString());
            }
            if (comboBoxSalta.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(16, comboBoxSalta.SelectedItem.ToString());
            }
            if (comboBoxSanJuan.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(17, comboBoxSanJuan.SelectedItem.ToString());
            }
            if (comboBoxSanLuis.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(18, comboBoxSanLuis.SelectedItem.ToString());
            }
            if (comboBoxSantaCruz.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(19, comboBoxSantaCruz.SelectedItem.ToString());
            }
            if (comboBoxSantafe.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(20, comboBoxSantafe.SelectedItem.ToString());
            }
            if (comboBoxSantiagoEstero.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(21, comboBoxSantiagoEstero.SelectedItem.ToString());
            }
            if (comboBoxTierraFuego.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(22, comboBoxTierraFuego.SelectedItem.ToString());
            }
            if (comboBoxTucuman.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(23, comboBoxTucuman.SelectedItem.ToString());
            }

            if (comboBoxBuenosAiresCA.SelectedItem != null)
            {
                provinciaController.UpdateProvincia(24, comboBoxBuenosAiresCA.SelectedItem.ToString());
            }




            provinciaController.SaveProvincias();
        }
    }
}
