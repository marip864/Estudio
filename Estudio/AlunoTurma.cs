using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    class AlunoTurma
    {
        private string aluno_cpf;
        private int turma_id;
        private int idModalidade;

        public AlunoTurma()
        {
        }

        public AlunoTurma(string aluno_cpf, int turma_id,  int idModalidade)
        {
            Aluno_cpf = aluno_cpf;
            Turma_id = turma_id;
            IdModalidade = idModalidade;
        }

        public string Aluno_cpf { get => aluno_cpf; set => aluno_cpf = value; }
        public int Turma_id { get => turma_id; set => turma_id = value; }
        public int IdModalidade { get => idModalidade; set => idModalidade = value; }

        public bool cadastrarAlunoTurma()
        {
            bool cad = false;
            try
            {
                Turma t1 = new Turma();
                int alunos = t1.contarAlunosnaTurma(Turma_id);
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_AlunoTurma (aluno_cpf, turma_id, idModalidade) values ('" + Aluno_cpf + "'," + Turma_id + "," + IdModalidade + ")", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                DAO_Conexao.con.Close();
                DAO_Conexao.con.Open();
                alunos++;
                MySqlCommand insere1 = new MySqlCommand("update Estudio_Turma set nalunosmatriculadosTurma = "+alunos+" where idEstudio_Turma = "+Turma_id+"", DAO_Conexao.con);
                insere1.ExecuteNonQuery();
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


        public MySqlDataReader consultar(string cpf)
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select Estudio_Turma.nomeTurma from Estudio_AlunoTurma inner join Estudio_Turma on aluno_cpf ='" + cpf + "' AND Estudio_AlunoTurma.turma_id = Estudio_Turma.idEstudio_Turma", DAO_Conexao.con);
                result = consulta.ExecuteReader();
             }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarqtdeAlunos(int id)
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select nalunosmatriculadosTurma from Estudio_Turma where idEstudio_Turma = "+id+"", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader consultarAlunosdaTurma(int id)
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select Estudio_Aluno.nomeAluno from Estudio_Aluno inner join Estudio_AlunoTurma where Estudio_AlunoTurma.aluno_cpf = Estudio_Aluno.CPFAluno and turma_id =" + id + "", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public MySqlDataReader visualizar()
        {
            MySqlDataReader result = null;
            try
            {
                MySqlCommand consulta = new MySqlCommand("select Estudio_Turma.nomeTurma, Estudio_AlunoTurma.turma_id, Estudio_Turma.idEstudio_Turma from Estudio_Turma inner join Estudio_AlunoTurma where Estudio_Turma.idEstudio_Turma = Estudio_AlunoTurma.turma_id", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public bool consultarAlunoIgual(int i)
        {
            MySqlDataReader result = null;
            bool a = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select aluno_cpf from Estudio_AlunoTurma where turma_id=" + i + "", DAO_Conexao.con);
                result = consulta.ExecuteReader();
                while (result.Read())
                {
                    if (aluno_cpf == result["aluno_cpf"].ToString())
                    {
                        a = true;
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
        public int selecionaMaximo(int id)
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



        public MySqlDataReader consultarAlunoDiaHora(string s)
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select diasemanaTurma, horaTurma from Estudio_Turma inner join Estudio_AlunoTurma inner join Estudio_Aluno on Estudio_AlunoTurma.aluno_cpf = '" + s + "' AND Estudio_Aluno.CPFAluno = Estudio_AlunoTurma.aluno_cpf AND Estudio_Turma.idEstudio_Turma = Estudio_AlunoTurma.turma_id;", DAO_Conexao.con);
                result = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public bool excluirAlunoTurma(string cpf)
        {
            bool exc = false;
            try
            {
                Turma t1 = new Turma();
                int alunos = t1.contarAlunosnaTurma(Turma_id);
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("delete from Estudio_AlunoTurma where aluno_cpf = '" + cpf + "' and turma_id = " + Turma_id + "", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                DAO_Conexao.con.Close();
                DAO_Conexao.con.Open();
                alunos = alunos - 1;
                MySqlCommand exclui2 = new MySqlCommand("update Estudio_Turma set nalunosmatriculadosTurma = " + alunos + " where idEstudio_Turma = " + Turma_id + "", DAO_Conexao.con);
                exclui2.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc;
        }
    }
}

