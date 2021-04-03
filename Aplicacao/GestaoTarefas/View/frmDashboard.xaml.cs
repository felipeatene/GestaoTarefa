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
        public frmDashboard()
        {
            InitializeComponent();
        }

        public List<string> ListaAFazer { get; set; }

        private void BtnAddTarefa_Click(object sender, RoutedEventArgs e)
        {
            lstAFazer.Items.Add(new { TESTE = txtDescricao.Text });
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
