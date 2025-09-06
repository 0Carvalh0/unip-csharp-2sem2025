using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace aula04A
{
    /// <summary>
    /// Lógica interna para SegundaJanela.xaml
    /// </summary>
    public partial class SegundaJanela : Window
    {
        private List<int> numerosPrimos;
        private int qntPrimos;

        public SegundaJanela(int qntPrimos)
        {
            InitializeComponent();

            this.qntPrimos = qntPrimos;
            this.numerosPrimos = new List<int>();
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SalvarNoBanco();
                MessageBox.Show("Números primos salvos com sucesso no banco de dados!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar no Banco de dados: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalvarNoBanco()
        {
            string connectionString = "Server=LAB9-28;Database=numerosPrimosDois;Integrated Security=true;TrustServerCertificate=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // INSERIR NÚMEROS PRIMOS
                foreach (int primo in numerosPrimos)
                {
                    string insertQuery = "INSERT INTO dboNumeros (NumeroPrimo) VALUES (@numeros)";

                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@numero", primo);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
