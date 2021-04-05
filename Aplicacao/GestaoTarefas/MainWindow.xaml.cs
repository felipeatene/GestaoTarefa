using GestaoTarefas.Business;
using GestaoTarefas.Model;
using GestaoTarefas.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestaoTarefas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Negocio servico; // Camada de negócio.

        public MainWindow()
        {
            InitializeComponent();
            servico = new Negocio();
        }

        private void BtnNovoUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastro telaCadastro = new frmCadastro(servico);
            this.Visibility = System.Windows.Visibility.Collapsed;
            telaCadastro.ShowDialog();
            this.Visibility = System.Windows.Visibility.Visible;
            txtSenha.Clear();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            //Logar
            if (servico.Logar(txtUsuario.Text, txtSenha.Password) != null)
            {
                frmDashboard telaDashboard = new frmDashboard(servico);
                this.Visibility = System.Windows.Visibility.Collapsed;
                telaDashboard.ShowDialog();
                this.Visibility = System.Windows.Visibility.Visible;
                txtSenha.Clear();
            }
            else
            {
                MostrarMensagem("Usuario não existe ou senha incorreta.");
                txtSenha.Clear();
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
    }
}
