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
using System.Text.RegularExpressions;
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


        static CriteriaOfFilter<PO_TEL_VID_CONNECT> CriteriaOfFilterCollection;


        static public readonly IEnumerable<PO_TEL_VID_CONNECT> TEL_VID_CONNECTs;


        //public readonly static IDictionary<OperatorSignComparision, string> OperatorSignComparisionStrings = new Dictionary<OperatorSignComparision, string>
        public readonly static IDictionary<string, OperatorSignComparision> OperatorSignComparisionStrings = new Dictionary<string, OperatorSignComparision>
        {
            {  "==", OperatorSignComparision._EQ_ },
            { "!=", OperatorSignComparision._NE_},
            { ">", OperatorSignComparision._GT_},
            { "<", OperatorSignComparision._LT_},
            { ">=", OperatorSignComparision._GE_},
            { "<=", OperatorSignComparision._LE_},
            { "<= .. >=", OperatorSignComparision._BETWEEN_NO_STRICT_},
            { "< .. >", OperatorSignComparision._BETWEEN_STRICT_},
            { "< .. >=", OperatorSignComparision._BETWEEN_STRICT_LEFT_},
            { "<= .. >", OperatorSignComparision._BETWEEN_STRICT_RIGHT_}
        };



        public readonly static IDictionary<string, OperatorSignLogic> OperatorSignLogicStrings = new Dictionary<string, OperatorSignLogic>
        {
            { "AND", OperatorSignLogic._AND_ },
            { "OR", OperatorSignLogic._OR_},
            { "AND NOT", OperatorSignLogic._AND_NOT_},
            { "OR NOT", OperatorSignLogic._OR_NOT_},
            { "NIL", OperatorSignLogic._NIL_}
        };




        static public readonly IDictionary<OperatorSignComparision, DelegateOperatorForComparision<PO_TEL_VID_CONNECT>> MapComparisioOperatorToComparisionPredicate = new Dictionary<OperatorSignComparision, DelegateOperatorForComparision<PO_TEL_VID_CONNECT>>()
        {
            { OperatorSignComparision._EQ_, (arg1, arg2, operatorComparision)=> ( operatorComparision == OperatorSignComparision._EQ_) &&
                                                                                (( arg1.Id == arg2.Id ) ||
                                                                                ( arg1.KodOfConnect != string.Empty  && arg2.KodOfConnect != string.Empty  && arg1.KodOfConnect.Equals(arg2.KodOfConnect) ) ||
                                                                                ( arg1.Name != string.Empty && arg2.Name != string.Empty && arg1.Name.Equals( arg2.Name))) },
            { OperatorSignComparision._NE_, (arg1, arg2, operatorComparision)=> ( operatorComparision == OperatorSignComparision._NE_) &&
                                                                                (( arg1.Id != arg2.Id ) &&
                                                                                ( arg1.KodOfConnect != string.Empty && arg2.KodOfConnect != string.Empty && !arg1.KodOfConnect.Equals(arg2.KodOfConnect) ) &&
                                                                                ( arg1.Name != string.Empty && arg2.Name != string.Empty && !arg1.Name.Equals( arg2.Name))) },
            { OperatorSignComparision._GT_, (arg1, arg2, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._GT_) &&
                                                                              (( arg1.Id > arg2.Id ) ||
                                                                              ( arg1.KodOfConnect != string.Empty && arg2.KodOfConnect != string.Empty &&
                                                                              string.Compare(arg1.KodOfConnect, arg2.KodOfConnect, StringComparison.OrdinalIgnoreCase) > 0) ||
                                                                              ( arg1.Name != string.Empty && arg2.Name != string.Empty &&
                                                                              string.Compare(arg1.Name, arg2.Name, StringComparison.OrdinalIgnoreCase) > 0)); } },
            { OperatorSignComparision._LT_, (arg1, arg2, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._LT_) &&
                                                                              ( ( arg1.Id < arg2.Id ) ||
                                                                              ( arg1.KodOfConnect != string.Empty && arg2.KodOfConnect != string.Empty &&
                                                                              string.Compare(arg1.KodOfConnect, arg2.KodOfConnect, StringComparison.OrdinalIgnoreCase) < 0) ||
                                                                              ( arg1.Name != string.Empty && arg2.Name != string.Empty  &&
                                                                              string.Compare(arg1.Name, arg2.Name, StringComparison.OrdinalIgnoreCase) < 0)); } },
            { OperatorSignComparision._GE_, (arg1, arg2, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._GE_) &&
                                                                              (( arg1.Id >= arg2.Id ) ||
                                                                              ( arg1.KodOfConnect != string.Empty && arg2.KodOfConnect != string.Empty &&
                                                                              string.Compare(arg1.KodOfConnect, arg2.KodOfConnect, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                                                              ( arg1.Name != string.Empty && arg2.Name != string.Empty &&
                                                                              string.Compare(arg1.Name, arg2.Name, StringComparison.OrdinalIgnoreCase) >= 0)); } },
            { OperatorSignComparision._LE_, (arg1, arg2, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._LE_) &&
                                                                              (( arg1.Id <= arg2.Id ) ||
                                                                              ( arg1.KodOfConnect != string.Empty && arg2.KodOfConnect != string.Empty  &&
                                                                              string.Compare(arg1.KodOfConnect, arg2.KodOfConnect, StringComparison.OrdinalIgnoreCase) <= 0) ||
                                                                              ( arg1.Name != string.Empty && arg2.Name != string.Empty &&
                                                                              string.Compare(arg1.Name, arg2.Name, StringComparison.OrdinalIgnoreCase) <= 0)); } },
            { OperatorSignComparision._REGEX_, (arg1, arg2, operatorComparision)=> {
                                                                 var regexTemplate = (arg2.KodOfConnect != string.Empty)? new Regex(arg2.KodOfConnect, RegexOptions.IgnoreCase) : (arg2.Name != string.Empty)? new Regex(arg2.Name, RegexOptions.IgnoreCase) : new Regex("");
                                                                 return ( operatorComparision == OperatorSignComparision._REGEX_) &&
                                                                              ( arg1.KodOfConnect != null  &&   !arg1.KodOfConnect.Equals(string.Empty) && regexTemplate.IsMatch(arg1.KodOfConnect) ||
                                                                              ( arg1.Name != null  &&   !arg1.Name.Equals(string.Empty) &&  regexTemplate.IsMatch( arg1.Name))); }}
        };



        static public readonly IDictionary<OperatorSignComparision, DelegateOperatorForComparisionWithTuples<PO_TEL_VID_CONNECT>> MapComparisioOperatorToComparisionPredicateWithTuples = new Dictionary<OperatorSignComparision, DelegateOperatorForComparisionWithTuples<PO_TEL_VID_CONNECT>>()
        {
            { OperatorSignComparision._EQ_, ( arg4compating, argSample, operatorComparision)=> ( operatorComparision == OperatorSignComparision._EQ_) &&
                                                                                (( arg4compating.Item1.Id == argSample.Item1.Id ) ||
                                                                                ( arg4compating.Item1.KodOfConnect != string.Empty  && argSample.Item1.KodOfConnect != string.Empty  && arg4compating.Item1.KodOfConnect.Equals( argSample.Item1.KodOfConnect) ) ||
                                                                                ( arg4compating.Item1.Name != string.Empty && argSample.Item1.Name != string.Empty && arg4compating.Item1.Name.Equals( argSample.Item1.Name))) },
            { OperatorSignComparision._NE_, ( arg4compating, argSample, operatorComparision)=> ( operatorComparision == OperatorSignComparision._NE_) &&
                                                                                (( arg4compating.Item1.Id != argSample.Item1.Id ) &&
                                                                                ( arg4compating.Item1.KodOfConnect != string.Empty && argSample.Item1.KodOfConnect != string.Empty && !arg4compating.Item1.KodOfConnect.Equals( argSample.Item1.KodOfConnect) ) &&
                                                                                ( arg4compating.Item1.Name != string.Empty && argSample.Item1.Name != string.Empty && !arg4compating.Item1.Name.Equals( argSample.Item1.Name))) },
            { OperatorSignComparision._GT_, ( arg4compating, argSample, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._GT_) &&
                                                                              (( arg4compating.Item1.Id > argSample.Item1.Id ) ||
                                                                              ( arg4compating.Item1.KodOfConnect != string.Empty && argSample.Item1.KodOfConnect != string.Empty &&
                                                                              string.Compare( arg4compating.Item1.KodOfConnect, argSample.Item1.KodOfConnect, StringComparison.OrdinalIgnoreCase) > 0) ||
                                                                              ( arg4compating.Item1.Name != string.Empty && argSample.Item1.Name != string.Empty &&
                                                                              string.Compare( arg4compating.Item1.Name, argSample.Item1.Name, StringComparison.OrdinalIgnoreCase) > 0)); } },
            { OperatorSignComparision._LT_, ( arg4compating, argSample, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._LT_) &&
                                                                              ( (  arg4compating.Item1.Id < argSample.Item1.Id ) ||
                                                                              ( arg4compating.Item1.KodOfConnect != string.Empty && argSample.Item1.KodOfConnect != string.Empty &&
                                                                              string.Compare( arg4compating.Item1.KodOfConnect, argSample.Item1.KodOfConnect, StringComparison.OrdinalIgnoreCase) < 0) ||
                                                                              ( arg4compating.Item1.Name != string.Empty && argSample.Item1.Name != string.Empty  &&
                                                                              string.Compare( arg4compating.Item1.Name, argSample.Item1.Name, StringComparison.OrdinalIgnoreCase) < 0)); } },
            { OperatorSignComparision._GE_, ( arg4compating, argSample, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._GE_) &&
                                                                              ((  arg4compating.Item1.Id >= argSample.Item1.Id ) ||
                                                                              (  arg4compating.Item1.KodOfConnect != string.Empty && argSample.Item1.KodOfConnect != string.Empty &&
                                                                              string.Compare( arg4compating.Item1.KodOfConnect, argSample.Item1.KodOfConnect, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                                                              ( arg4compating.Item1.Name != string.Empty && argSample.Item1.Name != string.Empty &&
                                                                              string.Compare( arg4compating.Item1.Name, argSample.Item1.Name, StringComparison.OrdinalIgnoreCase) >= 0)); } },
            { OperatorSignComparision._LE_, ( arg4compating, argSample, operatorComparision)=> {
                                                                 return ( operatorComparision == OperatorSignComparision._LE_) &&
                                                                              (( arg4compating.Item1.Id <= argSample.Item1.Id ) ||
                                                                              (  arg4compating.Item1.KodOfConnect != string.Empty && argSample.Item1.KodOfConnect != string.Empty  &&
                                                                              string.Compare( arg4compating.Item1.KodOfConnect, argSample.Item1.KodOfConnect, StringComparison.OrdinalIgnoreCase) <= 0) ||
                                                                              ( arg4compating.Item1.Name != string.Empty && argSample.Item1.Name != string.Empty &&
                                                                              string.Compare( arg4compating.Item1.Name, argSample.Item1.Name, StringComparison.OrdinalIgnoreCase) <= 0)); } },
            { OperatorSignComparision._REGEX_, ( arg4compating, argSample, operatorComparision)=> {
                                                                 var regexTemplate = (argSample.Item1.KodOfConnect != string.Empty)? new Regex(argSample.Item1.KodOfConnect, RegexOptions.IgnoreCase) : (argSample.Item1.Name != string.Empty)? new Regex(argSample.Item1.Name, RegexOptions.IgnoreCase) : new Regex("");
                                                                 return ( operatorComparision == OperatorSignComparision._REGEX_) &&
                                                                              ( arg4compating.Item1.KodOfConnect != null  &&   !arg4compating.Item1.KodOfConnect.Equals(string.Empty) && regexTemplate.IsMatch( arg4compating.Item1.KodOfConnect) ||
                                                                              (  arg4compating.Item1.Name != null  &&   !arg4compating.Item1.Name.Equals(string.Empty) &&  regexTemplate.IsMatch( arg4compating.Item1.Name))); }}
        };





        private CollectionViewSource _tel_vid_connection_CollectionViewSource;

        private PO_TEL_VID_CONNECT _po_tel_vid_connect;

        private IEnumerable<PO_TEL_VID_CONNECT> _foundCollection_PO_TEL_VID_CONNECTs;

        private bool _is_found_PO_TEL_VID_CONNECT;

        private int _iKeySelected;

        //private bool _is_adding_new_element;

        private IDictionary<DBGrid_editing_mode, Color> _editingModeWithColorMatching;

        private DBGrid_editing_mode _DBGrid_Editing_Mode;


        private IList<Control> _textFields;


        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }



        public DbAppContext DbAppContextProperty { get; }




        //public Window 


        public MainWindow()
        {
            ReadRecordsFromDBTable();
            ReadRecordsFromDBTableUsing_EF();

            OptionsOfDbContext = new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

            DbAppContextProperty = new DbAppContext(OptionsOfDbContext);


            this._textFields = new List<Control>();
            this._editingModeWithColorMatching = new Dictionary<DBGrid_editing_mode, Color>();

            this._is_found_PO_TEL_VID_CONNECT = false;
            this._DBGrid_Editing_Mode = DBGrid_editing_mode.EMPTY;
            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;





            InitializeComponent();
        }

        private static string GetConnectionString()
        {
            DbConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder["Data Source"] = "localhost";
            //builder["Data Source"] = @"localhost\SQLExpress";

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

            }

            this._DBGrid_Editing_Mode = DBGrid_editing_mode.SAVED_MODE;
            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;
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
                    //this._is_adding_new_element = false;
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

            this._DBGrid_Editing_Mode = DBGrid_editing_mode.SAVED_MODE;
            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;


            btnSave.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._textFields.Add(txtFld_ID);
            this._textFields.Add(txtFld_KodOfConnect);
            this._textFields.Add(txtFld_Name);


            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;

        }

        private void dgrid__VID_CONNECT_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            /*
                        this._po_tel_vid_connect = (PO_TEL_VID_CONNECT)dgrid__VID_CONNECT.CurrentItem;
                        if (this._DBGrid_Editing_Mode == DBGrid_editing_mode.PREMODIFY_MODE && !this._po_tel_vid_connect.isEmpty())
                        {
                            this._DBGrid_Editing_Mode = DBGrid_editing_mode.EDITING_MODE;
                        }
                        else if (this._DBGrid_Editing_Mode == DBGrid_editing_mode.PREMODIFY_MODE && this._po_tel_vid_connect.isEmpty())
                        {
                            this._DBGrid_Editing_Mode = DBGrid_editing_mode.ADDING_MODE;
                        }*/

            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null)
                {

                }
            }
        }





        private void dgrid__VID_CONNECT_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            /*            PO_TEL_VID_CONNECT currRecord_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)dgrid__VID_CONNECT.CurrentItem;


                        bool resultOfComparingOfRecords = is_validRecord(currRecord_TEL_VID_CONNECT);

                        resultOfComparingOfRecords &= is_changedRecordAfterEditingDataGrid(currRecord_TEL_VID_CONNECT);

                        if (resultOfComparingOfRecords)
                        {
                            btnSave.IsEnabled = true;
                        }*/

            ;
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
                btnDelete.IsEnabled = false;
            }

            this._DBGrid_Editing_Mode = DBGrid_editing_mode.CHANGED_MODE;
            this._iKeySelected = 0;
            this._po_tel_vid_connect = null;
            btnSave.IsEnabled = true;
        }



        private void dgrid__VID_CONNECT_GotFocus(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid;

            if ((dataGrid = (sender as DataGrid)) != null)
            {
                //dataGrid = (DataGrid)sender;

                try
                {
                    var selectedElement = dataGrid.CurrentItem;
                    if ((selectedElement as PO_TEL_VID_CONNECT) != null)
                    {
                        this._iKeySelected = ((PO_TEL_VID_CONNECT)selectedElement).Id;




                        if (this._po_tel_vid_connect != null)
                        {
                            ;
                        }

                        if (this._DBGrid_Editing_Mode == DBGrid_editing_mode.EDITING_MODE)
                        {
                            btnDelete.IsEnabled = false;

                            /**
                             *   to do ..
                             */
                        }
                        else if (this._DBGrid_Editing_Mode == DBGrid_editing_mode.SAVED_MODE ||
                                this._DBGrid_Editing_Mode == DBGrid_editing_mode.CHANGED_MODE
                                )
                        {
                            this._po_tel_vid_connect = (PO_TEL_VID_CONNECT)selectedElement;
                            this._DBGrid_Editing_Mode = DBGrid_editing_mode.PREMODIFY_MODE;
                            btnDelete.IsEnabled = true;

                        }
                        else if (this._DBGrid_Editing_Mode == DBGrid_editing_mode.SEARCHING_MODE)
                        {
                            btn_OK.Content = "Найти далее ..";
                        }

                        FillTextBoxesByRecordValues(this._textFields, (PO_TEL_VID_CONNECT)selectedElement, this._DBGrid_Editing_Mode, _editingModeWithColorMatching);

                    }
                    else
                    {
                        PO_TEL_VID_CONNECT potelvidconnectCandidate = new PO_TEL_VID_CONNECT();

                        var iResult = (DbAppContextProperty.pO_TEL_VID_CONNECTs.Max(rr => rr.Id));

                        potelvidconnectCandidate.Id = iResult + 1;

                        //int iMaxOfID = from DbAppContextProperty

                        this._DBGrid_Editing_Mode = DBGrid_editing_mode.ADDING_MODE;


                        FillTextBoxesByRecordValues(this._textFields, potelvidconnectCandidate, this._DBGrid_Editing_Mode, _editingModeWithColorMatching);

                        btnDelete.IsEnabled = false;
                        this._iKeySelected = 0;
                        //this._is_adding_new_element = true;
                    }
                }
                catch (InvalidCastException ice)
                {

                }
            }

        }




        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {


            PopupSearch.PlacementTarget = btn_Search;


            cmb_LogicOperator12.ItemsSource = OperatorSignLogicStrings.Keys;
            cmb_LogicOperator23.ItemsSource = OperatorSignLogicStrings.Keys;
            cmb_ID_from_filter.ItemsSource = OperatorSignComparisionStrings.Keys;
            //cmb_ID_from_filter_right.ItemsSource = OperatorSignComparisionStrings.Keys;
            cmb_KOD_from_filter.ItemsSource = OperatorSignComparisionStrings.Keys;
            //cmb_KOD_from_filter_right.ItemsSource = OperatorSignComparisionStrings.Keys;
            cmb_Name_from_filter.ItemsSource = OperatorSignComparisionStrings.Keys;
            //cmb_Name_from_filter_right.ItemsSource = OperatorSignComparisionStrings.Keys;
            mainWindowForGrid.IsEnabled = false;
            PopupSearch.IsOpen = true;


        }





        private bool is_changedRecordAfterEditingDataGrid(object recordTarget)
        {
            if (recordTarget == null || this._po_tel_vid_connect == null)
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

                if (this._po_tel_vid_connect.isEmpty() || record_TEL_VID_CONNECT.isEmpty())
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


                    Binding binding = new Binding();

                    binding.Mode = BindingMode.TwoWay;

                    binding.Source = itemsOf_TEL_VID_CONNECT;

                    binding.BindsDirectlyToSource = true;

                    if (this._tel_vid_connection_CollectionViewSource == null)
                    {
                        this._tel_vid_connection_CollectionViewSource = new CollectionViewSource();
                    }

                    this._tel_vid_connection_CollectionViewSource.Source = itemsOf_TEL_VID_CONNECT;

                    //dGrid.BindingGroup

                    dGrid.ItemsSource = this._tel_vid_connection_CollectionViewSource.View;


                    return true;
                }
                else
                {
                    if (this._tel_vid_connection_CollectionViewSource != null)
                    {
                        this._tel_vid_connection_CollectionViewSource = new CollectionViewSource();
                    }
                    this._tel_vid_connection_CollectionViewSource.Source = collection;
                    dGrid.ItemsSource = this._tel_vid_connection_CollectionViewSource.View;

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
                var textBox = (el as TextBox);
                if (textBox != null)
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
                if (dBGrid_Editing_Mode == DBGrid_editing_mode.ADDING_MODE)
                {
                    textBoxes[0].Foreground = Brushes.DarkBlue;
                    textBoxes[1].Foreground = Brushes.DarkBlue;
                    textBoxes[2].Foreground = Brushes.DarkBlue;
                }
                else if (dBGrid_Editing_Mode == DBGrid_editing_mode.CHANGED_MODE)
                {
                    textBoxes[0].Foreground = Brushes.DarkGreen;
                    textBoxes[1].Foreground = Brushes.DarkGreen;
                    textBoxes[2].Foreground = Brushes.DarkGreen;
                }
                else if (dBGrid_Editing_Mode == DBGrid_editing_mode.SEARCHING_MODE)
                {
                    textBoxes[0].Foreground = Brushes.Brown;
                    textBoxes[1].Foreground = Brushes.Brown;
                    textBoxes[2].Foreground = Brushes.Brown;
                }
                else
                {
                    btn_OK.Content = "Ок";

                    textBoxes[0].Foreground = Brushes.Black;
                    textBoxes[1].Foreground = Brushes.Black;
                    textBoxes[2].Foreground = Brushes.Black;
                }

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

        private void btn_Ok_from_popupfilter_Click(object sender, RoutedEventArgs e)
        {



            if (!txtfld_ID_from_filter_left.Text.Equals(string.Empty) ||
                !txtfld_ID_from_filter_right.Text.Equals(string.Empty) ||
                !txtfld_KOD_from_filter_left.Text.Equals(string.Empty) ||
                !txtfld_KOD_from_filter_right.Text.Equals(string.Empty) ||
                !txtfld_Name_from_filter_left.Text.Equals(string.Empty) ||
                !txtfld_Name_from_filter_right.Text.Equals(string.Empty))
            {
                if (!txtfld_ID_from_filter_left.Text.Equals(string.Empty) && txtfld_ID_from_filter_right.Text.Equals(string.Empty))
                {

                    CriteriaOfFilterCollection = MakeCriteriaOfFilterFromTextField(CriteriaOfFilterCollection, txtfld_ID_from_filter_left, cmb_ID_from_filter, cmb_ID_from_filter, 0);

                }
                if (!txtfld_ID_from_filter_right.Text.Equals(string.Empty))
                {

                }
                if (!txtfld_KOD_from_filter_left.Text.Equals(string.Empty) && txtfld_KOD_from_filter_right.Text.Equals(string.Empty))
                {

                    CriteriaOfFilterCollection = MakeCriteriaOfFilterFromTextField(CriteriaOfFilterCollection, txtfld_KOD_from_filter_left, cmb_KOD_from_filter, cmb_LogicOperator12, 1);
                }
                if (!txtfld_KOD_from_filter_right.Text.Equals(string.Empty))
                {

                }
                if (!txtfld_Name_from_filter_left.Text.Equals(string.Empty) && txtfld_Name_from_filter_right.Text.Equals(string.Empty))
                {

                    CriteriaOfFilterCollection = MakeCriteriaOfFilterFromTextField(CriteriaOfFilterCollection, txtfld_Name_from_filter_left, cmb_Name_from_filter, cmb_LogicOperator23, 2);
                }
                if (!txtfld_Name_from_filter_right.Text.Equals(string.Empty))
                {

                }
                /*
                 * 
                 *   
                 * 
                 * 
                 * 
                 */

                




                mainWindowForGrid.IsEnabled = true;
                PopupSearch.IsOpen = false;
            }


            //this._DBGrid_Editing_Mode;


            //this._is_found_PO_TEL_VID_CONNECT

        }





        private void btn_Cancel_from_popupfilter_Click(object sender, RoutedEventArgs e)
        {
            mainWindowForGrid.IsEnabled = true;
            PopupSearch.IsOpen = false;
        }



        /**
         * <summary>
         * 
         * 
         * </summary>
         */
        static private CriteriaOfFilter<PO_TEL_VID_CONNECT> MakeCriteriaOfFilterFromTextField(CriteriaOfFilter<PO_TEL_VID_CONNECT> inputCriteriaOfFilter,
                                                                                               TextBox inputTextBoxOfCriteriaItem,
                                                                                               ComboBox inputCmBoxOfComparisionOperationInCriteria,
                                                                                               ComboBox inputCmBoxOfLogicalOperationInCriteria,
                                                                                               int indxOfFieldIn)
        {
            if (inputCriteriaOfFilter == null)
            {
                inputCriteriaOfFilter = new CriteriaOfFilter<PO_TEL_VID_CONNECT>();
            }

            if (!inputTextBoxOfCriteriaItem.Text.Equals(string.Empty))
            {
                PO_TEL_VID_CONNECT pTELVIDCONNECT = new PO_TEL_VID_CONNECT();

                try
                {
                    if (indxOfFieldIn == 0)
                    {
                        int Id_dirty = -1;
                        bool isParsable = Int32.TryParse(inputTextBoxOfCriteriaItem.Text, out Id_dirty);
                        if (isParsable)
                        {
                            pTELVIDCONNECT.Id = Id_dirty;
                        }
                    }
                    else if (indxOfFieldIn == 1)
                    {
                        pTELVIDCONNECT.KodOfConnect = inputTextBoxOfCriteriaItem.Text;

                    }
                    else if (indxOfFieldIn == 2)
                    {
                        pTELVIDCONNECT.Name = inputTextBoxOfCriteriaItem.Text;
                    }

                    var operatorSignComparision = MakeOperatorSignComparisionEnumFromCombobox(inputCmBoxOfComparisionOperationInCriteria, MainWindow.OperatorSignComparisionStrings);
                    var operatorSignLogic = MakeOperatorSignLogicComparisionEnumFromCombobox(inputCmBoxOfLogicalOperationInCriteria, MainWindow.OperatorSignLogicStrings);
                    var oneCriteriaOfFilterChainLink = new CriteriaOfFilterChainLink<PO_TEL_VID_CONNECT>();
                    oneCriteriaOfFilterChainLink.ItemOfCriteria = pTELVIDCONNECT;
                    oneCriteriaOfFilterChainLink.OperatorComparision = operatorSignComparision;
                    oneCriteriaOfFilterChainLink.OperatorLogic = operatorSignLogic;
                    inputCriteriaOfFilter.Add(oneCriteriaOfFilterChainLink, MainWindow.MapComparisioOperatorToComparisionPredicate[operatorSignComparision]);
                }
                catch (FormatException fex)
                {
                    Console.WriteLine($" {fex.Message} ");
                    Console.WriteLine($" {fex.StackTrace} ");
                    Console.WriteLine($" {fex.Source} ");
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine($" {nre.HResult} ");
                    Console.WriteLine($" {nre.Message} ");
                    Console.WriteLine($" {nre.StackTrace} ");
                    Console.WriteLine($" {nre.Source} ");
                }

            }


            return inputCriteriaOfFilter;
        }


        /**
         * <summary>
         * 
         * 
         * </summary>
         */
        static private OperatorSignComparision MakeOperatorSignComparisionEnumFromCombobox(ComboBox inputCmBoxOfComparisionOperationInCriteria, IDictionary<string, OperatorSignComparision> operatorSignComparisionStringsDictionary)
        {
            if (operatorSignComparisionStringsDictionary.ContainsKey(inputCmBoxOfComparisionOperationInCriteria.Text))
            {
                return operatorSignComparisionStringsDictionary[inputCmBoxOfComparisionOperationInCriteria.Text];
            }
            return OperatorSignComparision._REGEX_;
        }


        /**
         * <summary>
         * 
         * 
         * </summary>
         */
        static private OperatorSignLogic MakeOperatorSignLogicComparisionEnumFromCombobox(ComboBox inputCmBoxOfComparisionOperationInCriteria, IDictionary<string, OperatorSignLogic> operatorSignLogicComparisionStringsDictionary)
        {
            if (operatorSignLogicComparisionStringsDictionary.ContainsKey(inputCmBoxOfComparisionOperationInCriteria.Text))
            {
                return operatorSignLogicComparisionStringsDictionary[inputCmBoxOfComparisionOperationInCriteria.Text];
            }
            return OperatorSignLogic._NIL_;
        }


        static CriteriaOfFilter<PO_TEL_VID_CONNECT> PrepareCollectionOfComparisionCriteria(IEnumerable<CriteriaOfFilterChainLink<PO_TEL_VID_CONNECT>> criteriaOfFilterCollection)
        {
            CriteriaOfFilter<PO_TEL_VID_CONNECT> collectionOfCriteria = new CriteriaOfFilter<PO_TEL_VID_CONNECT>();


            if (criteriaOfFilterCollection != null)
            {
                foreach (var oneCriteriaOfFilter in criteriaOfFilterCollection)
                {
                    collectionOfCriteria.Add(oneCriteriaOfFilter, MapComparisioOperatorToComparisionPredicate[oneCriteriaOfFilter.OperatorComparision]);
                }
            }

            return collectionOfCriteria;
        }

        private void cmb_ID_from_filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ; ; ; ; ; ; ; ; ;
        }

        private void cmb_KOD_from_filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ; ; ; ; ; ; ; ; ;
        }

        private void cmb_Name_from_filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ; ; ; ; ; ; ; ; ;
        }


        static Predicate<object> settingPredicateOf_CollViewSourceFilterringFromCriteriasOfFilter<T>( DbContext dbContext, CriteriaOfFilter<T> criteriaOfFilter, CollectionViewSource collectionViewSource = null)
        {
            if (collectionViewSource == null)
            {
                collectionViewSource = new CollectionViewSource();
            }

            DbAppContext dbAppContext = dbContext as DbAppContext;
            if(dbAppContext != null)
            {
                collectionViewSource.Source = dbAppContext.pO_TEL_VID_CONNECTs.Local.ToBindingList();
            }

            if (criteriaOfFilter != null)
            {
                return criteriaOfFilter.EvalOnAllCriteriaByObj;
            }
            return (o)=> false;
        }


        /*        private void cmb_ID_from_filter_Selected(object sender, RoutedEventArgs e)
                {

                    if(cmb_ID_from_filter.Text.Equals("< .. >") || cmb_ID_from_filter.Text.Equals("<= .. >=") || cmb_ID_from_filter.Text.Equals("< .. >=") || cmb_ID_from_filter.Text.Equals("<= .. >"))
                    {
                        ;
                    }
                }
        */

    }
}
