using SemanticIntellectualInformationalSystem.LogicalOutputMechanism;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SemanticIntellectualInformationalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string carQ, country, engineType, carET;
        LOM lom = new LOM();
        public MainWindow()
        {


            //Проверка
            /*List<string> countries = new List<string> { "Япония", "Германия", "Италия"};
            foreach(string country in countries)
            {
                List<string> cars = lom.WhichCarsMadeInCountry(country);
                foreach (string car in cars)
                {
                System.Windows.Forms.MessageBox.Show(car);
                System.Windows.MessageBox.Show(lom.WhatIsQualityOfCar(carQ));
                System.Windows.Forms.MessageBox.Show(lom.IsEngineTypeAPartOfCar(engineType, carET).ToString());
                }
            }*/     //InitializeComponent();
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Answer1_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ItemCarQ = (ComboBoxItem)comboBoxQuality.SelectedItem;
            carQ = ItemCarQ.Content.ToString();

            MessageBox.Show(lom.WhatIsQualityOfCar(carQ));
        }

        private void Answer2_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ItemCountry = (ComboBoxItem)comboBoxCountry.SelectedItem;
            country = ItemCountry.Content.ToString();

            List<string> cars = lom.WhichCarsMadeInCountry(country);
            foreach (string car in cars)
            {
                MessageBox.Show(car);
            }
        }

        private void Answer3_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ItemET = (ComboBoxItem)comboBoxET.SelectedItem;
            engineType = ItemET.Content.ToString();
            ComboBoxItem ItemETCar = (ComboBoxItem)comboBoxETCars.SelectedItem;
            carET = ItemETCar.Content.ToString();

            MessageBox.Show(lom.IsEngineTypeAPartOfCar(engineType, carET).ToString());

        }


    }
}

