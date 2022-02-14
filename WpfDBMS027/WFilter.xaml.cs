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
    /// Логика взаимодействия для WFilter.xaml
    /// </summary>
    public partial class WFilter : Window
    {
        private Window _parentWindow;

        public WFilter(Window parent)
        {
            this.Owner = parent;

            InitializeComponent();
        }

        private void btn_Ok_from_filter_Click(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void btn_Cancel_from_filter_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
            //this.WindowState = WindowState.Minimized;
            
            

            //this.Close();

        }
    }
}
