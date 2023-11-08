using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form8 : Form
    {
        int opcao = 0;
        public Form8(int op)
        {
            InitializeComponent();
            Modalidade ac = new Modalidade();
            MySqlDataReader r;
            if (op == 1)
            {
                button1.Visible = false;
                button2.Visible = false;
                txtNovaDescricao.Visible = false;
                lblNovaDescricao.Visible = false;
                opcao = 1;
                r = ac.consultarTodasModalidade01();
            }
            else
            {
                button1.Text = "Atualizar";
                button2.Enabled = false;
                opcao = 2;
                r = ac.consultarTodasModalidade();
            }
            while (r.Read())
            {
                cbxDescricao.Items.Add(r["descricaoModalidade"].ToString());
            }

            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float preco = float.Parse(txtPreco.Text);
                int alunos = int.Parse(txtAlunos.Text);
                int aulas = int.Parse(txtAulas.Text);
                Modalidade m = new Modalidade(cbxDescricao.Text, preco, alunos, aulas);
                
                if (m.atualizarModalidade())
                {
                    if(!txtNovaDescricao.Text.Equals(""))
                    {
                        m.atualizarDescricaoModalidadecomNovoNome(txtNovaDescricao.Text, cbxDescricao.Text, m.selecionaId(cbxDescricao.Text), m.selecionaQtdeAulas(m.selecionaId(cbxDescricao.Text)));
                    }
                    MessageBox.Show("Atualização realizada com sucesso!");
                }
                cbxDescricao.Text = "";
                txtPreco.Text = "";
                txtAlunos.Text = "";
                txtAulas.Text = "";
                txtNovaDescricao.Text = "";
                txtNovaDescricao.Enabled = false;
                txtAlunos.Enabled = false;
                txtAulas.Enabled = false;
                txtPreco.Enabled = false;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para atualizar!");
            }
            cbxDescricao.Items.Clear();
            Modalidade ac = new Modalidade();
            MySqlDataReader r;
            r = ac.consultarTodasModalidade();
            while (r.Read())
            {
                cbxDescricao.Items.Add(r["descricaoModalidade"].ToString());
            }

            DAO_Conexao.con.Close();

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void cbxDescricao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Modalidade m = new Modalidade(cbxDescricao.Text);
            MySqlDataReader mdr = m.consultarModalidade();
            while (mdr.Read())
            {
                txtPreco.Text = mdr["precoModalidade"].ToString();
                txtAulas.Text = mdr["qtdeAulas"].ToString();
                txtAlunos.Text = mdr["qtdeAlunos"].ToString();
                txtNovaDescricao.Enabled = true;
                txtAlunos.Enabled = true;
                txtAulas.Enabled = true;
                txtPreco.Enabled = true;
            }

            DAO_Conexao.con.Close();
            if (opcao == 2)
            {
                int n = m.verificaAtivo();
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
                float preco = float.Parse(txtPreco.Text);
                int alunos = int.Parse(txtAlunos.Text);
                int aulas = int.Parse(txtAulas.Text);
                Modalidade m = new Modalidade(cbxDescricao.Text, preco, alunos, aulas);
                if (m.tornarAtivo())
                {
                    MessageBox.Show("Modalidade ativada com sucesso!");
                    button2.Enabled=false;
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
