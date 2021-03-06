using P1_AP1_LUIS_20170581.Bll;
using P1_AP1_LUIS_20170581.Entidades;
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
using System.Windows.Shapes;

namespace P1_AP1_LUIS_20170581.Ui.Consultas
{
    /// <summary>
    /// Interaction logic for cAportes.xaml
    /// </summary>
    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }

      

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0: //listado
                    listado = AportesBll.GetAportes();

                    break;
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
