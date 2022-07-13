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
    public partial class Opcao : Form
    {
        Opcao form;
        Opcao formAdm;

        public Opcao()
        {
            InitializeComponent();
    
        }

        private void Opcao_Load(object sender, EventArgs e)
        {

        }



        //------------------------------------------------------- D E S I G N ------------------------------------------------



        private void label1_Click(object sender, EventArgs e)
        {

        }//Escolha uma opcao

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }//borda branca


        //------------------------------------------------------- D E S I G N ------------------------------------------------








        ////------------------------------------------------------- B O T Õ E S ------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 Cliente = new Form1();
            Cliente.ShowDialog();
            this.Visible = true;

        }//botao cliente

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginAdm FormLogin = new LoginAdm();
            FormLogin.ShowDialog();
            this.Visible = true;

           
        }//botao administrador


        ////------------------------------------------------------- B O T Õ E S ------------------------------------------------



    }//fim da classe
}//fim do projeto
