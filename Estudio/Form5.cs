using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class Form5 : Form
    {
        int opcao = 0;
        public Form5(int op)
        {
            InitializeComponent();
            if (op == 1)
            {
                button1.Visible = false;
                button2.Visible = false;
                opcao = 1;
            }
            if (op == 2)
            {
                opcao = 2;
            }
        }

        private byte[] ConverterFotoParaByteArray()
        {
            using (var stream = new System.IO.MemoryStream())
            {
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //deslocamento de bytes em relação ao parâmetro original
                //redefine a posição do fluxo para a gravação
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] bArray = new byte[stream.Length];
                //Lê um bloco de bytes e grava os dados em um buffer (stream)
                stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                return bArray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] foto = ConverterFotoParaByteArray();

            Aluno aluno = new Aluno(txtCPF.Text, txtNome.Text, txtEnd.Text, txtNumero.Text, txtBairro.Text, txtCompl.Text, txtCEP.Text, txtCidade.Text, txtEstado.Text, txtTel.Text, txtEmail.Text, foto);

            if (aluno.atualizarAluno())
            {
                MessageBox.Show("Atualização realizada com sucesso!");
            }

            txtNome.Text = "";
            txtEnd.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCompl.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtCPF.Text = "";
            txtCPF.Enabled = true;
            pictureBox1.Image = null;
            txtNome.Enabled = false;
            txtEnd.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCompl.Enabled = false;
            txtCEP.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;
            txtTel.Enabled = false;
            txtEmail.Enabled = false;
            button1.Enabled = false;
            btnAtualizarFoto.Enabled = false;
            button2.Enabled = false;
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(txtCPF.Text);
            if (e.KeyChar == 13)
            {
                MySqlDataReader dr = aluno.consultarAluno01();
                if (dr.Read())
                {
                    txtNome.Text = dr["nomeAluno"].ToString();
                    txtEnd.Text = dr["ruaAluno"].ToString();
                    txtNumero.Text = dr["numeroAluno"].ToString();
                    txtBairro.Text = dr["bairroAluno"].ToString();
                    txtCompl.Text = dr["complementoAluno"].ToString();
                    txtCEP.Text = dr["CEPAluno"].ToString();
                    txtCidade.Text = dr["cidadeAluno"].ToString();
                    txtEstado.Text = dr["estadoAluno"].ToString();
                    txtTel.Text = dr["telefoneAluno"].ToString();
                    txtEmail.Text = dr["emailAluno"].ToString();
                    try
                    {
                        string imagem = Convert.ToString(DateTime.Now.ToFileTime());
                        byte[] bimage = (byte[])dr["fotoAluno"];
                        FileStream fs = new FileStream(imagem, FileMode.CreateNew, FileAccess.Write);
                        fs.Write(bimage, 0, bimage.Length - 1);
                        fs.Close();
                        pictureBox1.Image = Image.FromFile(imagem);
                        dr.Close();
                    }
                    catch
                    {
                        
                        MessageBox.Show("Erro ao carregar a foto!","Atenção: ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    if (opcao == 2)
                    {
                        txtNome.Enabled = true;
                        txtEnd.Enabled = true;
                        txtNumero.Enabled = true;
                        txtBairro.Enabled = true;
                        txtCompl.Enabled = true;
                        txtCEP.Enabled = true;
                        txtCidade.Enabled = true;
                        txtEstado.Enabled = true;
                        txtTel.Enabled = true;
                        txtEmail.Enabled = true;
                        button1.Enabled = true;
                        btnAtualizarFoto.Enabled = true;
                        txtCPF.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                }
                DAO_Conexao.con.Close();
                int n = aluno.verificaAtivo();
                if (n == 1)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string CPF = txtCPF.Text;
                Aluno a = new Aluno(CPF);
                if (a.tornarAtivo())
                {
                    MessageBox.Show("Aluno ativado com sucesso!");
                    button2.Enabled=false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecione uma opção para atualizar!");
            }
            DAO_Conexao.con.Close();

        }

        private void btnAtualizarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Abrir Foto";
            dialog.Filter = "JPG (*.jpg)|*.jpg" + "|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(dialog.OpenFile());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel carregar a foto: " + ex.Message);
                }//catch
            }//if
            dialog.Dispose();
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
