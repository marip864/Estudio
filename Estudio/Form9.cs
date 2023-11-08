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
            MySqlDataReader r = con_mod.consultarTodasModalidade01();
            while (r.Read())
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                int cont = 0;
                string nome = "";
                string professor = txtProfessor.Text;
                string dia_semana = cbxDiaSemana.Text;
                string horas = txtHoras.Text;
                Turma t = new Turma();
                int modalidade = t.selecionaId(txtModalidade.Text);
                if ((cbxDiaSemana.SelectedIndex == 0) || (cbxDiaSemana.SelectedIndex == 1) || (cbxDiaSemana.SelectedIndex == 2))
                {
                    cont = 1;
                    nome = string.Concat(txtModalidade.Text + " - " + cont.ToString() + "x");
                }
                if ((cbxDiaSemana.SelectedIndex == 3) || (cbxDiaSemana.SelectedIndex == 4) || (cbxDiaSemana.SelectedIndex == 5))
                {
                    cont = 2;
                    nome = string.Concat(txtModalidade.Text + " - " + cont.ToString() + "x");
                }
                Turma turma = new Turma(professor, dia_semana, horas, modalidade, nome);
                Modalidade m1 = new Modalidade();
                

                if (turma.consultarIgual(txtProfessor.Text))
                {
                    MessageBox.Show("O professor já tem aula nesse dia e horário!");
                }
                else
                {
                    if (turma.cadastrarTurma())
                    {
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }
                    else
                        MessageBox.Show("Erro no cadastro!");
                        txtProfessor.Text = "";
                        cbxDiaSemana.Text = "";
                        txtHoras.Text = "";
                        txtModalidade.Text = "";
                        txtProfessor.Enabled = false;
                        cbxDiaSemana.Enabled = false;
                        txtHoras.Enabled = false;
                        txtModalidade.Enabled = false;
                        btnCadastrar.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Os campos não podem ser nulos!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblQtde_alunos_Click(object sender, EventArgs e)
        {

        }

        private void txtProfessor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cbxDiaSemana.Enabled = true;
        }

        private void cbxDiaSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoras.Enabled = true;
        }

        private void txtHoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnCadastrar.Enabled=true;
            
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModalidade.Enabled = true;
            txtProfessor.Enabled = true;
            txtModalidade.Text = dataGridView1.CurrentCell.Value.ToString();
        }
    }
}
