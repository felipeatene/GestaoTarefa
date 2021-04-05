using GestaoTarefas.Business;
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

namespace GestaoTarefas.View
{
    /// <summary>
    /// Interaction logic for frmDashboard.xaml
    /// </summary>
    public partial class frmDashboard : Window
    {
        public Negocio servico; // Camada de negócio.
        public Tarefa tarefaSelecionada; 
        public frmDashboard(Negocio conexao)
        {
            InitializeComponent();
            servico = conexao;
            lblUsuarioLogado.Text = conexao.usuarioLogado.usuario1;
            AtualizarDashBoard();
        }

        public List<string> ListaAFazer { get; set; }

        private void AtualizarDashBoard()
        {
            var tarefasAFazer = servico.GetTarefasUsuarioAFazer();
            var tarefasConcluir = servico.GetTarefasUsuarioConcluir();

            lstAFazer.Items.Clear();
            lstFeitas.Items.Clear();

            foreach (var tarefa in tarefasAFazer.Reverse())
            {
                lstAFazer.Items.Add(tarefa);
            }
            foreach (var tarefa in tarefasConcluir.Reverse())
            {
                lstFeitas.Items.Add(tarefa);
            }
        }

        private void BtnAddTarefa_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                servico.CriarTarefa(txtDescricao.Text);
            }
            else
            {
                MessageBox.Show("Necessita de dados...");
            }
            txtDescricao.Text = "";
            AtualizarDashBoard();
        }

        private void btnAtualizarDashboard_Click(object sender, RoutedEventArgs e)
        {
            AtualizarDashBoard();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            tarefaSelecionada = (Tarefa)((Button)sender).DataContext;

            txtDescricao.Text = tarefaSelecionada.Descricao;
            //mudança
            lblTitulo.Visibility = Visibility.Hidden;
            lblTituloEditar.Visibility = Visibility.Visible;
            btnAddTarefa.Visibility = Visibility.Hidden;
            btnCancelarTarefa.Visibility = Visibility.Visible;
            btnEditarTarefa.Visibility = Visibility.Visible;
            AtualizarDashBoard();

        }

        private void btnEditarTarefa_Click(object sender, RoutedEventArgs e)
        {

            servico.EditarTarefa(txtDescricao.Text, tarefaSelecionada.ID);
            txtDescricao.Text = "";
            //mudança
            lblTitulo.Visibility = Visibility.Visible;
            lblTituloEditar.Visibility = Visibility.Hidden;
            btnAddTarefa.Visibility = Visibility.Visible;
            btnCancelarTarefa.Visibility = Visibility.Hidden;
            btnEditarTarefa.Visibility = Visibility.Hidden;
            AtualizarDashBoard();
        }

        private void btnCancelarTarefa_Click(object sender, RoutedEventArgs e)
        {
            txtDescricao.Text = "";
            //mudança
            lblTitulo.Visibility = Visibility.Visible;
            lblTituloEditar.Visibility = Visibility.Hidden;
            btnAddTarefa.Visibility = Visibility.Visible;
            btnCancelarTarefa.Visibility = Visibility.Hidden;
            btnEditarTarefa.Visibility = Visibility.Hidden;
            AtualizarDashBoard();

        }

        private void btnConcluir_Click(object sender, RoutedEventArgs e)
        {
            tarefaSelecionada = (Tarefa)((Button)sender).DataContext;

            servico.ConcluirTarefa(tarefaSelecionada.ID);
            AtualizarDashBoard();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            tarefaSelecionada = (Tarefa)((Button)sender).DataContext;

            servico.ExcluirTarefa(tarefaSelecionada.ID);
            AtualizarDashBoard();
        }
    }
}
