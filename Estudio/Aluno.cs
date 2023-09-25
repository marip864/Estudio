using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Aluno
    {

        private string CPF;
        private string Nome;
        private string Rua;
        private string Numero;
        private string Bairro;
        private string Complemento;
        private string CEP;
        private string Cidade;
        private string Estado;
        private string Telefone;
        private string Email;
        private byte[] Foto;
        private bool ativo;

        public Aluno(string CPF, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email, bool ativo, byte[]foto)
        {
            setCPF(CPF);
            setNome(nome);
            setRua(rua);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCep(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
            setFoto(foto);
            setAtivo(ativo);
        }

        public Aluno(string CPF, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email)
        {
            setCPF(CPF);
            setNome(nome);
            setRua(rua);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCep(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
        }

        public Aluno()
        {

        }

        public Aluno(string cpf)
        {
            setCPF(cpf);
        }

        public bool cadastrarAluno()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Aluno (CPFAluno, nomeAluno, ruaAluno, numeroAluno, bairroAluno, complementoAluno, CEPAluno, cidadeAluno, estadoAluno, telefoneAluno, emailAluno) values ('" + CPF + "','" + Nome + "','" + Rua + "','" + Numero + "','" + Bairro + "','" + Complemento + "','" + CEP + "','" +Cidade+"','" + Estado + "','" + Telefone + "','" + Email + "')",DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }

        public bool atualizarAluno()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Aluno set nomeAluno='"+Nome+"', ruaAluno='"+Rua+"', numeroAluno='"+Numero+"', bairroAluno='"+Bairro+"', complementoAluno='"+Complemento+"', CEPAluno='"+CEP+"', cidadeAluno='"+Cidade+"', estadoAluno='"+Estado+"', telefoneAluno='"+Telefone+"', emailAluno='"+Email+"' where CPFAluno ='"+CPF+"'",DAO_Conexao.con);
                atualiza.ExecuteNonQuery();
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

        public bool consultarAluno()
        {
            bool existe = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Aluno where CPFAluno ='" + CPF + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if(resultado.Read())
                {
                    existe = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return existe;
        }

        public MySqlDataReader consultarAluno01()
        {
           MySqlDataReader resultado = null;
           try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Aluno where CPFAluno ='" + CPF + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool excluirAluno()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Aluno set ativo = 1 where CPFAluno = '"+CPF+"'", DAO_Conexao.con);
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
        private void setAtivo(bool ativo)
        {
            this.ativo = ativo;
        }

        private bool getAtivo()
        {
            return this.ativo;
        }

        private void setFoto(byte[] foto)
        {
            this.Foto = foto;
        }

        private byte[] getFoto()
        {
            return this.Foto;
        }

        private void setEmail(string email)
        {
            this.Email = email;
        }

        private string getEmail()
        {
            return this.Email;
        }

        private void setTelefone(string telefone)
        {
            this.Telefone = telefone;
        }

        private string getTelefone()
        {
            return this.Telefone;
        }

        private void setEstado(string estado)
        {
            this.Estado = estado;
        }

        private string getEstado()
        {
            return this.Estado;
        }

        private void setCidade(string cidade)
        {
            this.Cidade = cidade;
        }

        private string getCidade()
        {
            return this.Cidade;
        }

        private void setCep(string cep)
        {
            this.CEP = cep;
        }

        private string getCep()
        {
            return this.CEP;
        }

        private void setComplemento(string complemento)
        {
            this.Complemento = complemento;
        }

        private string getComplemento()
        {
            return this.Complemento;
        }

        private void setBairro(string bairro)
        {
            this.Bairro = bairro;
        }

        private string getbairro()
        {
            return this.Bairro;
        }

        private void setNumero(string numero)
        {
            this.Numero = numero;
        }

        private string getNumero()
        {
            return this.Numero;
        }

        private void setRua(string rua)
        {
            this.Rua = rua;
        }

        private string getRua()
        {
            return this.Rua;
        }

        private void setNome(string nome)
        {
            this.Nome = nome;
        }

        private string getNome()
        {
            return this.Nome;
        }

        private void setCPF(string cpf)
        {
            this.CPF = cpf;
        }

        private string getCPF()
        {
            return this.CPF;
        }
    }
    
}
