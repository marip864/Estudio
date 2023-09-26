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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Modalidade exc = new Modalidade();
            MySqlDataReader r = exc.consultarTodasModalidade01();
            while(r.Read())
            {
                cbxDescricao.Items.Add(r["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(cbxDescricao.Text!="")
            {
                Modalidade modalidade = new Modalidade();
                modalidade.excluirModalidade(cbxDescricao.Text);
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Selecione uma opção para excluir!");
            }
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
