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

        private Window _wndSample;
        private Page _pageSample;

        public MainWindow1()
        {
            InitializeComponent();

            this._wndSample = new WndSample();
            this._pageSample = new PageSimpleVz();
        }

        private void btn0303_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this._wndSample.Show();
            }
            catch (InvalidOperationException iopex)
            {

            }
        }

        private void btn0303__2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btn0303__2.Visibility = Visibility.Hidden;
                
                frm4PageSimple.Content = this._pageSample;

                



                frm4PageSimple.Visibility = Visibility.Visible;
                //this._pageSample.Visibility = Visibility.Visible;
            }
            catch (InvalidOperationException iopex)
            {

            }
        }
    }
}
