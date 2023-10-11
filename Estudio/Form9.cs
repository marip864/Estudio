using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            Modalidade con_mod = new Modalidade();
            MySqlDataReader r = con_mod.consultarTodasModalidade();
            while(r.Read())
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();
        }

        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                int qtd_alunos = int.Parse(txtAlunos.Text);
                string professor = txtProfessor.Text;
                string dia_semana = txtDiaSemana.Text;
                string horas = txtHoras.Text;
                Turma t = new Turma();
                int modalidade = t.selecionaId(txtModalidade.Text);
                Turma turma = new Turma(professor,dia_semana,horas,modalidade,qtd_alunos);
                if (turma.cadastrarTurma())
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtAlunos.Text = "";
                    txtProfessor.Text = "";
                    txtDiaSemana.Text = "";
                    txtHoras.Text = "";
                    txtModalidade.Text = "";
                }

                else
                    MessageBox.Show("Erro no cadastro!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Os campos não podem ser nulos!");
            }
        }

        private void mostra(string m)
        {
            txtModalidade.Text = m;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mostra(getModalidadeId());
        }

        private string getModalidadeId()
        {
            return dataGridView1.CurrentCell.Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
