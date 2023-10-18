using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class AlunoTurma
    {
        private string aluno_cpf;
        private int turma_id;

        public AlunoTurma()
        {
        }

        public AlunoTurma(string aluno_cpf, int turma_id)
        {
            Aluno_cpf = aluno_cpf;
            Turma_id = turma_id;
        }

        public string Aluno_cpf { get => aluno_cpf; set => aluno_cpf = value; }
        public int Turma_id { get => turma_id; set => turma_id = value; }

        public bool cadastrarAlunoTurma()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_AlunoTurma (aluno_cpf, turma_id) values ('" + Aluno_cpf + "'," + Turma_id + ")", DAO_Conexao.con);
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


        public MySqlDataReader consultar(string cpf)
        {
            MySqlDataReader result = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_AlunoTurma where aluno_cpf ='" + cpf + "'", DAO_Conexao.con);
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

        public bool excluirAlunoTurma(string cpf, int id)
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("delete from Estudio_AlunoTurma where aluno_cpf = '" + cpf + "' and turma_id = " + id + "", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
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

