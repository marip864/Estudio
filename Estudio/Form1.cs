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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            menuStrip1.Enabled = false;

            if (DAO_Conexao.getConexao("143.106.241.3", "cl202239", "cl202239", "@marip.864_frozen0905"))
                Console.WriteLine("Conectado");
            else
                Console.WriteLine("Erro de conexão");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form2>().Count() == 0) && (Application.OpenForms.OfType<Form3>().Count() == 0) && (Application.OpenForms.OfType<Form4>().Count() == 0) && (Application.OpenForms.OfType<Form5>().Count() == 0))
            {
                Form2 filho = new Form2();
                filho.MdiParent = this;
                filho.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = DAO_Conexao.verLogin(textBox1.Text, textBox2.Text);
            if (tipo == 0)
                MessageBox.Show("Usuário/Senha inválidos");
            if(tipo==1)
            {
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
            }
            if (tipo == 2)
            {
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                cadastrarLoginToolStripMenuItem.Enabled = false;
            }

        }

        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form2>().Count() == 0) && (Application.OpenForms.OfType<Form3>().Count() == 0) && (Application.OpenForms.OfType<Form4>().Count() == 0) && (Application.OpenForms.OfType<Form5>().Count() == 0))
            {
                Form3 filho = new Form3();
                filho.MdiParent = this;
                filho.Show();
            }
        }
     

        private void sairToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Close();
        }

        private void excluirAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form2>().Count() == 0) && (Application.OpenForms.OfType<Form3>().Count() == 0) && (Application.OpenForms.OfType<Form4>().Count() == 0) && (Application.OpenForms.OfType<Form5>().Count() == 0))
            {
                Form4 filho = new Form4();
                filho.MdiParent = this;
                filho.Show();
            }
        }

        private void atualizarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form2>().Count() == 0) && (Application.OpenForms.OfType<Form3>().Count() == 0) && (Application.OpenForms.OfType<Form4>().Count() == 0) && (Application.OpenForms.OfType<Form5>().Count() == 0))
            {
                Form5 filho = new Form5();
                filho.MdiParent = this;
                filho.Show();
            }
        }

        private void cadastrarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((Application.OpenForms.OfType<Form6>().Count()==0)&&(Application.OpenForms.OfType<Form7>().Count() == 0)&& (Application.OpenForms.OfType<Form8>().Count() == 0))
            {
                Form6 filho = new Form6();
                filho.MdiParent = this;
                filho.Show();
            }
            
        }

        private void consultarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form6>().Count() == 0) && (Application.OpenForms.OfType<Form7>().Count() == 0) && (Application.OpenForms.OfType<Form8>().Count() == 0))
            {
                Form8 filho = new Form8(1);
                filho.MdiParent = this;
                filho.Show();
            }
        }

        private void atualizarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form6>().Count() == 0) && (Application.OpenForms.OfType<Form7>().Count() == 0) && (Application.OpenForms.OfType<Form8>().Count() == 0))
            {
                Form8 filho = new Form8(2);
                filho.MdiParent = this;
                filho.Show();
            }
            
        }

        private void excluirModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms.OfType<Form6>().Count() == 0) && (Application.OpenForms.OfType<Form7>().Count() == 0) && (Application.OpenForms.OfType<Form8>().Count() == 0))
            {
                Form7 filho = new Form7();
                filho.MdiParent = this;
                filho.Show();
            }
        }
    }
}
