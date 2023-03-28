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

namespace CadastroContato_2_Verdadeiro
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

        private void bt_CadastroContato_Click(object sender, RoutedEventArgs e)
        {
            var form = new CadastroContato();
            form.ShowDialog();
        }

        private void bt_Lista_Contatos_Click(object sender, RoutedEventArgs e)
        {
            var form = new ListaContatos();
            form.ShowDialog();
        }
    }
}
