using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastrocliente    
{
        public partial class Form1 : Form
        {
            SqlConnection conexao;
            SqlCommand comando;
            SqlDataAdapter da;
            SqlDataReader dr;

        string strSQL;
        public Form1()
            {
                InitializeComponent();
            }
        // Botão Novo
            private void btnNovo_Click(object sender, EventArgs e)
            {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T3S475D\SQLEXPRESS; Database = Cliente; Trusted_Connection = True;");

                strSQL = "INSERT INTO cad_cliente (ID, NOME, NASCIMENTO, TELEFONE1, TELEFONE2, ENDERECO1, ENDERECO2, REDE, CPF, RG) VALUES (@ID, @NOME, @DATA, @TELEFONE1, @TELEFONE2, @ENDERECO1, @ENDERECO2, @REDE, @CPF, @RG)";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtId.Text);
                comando.Parameters.AddWithValue("@NOME ", txtNome.Text);
                comando.Parameters.AddWithValue("@DATA", txtData.Text);
                comando.Parameters.AddWithValue("@TELEFONE1", txtTelefone1.Text);
                comando.Parameters.AddWithValue("@TELEFONE2", txtTelefone2.Text);
                comando.Parameters.AddWithValue("@ENDERECO1", txtEndereco1.Text);
                comando.Parameters.AddWithValue("@ENDERECO2", txtEndereco2.Text);
                comando.Parameters.AddWithValue("@REDE", txtRede.Text);
                comando.Parameters.AddWithValue("@CPF", txtCpf.Text);
                comando.Parameters.AddWithValue("@RG", txtRg.Text);
               
                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
                

        }
        // Botão Exibir
        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T3S475D\SQLEXPRESS; Database = Cliente; Trusted_Connection = True;");

                strSQL = "SELECT * FROM CAD_CLIENTE";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        // Botão de consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T3S475D\SQLEXPRESS; Database = Cliente; Trusted_Connection = True;");

                strSQL = "SELECT * FROM CAD_CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtId.Text);

                conexao.Open();
                dr = comando.ExecuteReader();


                while (dr.Read())
                {
                    txtNome.Text = (string)dr["nome"];
                    txtTelefone1.Text = Convert.ToString(dr["telefone1"]);
                    txtTelefone2.Text = Convert.ToString(dr["telefone2"]);
                    txtEndereco1.Text = Convert.ToString(dr["endereco1"]);
                    txtEndereco2.Text = Convert.ToString(dr["endereco2"]);
                    txtRede.Text = Convert.ToString(dr["rede"]);
                    txtCpf.Text = Convert.ToString(dr["cpf"]);
                    txtRg.Text = Convert.ToString(dr["rg"]);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        //Botao editar
        private void btbEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T3S475D\SQLEXPRESS; Database = Cliente; Trusted_Connection = True;");

                strSQL = "UPDATE cad_cliente SET NOME = @NOME, TELEFONE1 = @TELEFONE1, TELEFONE2 = @TELEFONE2, ENDERECO1 = @ENDERECO1, ENDERECO2 = @ENDERECO2, REDE = @REDE, CPF = @CPF, RG = @RG WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtId.Text);
                comando.Parameters.AddWithValue("@NOME ", txtNome.Text);
                comando.Parameters.AddWithValue("@TELEFONE1", txtTelefone1.Text);
                comando.Parameters.AddWithValue("@TELEFONE2", txtTelefone2.Text);
                comando.Parameters.AddWithValue("@ENDERECO1", txtEndereco1.Text);
                comando.Parameters.AddWithValue("@ENDERECO2", txtEndereco2.Text);
                comando.Parameters.AddWithValue("@REDE", txtRede.Text);
                comando.Parameters.AddWithValue("@CPF", txtCpf.Text);
                comando.Parameters.AddWithValue("@RG", txtRg.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        //botão excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T3S475D\SQLEXPRESS; Database = Cliente; Trusted_Connection = True;");

                strSQL = "DELETE cad_cliente WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtId.Text);
                

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
    }
}

