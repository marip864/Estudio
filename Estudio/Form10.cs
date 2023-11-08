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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            Turma exc = new Turma();
            MySqlDataReader r = exc.consultarTodasTurmasAtivas();
            while (r.Read())
            {
                cbxTurma.Items.Add(r["nomeTurma"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((cbxTurma.Text != "") && (cbxDiaSemana.Text != "") && (cbxHora.Text != ""))
            {
                Turma turma = new Turma();
                if (turma.excluirTurma(cbxTurma.Text, cbxDiaSemana.Text, cbxHora.Text,turma.selecionaIdTurma(cbxTurma.Text)))
                    MessageBox.Show("Excluído com sucesso!");
                else
                    MessageBox.Show("Erro na exclusão!");
                cbxTurma.Text = "";
                cbxDiaSemana.Text = "";
                cbxHora.Text = "";
                cbxDiaSemana.Enabled = false;
                cbxHora.Enabled = false;
            }
            else
            {
                MessageBox.Show("Selecione uma opção para excluir!");
            }
        }

        private void cbxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDiaSemana.Items.Clear();
            cbxDiaSemana.Enabled = true;
            cbxDiaSemana.Text = "";
            cbxHora.Text = "";
            Turma exc = new Turma();
            MySqlDataReader r = exc.consultar(cbxTurma.Text);
            while (r.Read())
            {
                cbxDiaSemana.Items.Add(r["diasemanaTurma"].ToString());
            }
            if (cbxDiaSemana.Items.Count == 0)
            {
                cbxDiaSemana.Enabled = false;
                cbxHora.Enabled = false;
            }

            DAO_Conexao.con.Close();
        }

        private void cbxHora_Click(object sender, EventArgs e)
        {

        }

        private void cbxHora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxDiaSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxHora.Items.Clear();
            cbxHora.Enabled = true;
            cbxHora.Text = "";
            Turma exc = new Turma();
            MySqlDataReader r = exc.consultarTurma01(cbxDiaSemana.Text, cbxTurma.Text);
            while (r.Read())
            {
                cbxHora.Items.Add(r["horaTurma"].ToString());
            }
            DAO_Conexao.con.Close();
        }
    }
}
