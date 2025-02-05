using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PostalRatesApp
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, decimal> servicePrices = new Dictionary<string, decimal>
        {
            { "Pocztówka", 1.0m },
            { "List", 2.5m },
            { "Paczka", 10.0m }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool ValidatePostalCode(string postalCode)
        {
            return postalCode.Length == 5 && postalCode.All(char.IsDigit);
        }

        private void CheckPrice_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedService = serviceTypesPanel.Children
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.IsChecked == true);

            if (selectedService == null)
            {
                MessageBox.Show("Proszę wybrać rodzaj przesyłki.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string postalCode = PostalCodeTextBox.Text.Trim();

            if (!ValidatePostalCode(postalCode))
            {
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            decimal price = servicePrices[selectedService.Content.ToString()];
            PriceLabel.Content = $"Cena: {price} zł";
        }
    }
}