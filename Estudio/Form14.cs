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
    public partial class Form14 : Form
    {
        public Form14()
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

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbxTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDiaSemana.Items.Clear();
            cbxDiaSemana.Text = "";
            cbxHora.Items.Clear();
            cbxHora.Text = "";
            txtQtdeAlunos.Text = "";
            dataGridView1.Rows.Clear();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQtdeAlunos.Text = "";
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
            int i = 0;
            AlunoTurma exc = new AlunoTurma();
            Turma t = new Turma();
            MySqlDataReader r = exc.consultarAlunosdaTurma(t.selecionaIdTurma(cbxTurma.Text));
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["nomeAluno"].ToString());
                i++;
            }
            
            DAO_Conexao.con.Close();

            
            txtQtdeAlunos.Text = i.ToString();
        }
    }
}
