using P1_AP1_LUIS_20170581.Ui.Consultas;
using P1_AP1_LUIS_20170581.Ui.Registros;
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

namespace P1_AP1_LUIS_20170581
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

       

        private void RegistrosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAportes Aportes = new rAportes();
            Aportes.Show();
        }

        private void ConsultaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cAportes consulta = new cAportes();
            consulta.Show();
        }
    }
}
