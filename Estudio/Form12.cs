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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void txtCPFAluno_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbxTurma.Items.Clear();
            Aluno aluno = new Aluno(txtCPFAluno.Text);
            if (e.KeyChar == 13)
            {

                if (aluno.consultarAluno())
                {
                    cbxTurma.Enabled = true;
                    Turma exc = new Turma();
                    MySqlDataReader r = exc.consultarTodasTurmas();
                    while (r.Read())
                    {
                        cbxTurma.Items.Add(r["nomeTurma"].ToString());
                    }
                    DAO_Conexao.con.Close();
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                }

                DAO_Conexao.con.Close();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            MySqlDataReader alDH;
            Turma t = new Turma();
            int n = t.selecionaIdTurma(cbxTurma.Text);
            AlunoTurma at = new AlunoTurma(txtCPFAluno.Text, n);
            if (at.consultarAlunoIgual(n))
            {
                MessageBox.Show("Não é possível cadastrar aluno em uma turma já vinculada a ele!");
            }
            else
            {
                alDH = at.consultarAlunoDiaHora(txtCPFAluno.Text);
                bool exAlDH = true;
                while (alDH.Read())
                {
                    if (cbxDiaSemana.Text == alDH["diasemanaTurma"])
                    {
                        if (cbxHora.Text == alDH["horaTurma"])
                        {
                            exAlDH = false;
                        }
                    }
                }
                DAO_Conexao.con.Close();
                if (exAlDH)
                {
                    if (t.contarAlunos(n) < t.selecionaMaximo(n))
                    {
                        if (at.cadastrarAlunoTurma())
                        {
                            MessageBox.Show("Agora o aluno está vinculado a uma turma!");
                        }
                        else
                        {
                            MessageBox.Show("Erro no cadastro!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("A turma já atingiu o limite de alunos!");
                    }
                }
                else
                {
                    MessageBox.Show("O aluno já tem aula nesse dia e horário.", "O sistema informa:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            txtCPFAluno.Text = "";
            cbxDiaSemana.Text = "";
            cbxHora.Text = "";
            cbxTurma.Text = "";
            cbxDiaSemana.Enabled = false;
            cbxHora.Enabled = false;
            cbxTurma.Enabled = false;
            btnCadastrar.Enabled = false;
            cbxTurma.Items.Clear();

        }

        private void cbxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDiaSemana.Items.Clear();
            cbxDiaSemana.Enabled = true;
            Turma exc = new Turma();
            MySqlDataReader r = exc.consultar(cbxTurma.Text);
            while (r.Read())
            {
                cbxDiaSemana.Items.Add(r["diasemanaTurma"].ToString());
            }
            if (cbxDiaSemana.Items.Count == 0)
            {
                cbxDiaSemana.Enabled = false;
            }

            DAO_Conexao.con.Close();
        }

        private void cbxDiaSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxHora.Items.Clear();
            cbxHora.Enabled = true;
            Turma exc = new Turma();
            MySqlDataReader r = exc.consultarTurma01(cbxDiaSemana.Text, cbxTurma.Text);
            while (r.Read())
            {
                cbxHora.Items.Add(r["horaTurma"].ToString());
            }

            DAO_Conexao.con.Close();

        }

        private void cbxHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCadastrar.Enabled = true;
        }
    }
}
