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
            MySqlDataReader r = exc.consultarTodasModalidade();
            while(r.Read())
            {
                cbxDescricao.Items.Add(r["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Modalidade modalidade = new Modalidade();
            modalidade.excluirModalidade(cbxDescricao.Text);
            
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
