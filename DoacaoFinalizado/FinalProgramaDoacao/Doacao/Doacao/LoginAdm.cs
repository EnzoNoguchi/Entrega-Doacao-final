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
    public partial class LoginAdm : Form
    {
        public LoginAdm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }//titulo





        //=============================================== Usuario =================================================





        private void label2_Click(object sender, EventArgs e)
        {

        }//label de Usuario

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//textbox de usuario




        //======================================================== Senha ==============================



        private void label3_Click(object sender, EventArgs e)
        {
            
        }//label de Senha

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//textbox de senha

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "admin" && textBox1.Text == "1234")
            {
                MessageBox.Show("Bem vindo ao sistema!");
                this.Visible = false;
                Administrador formADM = new Administrador();
                formADM.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha invalindos!");
            }
        }
    }//fim da classe
}//fim do projeto
