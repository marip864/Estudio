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
    public partial class Form11 : Form
    {
        int opcao;
        public Form11(int op)
        {
            InitializeComponent();
            if (op == 2)
            {
                btnAtualizar.Visible = false;
                btnAtivo.Visible = false;
                opcao = 2;
            }
            else
            {
                btnAtualizar.Text = "Atualizar";
                btnAtivo.Enabled = false;
                opcao = 1;
            }
            Turma con_t = new Turma();

            MySqlDataReader r = con_t.consultarTodasTurmas02();

            while (r.Read())
            {
                dataGridView1.Rows.Add(r["idEstudio_Turma"].ToString(), r["nomeTurma"].ToString(), r["professorTurma"].ToString(), r["diasemanaTurma"].ToString(), r["horaTurma"].ToString(), r["nalunosmatriculadosTurma"].ToString());
            }

            DAO_Conexao.con.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;
                string nome = "";
                Turma t = new Turma();
                int i = t.consultarTodasTurmas01(txtModalidade.Text);
                string m = t.selecionaModalidade(i);

                if ((cbxDiaSemana.SelectedIndex == 0) || (cbxDiaSemana.SelectedIndex == 1) || (cbxDiaSemana.SelectedIndex == 2))
                {
                    cont = 1;
                    nome = string.Concat(m + " - " + cont.ToString() + "x");
                }
                if ((cbxDiaSemana.SelectedIndex == 3) || (cbxDiaSemana.SelectedIndex == 4) || (cbxDiaSemana.SelectedIndex == 5))
                {
                    cont = 2;
                    nome = string.Concat(m + " - " + cont.ToString() + "x");
                }
                Turma turma = new Turma(int.Parse(txtAlunos.Text), txtProfessor.Text, cbxDiaSemana.Text, txtHora.Text, int.Parse(txtId.Text), nome);
                

                if (turma.consultarIgual(txtProfessor.Text))
                {
                    MessageBox.Show("O professor já tem aula nesse dia e horário!");
                }
                else
                {
                    if (turma.atualizarTurma())
                    {
                        MessageBox.Show("Atualização realizada com sucesso!");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para atualizar!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnAtivo_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                Turma t = new Turma(id);
                if (t.tornarAtivo())
                {
                    MessageBox.Show("Turma ativada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para atualizar!");
            }
            DAO_Conexao.con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Enabled = false;
            txtModalidade.Enabled = false;
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtModalidade.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtProfessor.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbxDiaSemana.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtHora.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAlunos.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Turma t = new Turma(int.Parse(txtId.Text));
            if (opcao == 1)
            {
                int n = t.verificaAtivo();
                if (n == 1)
                {
                    btnAtivo.Enabled = true;
                }
                else
                {
                    btnAtivo.Enabled = false;
                }
            }
            if (opcao == 2)
            {
                txtProfessor.Enabled = false;
                cbxDiaSemana.Enabled = false;
                txtHora.Enabled = false;
                txtAlunos.Enabled = false;
            }
        }
    }
}
