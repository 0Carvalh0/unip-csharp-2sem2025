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

namespace aula04A
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(txt_qntprimos.Text, out int qntPrimos) && qntPrimos > 0)
                {
                    var segundaJanela = new SegundaJanela(qntPrimos);
                    segundaJanela.Show();
                } else
                {
                    MessageBox.Show("Por favor, digite um número valido maior que zero.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButton.OK);
            }
        }
    }
}
