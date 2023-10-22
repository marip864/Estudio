using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Estudio
{
    class Modalidade
    {
        private string Descricao;
        private float Preco;
        private int qtde_alunos, qtde_aulas, idModalidade;

        public Modalidade(string descricao, float preco, int qtde_alunos, int qtde_aulas)
        {
            Descricao1 = descricao;
            Preco1 = preco;
            Qtde_alunos = qtde_alunos;
            Qtde_aulas = qtde_aulas;
        }

        public Modalidade(string descricao)
        {
            Descricao1 = descricao;
        }

        public Modalidade()
        {

        }

        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public float Preco1 { get => Preco; set => Preco = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }
        public int Qtde_aulas { get => qtde_aulas; set => qtde_aulas = value; }
        public int IdModalidade { get => idModalidade; }

        public bool cadastrarModalidade()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Modalidade (descricaoModalidade, precoModalidade, qtdeAlunos, qtdeAulas) values ('" + Descricao + "'," + Preco + "," + qtde_alunos + "," + qtde_aulas + ")", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }

        public bool existeModalidade(string usuario)
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand verifica = new MySqlCommand("select * from Estudio_Modalidade where descricaoModalidade='" + usuario + "'", DAO_Conexao.con);
                MySqlDataReader resultado = verifica.ExecuteReader();
                if (resultado.Read())
                    cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }
        public MySqlDataReader consultarModalidade()
        {
            MySqlDataReader result = null;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Modalidade where descricaoModalidade ='" + Descricao + "'", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
        public MySqlDataReader consultarTodasModalidade()
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Modalidade", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTodasModalidade01()
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Modalidade where ativa = 0", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public int verificaAtivo()
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select ativa from Estudio_Modalidade where descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["ativa"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return resultI;
        }

        public bool tornarAtivo()
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Modalidade set ativa = 0 where descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                
                atualiza.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public bool atualizarModalidade()
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Modalidade set precoModalidade=" + Preco + ", qtdeAulas = " + Qtde_aulas + ", qtdeAlunos =" + Qtde_alunos + " where descricaoModalidade ='" + Descricao + "'", DAO_Conexao.con);
                atualiza.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return result;
        }

        public int selecionaId(string s)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idEstudio_Modalidade from Estudio_Modalidade where descricaoModalidade = '" + s + "'", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["idEstudio_Modalidade"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return resultI;
        }

        public bool excluirModalidade(string desc, int i)
        {
            string exclusao = desc;
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Modalidade set ativa = 1 where descricaoModalidade = '" + exclusao + "'", DAO_Conexao.con);
                MySqlCommand excluit = new MySqlCommand("update Estudio_Turma set ativa = 1 where idModalidade = " + i + "", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                excluit.ExecuteNonQuery();
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return result;
        }

        public int selecionaMaximoModalidade(int id)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select qtdeAlunos from Estudio_Modalidade where idEstudio_Modalidade = " + id + "", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["qtdeAlunos"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return resultI;
        }
    }
}
