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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AlunoTurma con_t = new AlunoTurma();

                MySqlDataReader r = con_t.consultar(maskedTextBox1.Text);

                while (r.Read())
                {
                    dataGridView1.Rows.Add(r["turma_id"].ToString());
                }



                DAO_Conexao.con.Close();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnExcluir.Enabled = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                AlunoTurma turma = new AlunoTurma();
                turma.excluirAlunoTurma(maskedTextBox1.Text, int.Parse(dataGridView1.CurrentCell.Value.ToString()));
                MessageBox.Show("Excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para excluir!");
            }
        }
    }
}
