using GestaoTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GestaoTarefas.Business;

namespace GestaoTarefas.View
{
    /// <summary>
    /// Interaction logic for frmCadastro.xaml
    /// </summary>
    public partial class frmCadastro : Window
    {
        public Negocio servico; // Camada de negócio.

        public frmCadastro(Negocio conexao)
        {
            InitializeComponent();
            servico = conexao;
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //Cadastrar Usuario.
            if (txtUsuario.Text != "" && txtSenha.Password != "")
            {
                if (servico.CriarUsuario(txtUsuario.Text, txtSenha.Password) != null)
                {
                    MostrarMensagem("Usuario cadastrado");
                    this.Close();

                }
                else
                {
                    MostrarMensagem("Usuario ja cadastrado");
                    txtUsuario.Clear();
                    txtSenha.Clear();
                }
            }
        }
        private void MostrarMensagem(string mensagem)
        {
            txtMensagemErro.Text = mensagem;
            rtMensagem.Visibility = Visibility.Visible;
            txtMensagemErro.Visibility = Visibility.Visible;
            btnFecharMensagem.Visibility = Visibility.Visible;

        }

        private void btnFecharMensagem_Click(object sender, RoutedEventArgs e)
        {
            txtMensagemErro.Text = "";
            rtMensagem.Visibility = Visibility.Hidden;
            txtMensagemErro.Visibility = Visibility.Hidden;
            btnFecharMensagem.Visibility = Visibility.Hidden;
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
