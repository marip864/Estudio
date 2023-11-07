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
            dataGridView1.Rows.Clear();
            if (e.KeyChar == 13)
            {
                AlunoTurma con_t = new AlunoTurma();

                MySqlDataReader r = con_t.consultar(maskedTextBox1.Text);

                //MySqlDataReader r2 = con_t.visualizar();

                while (r.Read())
                {
                    
                    //if (r2["idEstudio_Turma"] == r["turma_id"])

                        dataGridView1.Rows.Add(r["nomeTurma"].ToString());
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
                AlunoTurma aturma = new AlunoTurma();
                Turma t = new Turma();
                aturma.Turma_id = t.selecionaIdTurma(dataGridView1.CurrentCell.Value.ToString());
                aturma.excluirAlunoTurma(maskedTextBox1.Text);
                MessageBox.Show("Excluído com sucesso!");
                maskedTextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para excluir!");
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
