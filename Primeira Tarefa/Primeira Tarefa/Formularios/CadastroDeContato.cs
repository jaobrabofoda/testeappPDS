using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Primeira_Tarefa.RegrasDeNegocio;
using MySql.Data.MySqlClient;

namespace Primeira_Tarefa.Formularios
{
    public partial class CadastroDeContato : Form
    {
        private MySqlConnection _conexao;
        
        public CadastroDeContato()
        {
            InitializeComponent();

            Conexao();

            edTelefone.Enabled = false;
            edNome.Enabled = false;
            edEmail.Enabled = false;
            dtpNascimento.Enabled = false;
            cbSexo.Enabled = false;



        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            edTelefone.Enabled = false;
            edNome.Enabled = false;
            edEmail.Enabled = false;
            dtpNascimento.Enabled = false;
            cbSexo.Enabled = false;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            edTelefone.Enabled = true;
            edNome.Enabled = true;
            edEmail.Enabled = true;
            dtpNascimento.Enabled = true;
            cbSexo.Enabled = true;
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            var nome = edNome.Text;
            var email = edEmail.Text;
            var sexo = cbSexo.Text;
            var data_nascimento = dtpNascimento.Text;
            var telefone = edTelefone.Text;

            var sql = "INSERT INTO contato (nome_con , email_con , sexo_con , data_nascimento_con , telefone_con) VALUES (@_nome , @_email , @_sexo , @_data_nascimento , @_telefone)";
            var comando = new MySqlCommand(sql, _conexao);

            comando.Parameters.AddWithValue("@_nome", nome);
            comando.Parameters.AddWithValue("@_email", email);
            comando.Parameters.AddWithValue("@_sexo", sexo);
            comando.Parameters.AddWithValue("@_data_nascimento", data_nascimento);
            comando.Parameters.AddWithValue("@_telefone", telefone);
            comando.ExecuteNonQuery();

            _conexao.Close();
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            edTelefone.Clear();
            edNome.Clear();
            edEmail.Clear();
            
            edTelefone.Enabled = false;
            edNome.Enabled = false;
            edEmail.Enabled = false;
            dtpNascimento.Enabled = false;
            cbSexo.Enabled = false;
        }

        private void CadastroDeContato_Load(object sender, EventArgs e)
        {

        }
    }
}
