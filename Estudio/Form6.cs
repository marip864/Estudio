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
    public partial class Form6 : Form
    {

        public Form6()
        {

            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                float preco = float.Parse(txtPreco.Text);
                int qtd_alunos = int.Parse(txtAlunos.Text);
                int qtd_aulas = int.Parse(txtAulas.Text);
                Modalidade modalidade = new Modalidade(txtDescricao.Text, preco, qtd_alunos, qtd_aulas);
                if ((txtDescricao.Text == "") || (txtPreco.Text == "") || (txtAulas.Text == "") || (txtAlunos.Text == ""))
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
                else
                {

                    if (modalidade.cadastrarModalidade())
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }

                    else
                        MessageBox.Show("Erro no cadastro!");

                    txtDescricao.Text = "";
                    txtPreco.Text = "";
                    txtAlunos.Text = "";
                    txtAulas.Text = "";
                    txtPreco.Enabled = false;
                    txtAlunos.Enabled = false;
                    txtAulas.Enabled = false;
                    btnCadastrar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Os campos não podem ser nulos!");
            }

        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Modalidade m = new Modalidade();
                if (m.existeModalidade(txtDescricao.Text))
                {
                    MessageBox.Show("Já existe essa modalidade!");
                    txtDescricao.Text = "";
                }
                else
                {
                    txtAlunos.Enabled = true;
                    txtAulas.Enabled = true;
                    txtPreco.Enabled = true;
                    btnCadastrar.Enabled = true;
                }
            }

        }
    }
}
