using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfDBMS027
{
    /// <summary>
    /// Логика взаимодействия для MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {

        private Window wndSample;

        public MainWindow1()
        {
            InitializeComponent();

            wndSample = new MainWindow();

        }

        private void btn0303_Click(object sender, RoutedEventArgs e)
        {
            this.wndSample.Show();
        }
    }
}
