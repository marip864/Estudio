using MySql.Data.MySqlClient;
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

namespace Estudio
{
    public partial class Form5 : Form
    {
        int opcao = 0;
        public Form5(int op)
        {
            InitializeComponent();
            if (op == 1)
            {
                button1.Visible = false;
                button2.Visible = false;
                opcao = 1;
            }
            if (op == 2)
            {
                opcao = 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text, txtNome.Text, txtEnd.Text, txtNumero.Text, txtBairro.Text, txtCompl.Text, txtCEP.Text, txtCidade.Text, txtEstado.Text, txtTel.Text, txtEmail.Text);
            if (aluno.atualizarAluno())
            {
                MessageBox.Show("Atualização realizada com sucesso!");
            }
            txtNome.Text = "";
            txtEnd.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCompl.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
            txtCPF.Enabled = true;
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text);
            if (e.KeyChar == 13)
            {
                MySqlDataReader dr = aluno.consultarAluno01();
                if (dr.Read())
                {
                    txtNome.Text = dr["nomeAluno"].ToString();
                    txtEnd.Text = dr["ruaAluno"].ToString();
                    txtNumero.Text = dr["numeroAluno"].ToString();
                    txtBairro.Text = dr["bairroAluno"].ToString();
                    txtCompl.Text = dr["complementoAluno"].ToString();
                    txtCEP.Text = dr["CEPAluno"].ToString();
                    txtCidade.Text = dr["cidadeAluno"].ToString();
                    txtEstado.Text = dr["estadoAluno"].ToString();
                    txtTel.Text = dr["telefoneAluno"].ToString();
                    txtEmail.Text = dr["emailAluno"].ToString();
                    if (opcao == 2)
                    {
                        txtNome.Enabled = true;
                        txtEnd.Enabled = true;
                        txtNumero.Enabled = true;
                        txtBairro.Enabled = true;
                        txtCompl.Enabled = true;
                        txtCEP.Enabled = true;
                        txtCidade.Enabled = true;
                        txtEstado.Enabled = true;
                        txtTel.Enabled = true;
                        txtEmail.Enabled = true;
                        button1.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                }
                DAO_Conexao.con.Close();
                int n = aluno.verificaAtivo();
                if (n == 1)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string CPF = txtCPF.Text;
                Aluno a = new Aluno(CPF);
                if (a.tornarAtivo())
                {
                    MessageBox.Show("Aluno ativado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para atualizar!");
            }
            DAO_Conexao.con.Close();

        }
    }
}
