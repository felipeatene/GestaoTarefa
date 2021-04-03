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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNovoUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastro telaCadastro = new frmCadastro();
            this.Visibility = System.Windows.Visibility.Collapsed;
            telaCadastro.ShowDialog();
            this.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {

            frmDashboard telaDashboard = new frmDashboard();
            this.Visibility = System.Windows.Visibility.Collapsed;
            telaDashboard.ShowDialog();
            this.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
