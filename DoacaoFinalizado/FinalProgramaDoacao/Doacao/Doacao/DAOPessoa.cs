using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Doacao
{
    class DAOPessoa




    {
        public MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;
        public int contarCodigo;
        public int contador;
        public string msg;
        //vetor
        public int[] vetorCodigoCliente;
        public string[] vetorEmail;
        public string[] vetorNome;
        public string[] vetorTelefone;
        public string[] vetorEndereco;
        public string[] vetorBrinquedos;
        public string[] vetorRoupas;
        public string[] vetorDinheiro;
        public string[] vetorAlimento;
        public int i;



        public DAOPessoa()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=DoacaoBD;Uid=root;password=;");
            try
            {
                conexao.Open();//Tentando conectar ao BD
            }catch(Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);//Mandando mensagem de erro para o usuario
                conexao.Close();//Fechando a conexao com o bd
            }
        }//Fim DAOPessoa














        //========================================================== Metodos ====================================================================





        //Inserir Cliente

        public void Inserir(string nome, string email, string telefone, string endereco, string brinquedos, string roupas, string dinheiro, string alimento)
        {
            try
            {
                //Preparar os dados para inserir no banco
                dados = "('','" + email + "','" + nome + "','" + telefone + "','" + endereco + "','" + brinquedos + "','" + roupas + "','" + dinheiro + "','" + alimento + "')";
                comando = "Insert into Cliente(codigoCliente, email, nome, telefone, endereco, brinquedos, roupas, dinheiro, alimento) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    MessageBox.Show("Enviado com sucesso!\n\n" +
                        "Entraremos em contato em breve!\n\n");
                }
                else
                {
                    MessageBox.Show("Não Cadastrado!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
        }//fim do método inserir






        //Inserir Admin

        public void Inserir2(string email, string nome, string telefone, string endereco)
        {
            try
            {
                //Preparar os dados para inserir no banco
                dados = "('','" + email + "','" + nome + "','" + telefone + "','" + endereco + "')";
                comando = "Insert into Cliente(codigoCliente, email, nome, telefone, endereco) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não Cadastrado!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro);
            }
        }//fim do método inserir






        public void PreencherVetor()
        {
            string query = "select * from Cliente";


            vetorCodigoCliente = new int[100];
            vetorEmail = new string[100];
            vetorNome = new string[100];
            vetorTelefone = new string[100];
            vetorEndereco = new string[100];
            vetorBrinquedos = new string[100];
            vetorRoupas = new string[100];
            vetorDinheiro = new string[100];
            vetorAlimento = new string[100];


            for(i=0; i < 100; i++)
            {
                vetorCodigoCliente[i] = 0;
                vetorEmail[i] = "";
                vetorNome[i] = "";
                vetorTelefone[i] = "";
                vetorEndereco[i] = "";
                vetorBrinquedos[i] = "";
                vetorRoupas[i] = "";
                vetorDinheiro[i] = "";
                vetorAlimento[i] = "";
            }//Fim for


            MySqlCommand coletar = new MySqlCommand(query, conexao);

            MySqlDataReader leitura = coletar.ExecuteReader();


            i = 0;
            contador = 0;
            contarCodigo = 0;

            while(leitura.Read())

            {
                vetorCodigoCliente[i] = Convert.ToInt32(leitura["codigoCliente"]);
                vetorEmail[i] = leitura["email"] + "";
                vetorNome[i] = leitura["nome"] + "";
                vetorTelefone[i] = leitura["telefone"] + "";
                vetorEndereco[i] = leitura["endereco"] + "";
                contarCodigo = contador;
                i++;
                contador++;
            }//fim do while

            leitura.Close();
        }//fim do preencherVetor





        //=======================================================================

        public string ConsultarTudo()
        {
            PreencherVetor();//Primeira Coisa -> Preencher os vetor com dados do BD
            msg = "";
            for (i = 0; i < contador; i++)
            {
                //Armazenar temporariamente os dados do BD na variável MSG
                msg += "Código: " + vetorCodigoCliente[i] +
                       ", email: " + vetorEmail[i] +
                       ", nome: " + vetorNome[i] +
                       ", telefone: " + vetorTelefone[i] +
                       ", endereço: " + vetorEndereco[i] +
                       "\n\n";
            }//fim do for
            return msg;//Retorna todos os dados armazenados na variável msg
        }//fim do consultarTudo



        //=========================== C o n s u l t a r ======================

        public int ConsultarCodigoCliente()
        {
            PreencherVetor();//Preencher os vetores com os dados do BD
            return vetorCodigoCliente[contarCodigo];
        }//fim do consultarCodigo




        public string ConsultarEmail(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (vetorCodigoCliente[i] == cod)
                {
                    return vetorEmail[i];
                }//fim do if
            }//fim do for
            return "Email não encontrado!";
        }//fim do consultarEmail


        public string ConsultarNome(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (vetorCodigoCliente[i] == cod)
                {
                    return vetorNome[i];
                }
            }//fim do for
            return "Nome não encontrado!";
        }//fim do consultarNome


        public string ConsultarTelefone(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (vetorCodigoCliente[i] == cod)
                {
                    return vetorTelefone[i];
                }
            }
            return "Telefone não encontrado!";
        }//fim do consultarTelefone


        public string ConsultarEndereco(int cod)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (vetorCodigoCliente[i] == cod)
                {
                    return vetorEndereco[i];
                }
            }
            return "Endereço não encontrado!";
        }//fim do consultarEndereco



        //==============================================================================






        //=========================================== Botao Atualizar =================================================





        public string AtualizarBrinquedos(int cod)
        {
            try
            {
                string query = "update Cliente set brinquedos = sim" + "' where codigoCliente = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Obrigado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Erro";
        
           
        }//fim do metodo AtualizarBrinquedos






        public string AtualizarAlimentos(int cod)
        {
            try
            {
                string query = "update Cliente set alimento = sim" + "' where codigoCliente = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Obrigado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Erro";


        }//fim do metodo AtualizarAlimentos







        public string AtualizarRoupas(int cod)
        {
            try
            {
                string query = "update Cliente set roupas = sim" + "' where codigoCliente = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Obrigado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Erro";


        }//fim do metodo AtualizarRoupas






        public string AtualizarDinheiro(int cod)
        {
            try
            {
                string query = "update Cliente set dinheiro = sim" + "' where codigoCliente = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Obrigado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Erro";


        }//fim do metodo AtualizarDinheiro







        //=============================================================================================================











        //========================== A t t  A d m ==================================


        public string Atualizar(int cod, string campo, string novoDado)
        {
            try
            {
                string query = "update Cliente set " + campo + " = '" + novoDado + "' where codigoCliente = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Atualizado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Não Atualizado!";
        }//fim do atualizar


        public string Atualizar(int cod, string campo, long novoDado)
        {
            try
            {
                string query = "update Cliente set " + campo + " = '" + novoDado + "' where codigoCliente = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    return "Atualizado!";
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
            return "Não Atualizado!";
        }//fim do atualizar


        public void Deletar(int cod)
        {
            try
            {
                string query = "delete from Cliente where codigoCliente = '" + cod + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();

                if (resultado == "1")
                {
                    MessageBox.Show("Deletado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não Deletado!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }//fim do deletar

    }//Fim da classe
}//Fim do projeto
