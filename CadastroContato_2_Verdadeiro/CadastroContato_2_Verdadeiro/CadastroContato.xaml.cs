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
using static System.Net.WebRequestMethods;
using MySql.Data.MySqlClient;

namespace CadastroContato_2_Verdadeiro
{
    /// <summary>
    /// Lógica interna para CadastroContato.xaml
    /// </summary>
    public partial class CadastroContato : Window
    {
        private MySqlConnection _conexao;
        private string sexoDado;
        public CadastroContato()
        {
            InitializeComponent();
            txtEmail.IsEnabled= false;
            txtNome.IsEnabled= false;
            txtTelefone.IsEnabled= false;
            btCancelar.IsEnabled= false;
            btSalvar.IsEnabled= false;
            dtpDataNascimento.IsEnabled= false;
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_db;user=root;password=root;port=3360;";
            _conexao = new MySqlConnection(conexaoString);

            _conexao.Open();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.IsEnabled = true;
            txtNome.IsEnabled = true;
            txtTelefone.IsEnabled = true;
            btCancelar.IsEnabled = true;
            btSalvar.IsEnabled = true;
            dtpDataNascimento.IsEnabled = true;
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

            txtEmail.IsEnabled = false;
            txtNome.IsEnabled = false;
            txtTelefone.IsEnabled = false;
            btCancelar.IsEnabled = false;
            btSalvar.IsEnabled = false;
            dtpDataNascimento.IsEnabled = false;

        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTelefone.Text != "" && rbSexo.Text != "" && txtNome.Text != "" && txtEmail.Text != "")
                {
                    var nome = txtNome.Text;
                    var sexo = rdSexo.Text;
                    var email = txtEmail.Text;
                    var telefone = txtTelefone.Text;

                    var data = Convert.ToDateTime(dtpDataNascimento.Text).ToString("yyyy-MM-dd");

                    var sql = "insert into contato(con_nome, con_sexo, con_email, con_telefone, con_data_nasc) values (@_nome, @_sexo, @_email, @_telefone, @_data_nasc)";
                    var comando = new MySqlCommand(sql, BancoDados.connection);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.Parameters.AddWithValue("@_data_nasc", data);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Salvo com sucesso", "Sistema");

                    this.Close();

                }
                else MessageBox.Show("Prencha todo os campos", "Sistema");
            } catch (Exception ex){
                MessageBox.Show("Erro no sistema, fale com o suporte, erro: " + ex,
                            "Sistema",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
     }
}
 

