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
                Modalidade modalidade = new Modalidade(txtDescricao.Text,preco,qtd_alunos,qtd_aulas);
                if (modalidade.cadastrarModalidade())
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtDescricao.Text = "";
                    txtPreco.Text = "";
                    txtAlunos.Text = "";
                    txtAulas.Text = "";
                }
                    
                else
                    MessageBox.Show("Erro no cadastro!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Os campos não podem ser nulos!");
            }
            
        }
    }
}
