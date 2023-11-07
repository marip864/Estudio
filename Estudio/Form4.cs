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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(maskedTextBox1.Text);
            AlunoTurma aturma = new AlunoTurma();
            Turma t = new Turma();
            t.Id = t.selecionaIdTurmadoAluno(maskedTextBox1.Text);
            if (e.KeyChar == 13)
            {
                if (aluno.consultarAluno())
                {
                    if (aluno.excluirAluno(t.Id))
                    {
                        MessageBox.Show("Aluno excluído!");
                    }
                }
                else
                {
                    MessageBox.Show("Aluno não existe!");
                }
                maskedTextBox1.Text = "";
            }
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
