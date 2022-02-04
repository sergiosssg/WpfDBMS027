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


    enum DBGrid_editing_mode
    {
        EMPTY,
        PREMODIFY_MODE,
        EDITING_MODE,
        ADDING_MODE,
        DELETING_MODE,
        SEARCHING_MODE,
        CHANGED_MODE,
        SAVED_MODE
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CollectionViewSource tel_vid_connectionViewSource;

        private PO_TEL_VID_CONNECT _po_tel_vid_connect;

        private int _iKeySelected;

        private bool _is_adding_new_element;

        private IDictionary<DBGrid_editing_mode, Color> _editingModeWithColorMatching;

        private DBGrid_editing_mode _DBGrid_Editing_Mode;


        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }



        public DbAppContext DbAppContextProperty { get; }



        public MainWindow()
        {
            ReadRecordsFromDBTable();


            ReadRecordsFromDBTableUsing_EF();

            OptionsOfDbContext = new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

            DbAppContextProperty = new DbAppContext(OptionsOfDbContext);


            this._editingModeWithColorMatching = new Dictionary<DBGrid_editing_mode, Color>();

            this._is_adding_new_element = false;


            this._DBGrid_Editing_Mode = DBGrid_editing_mode.EMPTY;

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
                txtFld_ID.IsEnabled = true;
                txtFld_KodOfConnect.IsEnabled = true;
                txtFld_Name.IsEnabled = true;
                btn_Search.IsEnabled = true;

                this._DBGrid_Editing_Mode = DBGrid_editing_mode.SAVED_MODE;
            }
        }

        private void txtFld_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((txtFld_ID.Text != null && txtFld_ID.Text.Length > 0) && (txtFld_KodOfConnect.Text != null && txtFld_KodOfConnect.Text.Length == 1) && (txtFld_Name.Text != null && txtFld_Name.Text.Length > 0))
            {
                btn_OK.IsEnabled = true;
            }
        }

        private void txtFld_KodOfConnect_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((txtFld_ID.Text != null && txtFld_ID.Text.Length > 0) && (txtFld_KodOfConnect.Text != null && txtFld_KodOfConnect.Text.Length == 1) && (txtFld_Name.Text != null && txtFld_Name.Text.Length > 0))
            {
                btn_OK.IsEnabled = true;
            }
        }

        private void txtFld_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

            var _txtBox = txtFld_ID;

            var ttt = _txtBox.Foreground.GetType().Name;
            var tforeground = _txtBox.Foreground;
            var tval = _txtBox.Foreground.ToString();

            if ((txtFld_ID.Text != null && txtFld_ID.Text.Length > 0) &&
                (txtFld_KodOfConnect.Text != null && txtFld_KodOfConnect.Text.Length == 1) &&
                (txtFld_Name.Text != null && txtFld_Name.Text.Length > 0))
            {
                btn_OK.IsEnabled = true;
            }
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            //  сформировать новую   PO_TEL_VID_CONNECT
            //  и добавить в модель  ..

            PO_TEL_VID_CONNECT new_TEL_VID_CONNECT = new PO_TEL_VID_CONNECT();
            new_TEL_VID_CONNECT.Id = Int32.Parse(txtFld_ID.Text);
            new_TEL_VID_CONNECT.KodOfConnect = txtFld_KodOfConnect.Text;
            new_TEL_VID_CONNECT.Name = txtFld_Name.Text;

            if (is_validRecord(new_TEL_VID_CONNECT) && is_unique_key_of_integer_value(new_TEL_VID_CONNECT.Id, DbAppContextProperty))
            {
                DbAppContextProperty.pO_TEL_VID_CONNECTs.Add(new_TEL_VID_CONNECT);

                bool resultOfRefreshing = RefreshDataGridWithCollection(dgrid__VID_CONNECT, DbAppContextProperty);

                if (resultOfRefreshing)
                {
                    txtFld_ID.Text = "";
                    txtFld_KodOfConnect.Text = "";
                    txtFld_Name.Text = "";

                    btn_OK.IsEnabled = false;


                    btnSave.IsEnabled = true;


                    this._iKeySelected = 0;
                    this._po_tel_vid_connect = null;
                    this._is_adding_new_element = false;
                    if (this._DBGrid_Editing_Mode == DBGrid_editing_mode.ADDING_MODE || this._DBGrid_Editing_Mode == DBGrid_editing_mode.EDITING_MODE)
                    {
                        this._DBGrid_Editing_Mode = DBGrid_editing_mode.CHANGED_MODE;
                    }

                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //  сохранить модель в БД ..
            //
            DbAppContextProperty.SaveChanges();

            this._po_tel_vid_connect = null;

            this._iKeySelected = 0;

            this._DBGrid_Editing_Mode = DBGrid_editing_mode.SAVED_MODE;

            btnSave.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;

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
            this._DBGrid_Editing_Mode = DBGrid_editing_mode.DELETING_MODE;

            bool resultOfRefreshing = false;

            IList<PO_TEL_VID_CONNECT> objectsForDeleting = new List<PO_TEL_VID_CONNECT>();

            foreach (var oneItem in dgrid__VID_CONNECT.SelectedItems)
            {
                var oneRecord = DbAppContextProperty.pO_TEL_VID_CONNECTs.Find(((PO_TEL_VID_CONNECT)oneItem).Id);
                objectsForDeleting.Add(oneRecord);
            }
            foreach (var el in objectsForDeleting)
            {
                DbAppContextProperty.pO_TEL_VID_CONNECTs.Remove(el);
            }

            resultOfRefreshing = RefreshDataGridWithCollection(dgrid__VID_CONNECT, DbAppContextProperty);
            if (resultOfRefreshing)
            {
                this._iKeySelected = 0;
                this._po_tel_vid_connect = null;

                btnSave.IsEnabled = true;
                btnDelete.IsEnabled = false;
                this._DBGrid_Editing_Mode = DBGrid_editing_mode.CHANGED_MODE;
            }
        }



        private void dgrid__VID_CONNECT_GotFocus(object sender, RoutedEventArgs e)
        {

            try
            {
                var selectedElement = dgrid__VID_CONNECT.CurrentItem;
                if ((selectedElement as PO_TEL_VID_CONNECT) != null)
                {
                    this._iKeySelected = ((PO_TEL_VID_CONNECT)selectedElement).Id;
                    btnDelete.IsEnabled = true;

                    IList<Control> textFields = new List<Control>();

                    textFields.Add(txtFld_ID);
                    textFields.Add(txtFld_KodOfConnect);
                    textFields.Add(txtFld_Name);

                    this._DBGrid_Editing_Mode = DBGrid_editing_mode.PREMODIFY_MODE;

                    FillTextBoxesByRecordValues(textFields, (PO_TEL_VID_CONNECT)selectedElement, this._DBGrid_Editing_Mode, _editingModeWithColorMatching);

                }
                else
                {
                    btnDelete.IsEnabled = false;
                    this._iKeySelected = 0;
                    this._is_adding_new_element = true;
                }
            }
            catch (InvalidCastException ice)
            {

            }
        }



        private bool is_changedRecordAfterEditingDataGrid(object recordTarget)
        {
            if(recordTarget == null || this._po_tel_vid_connect == null)
            {
                return false;
            }
            try
            {
                if (recordTarget.GetType() != typeof(PO_TEL_VID_CONNECT))
                {
                    return false;
                }

                PO_TEL_VID_CONNECT record_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)recordTarget;

                if(this._po_tel_vid_connect.isEmpty() || record_TEL_VID_CONNECT.isEmpty())
                {
                    return false;
                }

                if ((this._po_tel_vid_connect.Id != record_TEL_VID_CONNECT.Id) ||
                    (!this._po_tel_vid_connect.KodOfConnect.Equals(record_TEL_VID_CONNECT.KodOfConnect)) ||
                    (!this._po_tel_vid_connect.Name.Equals(record_TEL_VID_CONNECT.Name)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException nre)
            {

            }
            return false;

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




        /**
         * <summary
         * 
         * is selected record is valid for modifying 
         * 
         */
        private bool is_validRecord(object recordTarget)
        {
            if (recordTarget.GetType() != typeof(PO_TEL_VID_CONNECT))
            {
                return false;
            }
            PO_TEL_VID_CONNECT record_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)recordTarget;


            if ((record_TEL_VID_CONNECT.Id == 0) ||
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

            foreach (var oneRecord in listOfRecords)
            {
                if (record_TEL_VID_CONNECT.Id == oneRecord.Id)
                {
                    return false;
                }
            }
            return true;
        }


        private bool is_unique_key_of_integer_value(int keyValue, DbContext dbContext)
        {
            if ((dbContext == null) || (dbContext.GetType() != typeof(DbAppContext)))
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


        /**
         * <summary>
         *  filling controls with record values
         * </summary>
         * 
         * 
         */
        private bool FillTextBoxesByRecordValues(IList<Control> controls, object oRecord, DBGrid_editing_mode dBGrid_Editing_Mode, IDictionary<DBGrid_editing_mode, Color> editingModeWithColorMatching)
        {
            TextBox[] textBoxes = new TextBox[controls.Count];
            PO_TEL_VID_CONNECT pO_record;
            int iii = 0;
            foreach (var el in controls)
            {
                var textBox = el; ;
                if ((textBox as TextBox) != null)
                {
                    textBoxes[iii++] = (TextBox)textBox;
                }
            }
            if (oRecord.GetType() == typeof(PO_TEL_VID_CONNECT))
            {
                pO_record = (PO_TEL_VID_CONNECT)oRecord;

                textBoxes[0].Text = pO_record.Id.ToString();
                textBoxes[1].Text = pO_record.KodOfConnect;
                textBoxes[2].Text = pO_record.Name;

                return true;
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
