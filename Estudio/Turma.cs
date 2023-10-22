using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class Turma
    {
        private string professor, dia_semana, hora, nome;

        public Turma(string nome)
        {
            Nome = nome;
        }

        private int modalidade, qtde_alunos, id;

        public Turma(int id, string professor, string dia_semana, string hora, int modalidade, int qtde_alunos)
        {
            Id = id;
            Professor = professor;
            Dia_semana = dia_semana;
            Hora = hora;
            Modalidade = modalidade;
            Qtde_alunos = qtde_alunos;
        }

        public Turma(string professor, string dia_semana, string hora, int modalidade, int qtde_alunos, string nome)
        {
            Professor = professor;
            Dia_semana = dia_semana;
            Hora = hora;
            Modalidade = modalidade;
            Qtde_alunos = qtde_alunos;
            Nome = nome;
        }

        public Turma(int alunos, string professor, string dia_semana, string hora, int id, string nome)
        {
            Qtde_alunos = alunos;
            Professor = professor;
            Dia_semana = dia_semana;
            Hora = hora;
            Id = id;
            Nome = nome;
        }

        public Turma(int id)
        {
            Id = id;
        }

        public Turma(string dia_semana, int modalidade)
        {
            Dia_semana = dia_semana;
            Modalidade = modalidade;
        }

        public Turma()
        {

        }

        public bool cadastrarTurma()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma (idModalidade, professorTurma, diasemanaTurma, horaTurma, nalunosmatriculadosTurma, nomeTurma) values (" + Modalidade + ",'" + Professor + "','" + Dia_semana + "','" + Hora + "'," + Qtde_alunos + ",'" + Nome + "')", DAO_Conexao.con);
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

        public bool excluirTurma(string n, string d, string h)
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Turma set ativa = 1 where nomeTurma='"+n+"' and diasemanaTurma = '" + d + "' and horaTurma ='" + h + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
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

        public string verificaTurma(string p, string d, string h)
        {
            MySqlDataReader result = null;
            string resultS = "";

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select professorTurma,diasemanaTurma,horaTurma from Estudio_Turma where professorTurma ='" + p + "' and diasemanaTurma ='" + d + "' and horaTurma ='" + h + "'", DAO_Conexao.con);
                result = consulta.ExecuteReader();
                resultS = result.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }

            return resultS;
        }

        public MySqlDataReader consultar()
        {
            MySqlDataReader result = null;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Turma where ativa=0", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTurma(int i)
        {
            MySqlDataReader result = null;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select diasemanaTurma from Estudio_Turma where idEstudio_Turma =" + i + "", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public int selecionaIdTurma(string p)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idEstudio_Turma from Estudio_Turma where nomeTurma = '" + p + "'", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["idEstudio_Turma"].ToString());
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

        public int selecionaIdModalidadeTurma(string p)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idEstudio_Turma from Estudio_Turma where nomeTurma = '" + p + "'", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["idEstudio_Turma"].ToString());
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

        public MySqlDataReader consultarTurma01(string s, string s2)
        {
            MySqlDataReader result = null;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select horaTurma from Estudio_Turma where diasemanaTurma = '" + s + "' and nomeTurma ='" + s2 + "' and ativa = 0", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTodasTurmas()
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select distinct (nomeTurma) from Estudio_Turma", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTodasTurmasParaModalidade(int id)
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select distinct (nomeTurma) from Estudio_Turma where idModalidade = "+id+"", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTodasTurmasAtivas()
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select distinct (nomeTurma) from Estudio_Turma where ativa = 0", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTodasTurmas02()
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Turma", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarTodasTurmas03()
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Turma where ativa=0", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public bool consultarIgual(string p)
        {
            MySqlDataReader result = null;
            bool a = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select diasemanaTurma, horaTurma from Estudio_Turma where professorTurma='" + p + "'", DAO_Conexao.con);
                result = consulta.ExecuteReader();
                while (result.Read())
                {
                    if (dia_semana == result["diasemanaTurma"].ToString())
                    {
                        if (hora == result["horaTurma"].ToString())
                        {
                            a = true;
                        }
                    }

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
            return a;
        }



        public string selecionaModalidade(int i)
        {
            MySqlDataReader result = null;
            string resultS = "";
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select descricaoModalidade from Estudio_Modalidade where idEstudio_Modalidade =" + i + "", DAO_Conexao.con);
                result = consulta.ExecuteReader();
                if (result.Read())
                {
                    resultS = result["descricaoModalidade"].ToString();
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

            return resultS;
        }

        public int consultarTodasTurmas01(string s)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select idModalidade from Estudio_Turma where nomeTurma ='" + s + "'", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["idModalidade"].ToString());
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

        public MySqlDataReader consultar(string s)
        {
            MySqlDataReader resultS = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select diasemanaTurma from Estudio_Turma where nomeTurma ='" + s + "' and ativa = 0", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultS;
        }

        public bool atualizarTurma()
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Turma set nalunosmatriculadosTurma = " + Qtde_alunos + ", horaTurma ='" + Hora + "', professorTurma ='" + Professor + "', diasemanaTurma ='" + Dia_semana + "', nomeTurma = '" + Nome + "' where idEstudio_Turma =" + Id + "", DAO_Conexao.con);
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

        public bool atualizarNomeTurma()
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Turma set nomeTurma = '" + Nome + "' where idModalidade =" + Modalidade + "", DAO_Conexao.con);
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

        public int verificaAtivo()
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select ativa from Estudio_Turma where idEstudio_Turma = " + Id + "", DAO_Conexao.con);
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

        public int contarAlunos(int n)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select count(aluno_cpf) from Estudio_AlunoTurma where turma_id = " + n + "", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["count(aluno_cpf)"].ToString());
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

        public int contarTurmas()
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select count(idEstudio_Turma) from Estudio_Turma", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["count(idEstudio_Turma)"].ToString());
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

        public int selecionaMaximo(int id)
        {
            MySqlDataReader resultS = null;
            int resultI = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select nalunosmatriculadosTurma from Estudio_Turma where idEstudio_Turma = " + id + "", DAO_Conexao.con);
                resultS = consulta.ExecuteReader();
                if (resultS.Read())
                {
                    resultI = int.Parse(resultS["nalunosmatriculadosTurma"].ToString());
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

        public int contaAlunos(int novosAlunos)
        {
            MySqlDataReader resultS = null;
            MySqlCommand consulta = new MySqlCommand();
            return 0;
        }

        public bool tornarAtivo()
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Turma set ativa = 0 where idEstudio_Turma = " + Id + "", DAO_Conexao.con);
                atualiza.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }


        public string Professor { get => professor; set => professor = value; }
        public string Dia_semana { get => dia_semana; set => dia_semana = value; }
        public string Hora { get => hora; set => hora = value; }
        public int Modalidade { get => Modalidade1; set => Modalidade1 = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }
        public int Modalidade1 { get => modalidade; set => modalidade = value; }
        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
    }
}
