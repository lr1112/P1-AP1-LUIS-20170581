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

namespace P1_AP1_LUIS_20170581.Ui.Registros
{
    /// <summary>
    /// Interaction logic for cAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        private Aportes rol = new Aportes();
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = rol;
        }
        private void Limpiar()
        {
            this.rol = new Aportes();
            this.DataContext = rol;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte la fecha", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (ConceptoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ha ocurrido un error, inserte la descripcion", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Aportess = AportesBll.Buscar(Utilidades.ToInt(AporteIdTextBox.Text));
            if (Aportess != null)
                this.rol = Aportess;
            else
            {
                this.rol = new Aportes();
                MessageBox.Show("No se ha Encontrado", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.rol;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (AportesBll.ExisteConcepto(ConceptoTextBox.Text))
            {
                MessageBox.Show("Ya existe este rol. Ingrese otro", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var paso = AportesBll.Guardar(this.rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBll.Eliminar(Utilidades.ToInt(AporteIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
