using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDBMS027
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CollectionViewSource tel_vid_connectionViewSource;

        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }

        public DbAppContext DbAppContextProperty { get; }

        public MainWindow()
        {
            ReadRecordsFromDBTable();


            ReadRecordsFromDBTableUsing_EF();

            OptionsOfDbContext = new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

            DbAppContextProperty = new DbAppContext(OptionsOfDbContext);

/*
            try
            {
                ;
                DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();
                ;

                foreach (var eee in DbAppContextProperty.pO_TEL_VID_CONNECTs)
                {
                    var iii = eee.Id;
                    var kkk = eee.KodOfConnect;
                    var nnn = eee.Name;
                }


            }
            catch (Exception exe)
            {
                var _et = exe.GetType().Name;
                var _eM = exe.Message;
                var _eTr = exe.StackTrace;
            }
*/


            InitializeComponent();
        }

        private static string GetConnectionString()
        {
            DbConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder["Data Source"] = @"localhost\SQLExpress";////@"localhost\SQLExpress";

            builder["Database"] = "sampd_cexs";

            builder["integrated Security"] = "true";

            return builder.ConnectionString;
        }

        private static void ReadRecordsFromDBTable()
        {

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {

                try
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM TEL_VID_CONNECT";
                    command.Connection = connection;

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Соединение установлено!");
                    }
                    else if (connection.State == System.Data.ConnectionState.Connecting)
                    {
                        Console.WriteLine("Соединение в процессе установки ...");
                    }
                    else if (connection.State == System.Data.ConnectionState.Broken)
                    {
                        Console.WriteLine("Соединение поломано :-((");
                    }

                    var dataReader = command.ExecuteReader();

                    while (dataReader.HasRows)
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", dataReader.GetName(0), dataReader.GetName(1), dataReader.GetName(2));

                        while (dataReader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}", dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2));
                        }
                        dataReader.NextResult();
                    }
                }
                catch (SqlException sqe)
                {
                    Console.Error.WriteLine(sqe.Message);
                }
            }

        }

        private static void ReadRecordsFromDBTableUsing_EF()
        {

            DbContextOptions<DbAppContext> _options = new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;




            using (var dbContent = new DbAppContext( _options))
            {
                //dbContent.pO_TEL_VID_CONNECTs.Load();

                var simpleVidConnects = dbContent.pO_TEL_VID_CONNECTs;




                foreach (var oneTEL_VID_CONNECT in simpleVidConnects)
                {
                    Console.WriteLine(" Id = {0}  Kod связи {1}  Название вида связи {2}", oneTEL_VID_CONNECT.Id, oneTEL_VID_CONNECT.KodOfConnect, oneTEL_VID_CONNECT.Name);

                }
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

            DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();

            dgrid__VID_CONNECT.ItemsSource = DbAppContextProperty.pO_TEL_VID_CONNECTs.Local.ToList();

            //dgrid__VID_CONNECT.DataContext = DbAppContextProperty.pO_TEL_VID_CONNECTs;





            txtFld1.IsEnabled = true;
            txtFld2.IsEnabled = true;
            txtFld3.IsEnabled = true;
        }

        private void txtFld1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((txtFld1.Text != null && txtFld1.Text.Length > 0 ) && (txtFld2.Text != null && txtFld2.Text.Length == 1) && (txtFld3.Text != null && txtFld3.Text.Length > 0))
            {
                btnAdd.IsEnabled = true;
            }
        }

        private void txtFld2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((txtFld1.Text != null && txtFld1.Text.Length > 0) && (txtFld2.Text != null && txtFld2.Text.Length == 1) && (txtFld3.Text != null && txtFld3.Text.Length > 0))
            {
                btnAdd.IsEnabled = true;
            }
        }

        private void txtFld3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((txtFld1.Text != null && txtFld1.Text.Length > 0) && (txtFld2.Text != null && txtFld2.Text.Length == 1) && (txtFld3.Text != null && txtFld3.Text.Length > 0))
            {
                btnAdd.IsEnabled = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //  сформировать новую   PO_TEL_VID_CONNECT
            //  и добавить в модель  ..

            PO_TEL_VID_CONNECT new_TEL_VID_CONNECT = new PO_TEL_VID_CONNECT();
            new_TEL_VID_CONNECT.Id = Int32.Parse(txtFld1.Text);
            new_TEL_VID_CONNECT.KodOfConnect = txtFld2.Text;
            new_TEL_VID_CONNECT.Name = txtFld3.Text;

            txtFld1.Text = "";
            txtFld2.Text = "";
            txtFld3.Text = "";

            btnAdd.IsEnabled = false;

            DbAppContextProperty.pO_TEL_VID_CONNECTs.Add(new_TEL_VID_CONNECT);

            btnSave.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //  сохранить модель в БД ..
            //
            DbAppContextProperty.SaveChanges();
            btnSave.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ;
            //dgrid__VID_CONNECT.ItemsSource = DbAppContextProperty.pO_TEL_VID_CONNECTs;
            //dgrid__VID_CONNECT.ItemsSource = DbAppContextProperty.pO_TEL_VID_CONNECTs;
        }
    }
}
