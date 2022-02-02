using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Path = System.IO.Path;

namespace WpfDBMS027
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CollectionViewSource tel_vid_connectionViewSource;

        private PO_TEL_VID_CONNECT _po_tel_vid_connect;

        private int _iKeySelected;

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

            builder["Data Source"] = "localhost";
            //builder["Data Source"] = @"localhost\SQLExpress";////@"localhost\SQLExpress";

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




            using (var dbContent = new DbAppContext(_options))
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
            bool resultOfRefreshing = RefreshDataGridWithCollection(dgrid__VID_CONNECT, DbAppContextProperty);

            if (resultOfRefreshing)
            {
                txtFld1.IsEnabled = true;
                txtFld2.IsEnabled = true;
                txtFld3.IsEnabled = true;
            }
        }

        private void txtFld1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((txtFld1.Text != null && txtFld1.Text.Length > 0) && (txtFld2.Text != null && txtFld2.Text.Length == 1) && (txtFld3.Text != null && txtFld3.Text.Length > 0))
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

            DbAppContextProperty.pO_TEL_VID_CONNECTs.Add(new_TEL_VID_CONNECT);

            bool resultOfRefreshing = RefreshDataGridWithCollection(dgrid__VID_CONNECT, DbAppContextProperty);

            if (resultOfRefreshing)
            {
                txtFld1.Text = "";
                txtFld2.Text = "";
                txtFld3.Text = "";

                btnAdd.IsEnabled = false;


                btnSave.IsEnabled = true;


                this._iKeySelected = 0;
                this._po_tel_vid_connect = null;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //  сохранить модель в БД ..
            //
            DbAppContextProperty.SaveChanges();

            this._po_tel_vid_connect = null;

            this._iKeySelected = 0;

            btnSave.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            tel_vid_connectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("TEL_VID_CONNECTS")));


            DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();

            //bool resultOfRefreshing = SettingDataContextforControl(dgrid__VID_CONNECT, DbAppContextProperty);


            //tel_vid_connectionViewSource.Source = DbAppContextProperty.pO_TEL_VID_CONNECTs.Local;

            //tel_vid_connectionViewSource.Source = DbAppContextProperty.pO_TEL_VID_CONNECTs.ToList<PO_TEL_VID_CONNECT>();

            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;

            //dgrid__VID_CONNECT.ItemsSource = DbAppContextProperty.pO_TEL_VID_CONNECTs;
            //dgrid__VID_CONNECT.ItemsSource = DbAppContextProperty.pO_TEL_VID_CONNECTs;
        }

        private void dgrid__VID_CONNECT_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            _po_tel_vid_connect = (PO_TEL_VID_CONNECT)dgrid__VID_CONNECT.CurrentItem;

            ;

        }



        private void dgrid__VID_CONNECT_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            PO_TEL_VID_CONNECT currRecord_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)dgrid__VID_CONNECT.CurrentItem;


            bool resultOfComparingOfRecords = is_validRecord(currRecord_TEL_VID_CONNECT);

            resultOfComparingOfRecords &= is_changedRecordAfterEditingDataGrid(currRecord_TEL_VID_CONNECT);

            if (resultOfComparingOfRecords)
            {
                btnSave.IsEnabled = true;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ;
            ;// delete selected record
            ;
            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;

            btnSave.IsEnabled = true;
            btnDelete.IsEnabled = false;
        }



        private void dgrid__VID_CONNECT_GotFocus(object sender, RoutedEventArgs e)
        {
            this._iKeySelected = ((PO_TEL_VID_CONNECT)dgrid__VID_CONNECT.CurrentItem).Id;
            btnDelete.IsEnabled = true;
        }



        private bool is_changedRecordAfterEditingDataGrid(object recordTarget)
        {
            if (recordTarget.GetType() != typeof(PO_TEL_VID_CONNECT))
            {
                return false;
            }

            PO_TEL_VID_CONNECT record_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)recordTarget;

            if ((_po_tel_vid_connect.Id != record_TEL_VID_CONNECT.Id) ||
                (!_po_tel_vid_connect.KodOfConnect.Equals(record_TEL_VID_CONNECT.KodOfConnect)) ||
                (!_po_tel_vid_connect.Name.Equals(record_TEL_VID_CONNECT.Name)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /**
         *  <summary
         *  
         *  this function performs all work with displaying data in Control
         *  
         */
        private bool RefreshDataGridWithCollection(Control dataViewControl, DbContext dbContext, ICollection collection = null)
        {
            if (dataViewControl == null) return false;
            if (dataViewControl.GetType() == typeof(DataGrid))
            {
                DataGrid dGrid = (DataGrid)dataViewControl;

                if (collection == null && dbContext.GetType() == typeof(DbAppContext))
                {
                    var dbAppContext = (DbAppContext)dbContext;

                    var itemsOf_TEL_VID_CONNECT = dbAppContext.pO_TEL_VID_CONNECTs.Local.ToBindingList();

                    Type ttt = itemsOf_TEL_VID_CONNECT.GetType();

                    var arrayOfInterfaces = ttt.GetInterfaces();

                    foreach (var oneTypeOfInterface in arrayOfInterfaces)
                    {
                        var strOfInterfaceType = oneTypeOfInterface.Name;
                        if (strOfInterfaceType.EndsWith("INotifyCollectionChanged"))
                        {
                            ; ; ;
                        }
                    }

                    dGrid.ItemsSource = itemsOf_TEL_VID_CONNECT;



                    return true;
                }
                else
                {
                    dGrid.ItemsSource = collection;
                    return true;
                }
            }
            return false;
        }





        private bool is_validRecord(object recordTarget)
        {
            if (recordTarget.GetType() != typeof(PO_TEL_VID_CONNECT))
            {
                return false;
            }
            PO_TEL_VID_CONNECT record_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)recordTarget;


            if((record_TEL_VID_CONNECT.Id == 0) ||
                (
                (record_TEL_VID_CONNECT.KodOfConnect == null) || (record_TEL_VID_CONNECT.KodOfConnect.Length == 0) || (record_TEL_VID_CONNECT.KodOfConnect.Equals(string.Empty)) &&
                (record_TEL_VID_CONNECT.Name == null) || (record_TEL_VID_CONNECT.Name.Length == 0) || (record_TEL_VID_CONNECT.Name.Equals(string.Empty))))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool is_unique_key_of_record(object recordTarget, DbContext dbContext)
        {
            if (recordTarget.GetType() != typeof(PO_TEL_VID_CONNECT) ||
                (dbContext == null) || (dbContext.GetType() != typeof(DbAppContext)))
            {
                return false;
            }
            PO_TEL_VID_CONNECT record_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)recordTarget;
            DbAppContext dbAppContext = (DbAppContext)dbContext;

            var listOfRecords = dbAppContext.pO_TEL_VID_CONNECTs.Local.ToBindingList();

            foreach(var oneRecord in listOfRecords)
            {
                if(record_TEL_VID_CONNECT.Id == oneRecord.Id)
                {
                    return false;
                }
            }
            return true;
        }


        private bool is_unique_key_of_integer_value(int keyValue, DbContext dbContext)
        {
            if ( (dbContext == null) || (dbContext.GetType() != typeof(DbAppContext)))
            {
                return false;
            }
            DbAppContext dbAppContext = (DbAppContext)dbContext;

            var listOfRecords = dbAppContext.pO_TEL_VID_CONNECTs.Local.ToBindingList();

            foreach (var oneRecord in listOfRecords)
            {
                if (keyValue == oneRecord.Id)
                {
                    return false;
                }
            }
            return true;
        }


        private bool SettingDataContextforControl(Control dataViewControl, DbContext dbContext)
        {
            if (dataViewControl == null) return false;
            if (dataViewControl.GetType() == typeof(DataGrid))
            {
                DataGrid dGrid = (DataGrid)dataViewControl;
                if (dbContext.GetType() == typeof(DbAppContext))
                {
                    var dbAppContext = (DbAppContext)dbContext;
                    dGrid.DataContext = dbAppContext;

                    Binding bindingForDbGrid = new Binding("dbGridWithDbAppContext");
                    bindingForDbGrid.Mode = BindingMode.OneWay;
                    bindingForDbGrid.Source = dbAppContext.pO_TEL_VID_CONNECTs.Local.ToBindingList();

                    dGrid.SetBinding(DataGrid.ItemsSourceProperty, bindingForDbGrid);

                    //dGrid.SetBinding();

                    return true;
                }
            }
            return false;
        }




        private static void WriteLineInLogFile(string message)
        {
            using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", true))
            {
                sw.WriteLine(String.Format("{0,-23} {1}", DateTime.Now.ToString() + ":", message));
            }
        }


        private static void WriteInLogFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\log.txt", true))
            {
                sw.Write(text);
            }
        }

    }
}
