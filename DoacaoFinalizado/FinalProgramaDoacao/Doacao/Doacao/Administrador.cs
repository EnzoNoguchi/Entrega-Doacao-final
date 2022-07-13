using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doacao
{
    public partial class Administrador : Form
    {

        DAOPessoa pessoa;
        Opcao formAdm;

        public Administrador()
        {
            InitializeComponent();
            pessoa = new DAOPessoa();//abrindo conexao com o banco de dados
            formAdm = new Opcao();
            textBox1.Text = Convert.ToString(pessoa.ConsultarCodigoCliente() + 1);
            textBox1.ReadOnly = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        //======================================================================== Campos Metodos ============================================================


        public void Limpar()
        {
            textBox1.Text = "" + pessoa.ConsultarCodigoCliente();//CódigoCliente
            textBox2.Text = "";//Email
            textBox3.Text = "";//Nome
            maskedTextBox1.Text = "";//Telefone
            textBox5.Text = "";//Endereço
        }//fim do método limpar


        public void AtivarCampos()
        {
            textBox1.ReadOnly = false;//CódigoCliente
            textBox2.ReadOnly = true;//Email
            textBox3.ReadOnly = true;//Nome
            maskedTextBox1.ReadOnly = true;//Telefone
            textBox5.ReadOnly = true;//Endereço
        }//fim do ativar


        public void InativarCampos()
        {
            textBox1.ReadOnly = true;//CódigoCliente
            textBox2.ReadOnly = false;//Email
            textBox3.ReadOnly = false;//Nome
            maskedTextBox1.ReadOnly = false;//Telefone
            textBox5.ReadOnly = false;//Endereço
        }//fim do Inativar


        public void AtivarTodosOsCampos()
        {
            textBox1.ReadOnly = false;//CódigoCliente
            textBox2.ReadOnly = false;//Email
            textBox3.ReadOnly = false;//Nome
            maskedTextBox1.ReadOnly = false;//Telefone
            textBox5.ReadOnly = false;//Endereço
        }

        //======================================================= Fim campos metodos   ====================================================================================


        private void label2_Click(object sender, EventArgs e)
        {

        }//label de codigo

        private void label3_Click(object sender, EventArgs e)
        {

        }//label de email

        private void label4_Click(object sender, EventArgs e)
        {

        }//label de nome

        private void label5_Click(object sender, EventArgs e)
        {

        }//label de telefone







        //=================================================== T e x t  b o x ==================================


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//text box de codigo

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//text box de email

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//text box de nome

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }//text box de endereco

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }// masked text box de telefone




        //============================================================================================================











        
        //=================================================== B u t t o n s =====================================


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.ReadOnly == false)
                {
                    Limpar();
                    InativarCampos();
                }
                else
                {
                    string email = textBox2.Text;//Coletando o dado do campo CPF
                    string nome = textBox3.Text;//Coletando o dado do campo nome
                    string telefone = maskedTextBox1.Text;//Coletando o dado do campo telefone
                    string endereco = textBox5.Text;//Coletando o dado do campo Endereço
                                                    //Chamar o método inserir que foi criado na classe DAOPessoa
                    pessoa.Inserir2(email, nome, telefone, endereco);//Inserir no banco os dados do formulário
                    Limpar();//Limpo os campos
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }//botao de cadastrar





        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == true)
            {
                AtivarCampos();
            }
            else
            {
                textBox2.Text = "" + pessoa.ConsultarEmail(Convert.ToInt32(textBox1.Text));//Preenchendo o campo email
                textBox3.Text = pessoa.ConsultarNome(Convert.ToInt32(textBox1.Text));//Preenchendo o campo nome
                maskedTextBox1.Text = pessoa.ConsultarTelefone(Convert.ToInt32(textBox1.Text));//Prenchendo o campo telefone
                textBox5.Text = pessoa.ConsultarEndereco(Convert.ToInt32(textBox1.Text));//Prenchendo o campo endereco
            }
        }//botao de consultar







        private void button3_Click(object sender, EventArgs e)
        {
            AtivarTodosOsCampos();
            if (textBox2.Text == "")
            {
                //Se o campo nome está vazio, então preenche com o dados do banco...
                textBox2.Text = "" + pessoa.ConsultarEmail(Convert.ToInt32(textBox1.Text));//Preenchendo o campo email
                textBox3.Text = pessoa.ConsultarNome(Convert.ToInt32(textBox1.Text));//Preenchendo o campo nome
                maskedTextBox1.Text = pessoa.ConsultarTelefone(Convert.ToInt32(textBox1.Text));//Prenchendo o campo telefone
                textBox5.Text = pessoa.ConsultarEndereco(Convert.ToInt32(textBox1.Text));//Prenchendo o campo endereco
            }
            else
            {
                //Atualizar o CPF
                string atuEmail = pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "email", textBox2.Text);
                //Atualizar o Nome
                string atuNome = pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "nome", textBox3.Text);
                //Atualizar o Telefone
                string atuTelefone = pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "telefone", maskedTextBox1.Text);
                //Atualizar o Endereço
                string atuEndereco = pessoa.Atualizar(Convert.ToInt32(textBox1.Text), "endereco", textBox5.Text);

                //Resposta...
                if ((atuEmail == "Atualizado!") && (atuNome == "Atualizado!") && (atuTelefone == "Atualizado!") && (atuEndereco == "Atualizado!"))
                {
                    MessageBox.Show("Atualizado com Sucesso!");
                }
                else
                {
                    MessageBox.Show("Não Atualizado!");
                }
                Limpar();//Limpo os campos
            }
        }//botao de atualizar






        private void button4_Click(object sender, EventArgs e)
        {
            AtivarCampos();
            pessoa.Deletar(Convert.ToInt32(textBox1.Text));
            Limpar();//Limpo os campos
        }//botao de excluir





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        //==================================================================================================================









    }//fim da classe
}//fim projeto
