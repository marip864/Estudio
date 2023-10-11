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
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((cbxTurma.Text != "")&&(cbxDiaSemana.Text != "")&&(cbxHora.Text != ""))
            {
                Turma turma = new Turma();
                turma.excluirTurma(cbxTurma.Text);
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Selecione uma opção para excluir!");
            }
        }
    }
}
