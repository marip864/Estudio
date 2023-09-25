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
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text, txtNome.Text, txtEnd.Text, txtNumero.Text, txtBairro.Text, txtCompl.Text, txtCEP.Text, txtCidade.Text, txtEstado.Text, txtTel.Text, txtEmail.Text);
            if(aluno.atualizarAluno() )
            {
                MessageBox.Show("Atualização realizada com sucesso!");
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text);
            if(e.KeyChar==13)
            {
                MySqlDataReader dr = aluno.consultarAluno01();
                if(dr.Read())
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
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                }
            }
            DAO_Conexao.con.Close();
        }
    }
}
