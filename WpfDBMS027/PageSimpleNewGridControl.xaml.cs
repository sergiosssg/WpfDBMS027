
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для PageSimpleNewGridControl.xaml
    /// </summary>
    public partial class PageSimpleNewGridControl : Page
    {
        private DataBaseFacilities _dataBaseFacilities;

        private CollectionViewSource _tel_vid_connection_CollectionViewSource;

        public DbSet<PO_TEL_VID_CONNECT> TEL_VID_CONNECTs;

        public DbAppContext DbAppContextProperty { get; }

        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }



        public PageSimpleNewGridControl()
        {
            this._dataBaseFacilities = new DataBaseFacilities();

            DbAppContextProperty = this._dataBaseFacilities.DbAppContextProperty;

            DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();

            this.TEL_VID_CONNECTs = DbAppContextProperty.pO_TEL_VID_CONNECTs;

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();

            this.TEL_VID_CONNECTs = DbAppContextProperty.pO_TEL_VID_CONNECTs;

            //bool resultOfRefreshing = RefreshListviewWithCollection(c1datagrid, DbAppContextProperty);

        }

        private bool RefreshListviewWithCollection(Control dataViewControl, DbContext dbContext, ICollection<PO_TEL_VID_CONNECT> collection = null)
        {
            if (dataViewControl == null) return false;

/*            if (dataViewControl.GetType() == typeof(C1DataGrid))
            {
                C1DataGrid datagrid = (C1DataGrid)dataViewControl;

                var tTTT_of_datagrid = datagrid.GetType();

                var sTTTT = tTTT_of_datagrid.Name;


                if (collection == null && dbContext.GetType() == typeof(DbAppContext))
                {

                    var dbAppContext = (DbAppContext)dbContext;
                    var itemsOf_TEL_VID_CONNECT = dbAppContext.pO_TEL_VID_CONNECTs.Local.ToBindingList();


                    Binding binding = new Binding();

                    binding.Mode = BindingMode.TwoWay;

                    binding.Source = itemsOf_TEL_VID_CONNECT.ToList<PO_TEL_VID_CONNECT>();

                    binding.BindsDirectlyToSource = true;


                    if (this._tel_vid_connection_CollectionViewSource == null)
                    {
                        this._tel_vid_connection_CollectionViewSource = new CollectionViewSource();
                    }
                    this._tel_vid_connection_CollectionViewSource.Source = itemsOf_TEL_VID_CONNECT.ToList<PO_TEL_VID_CONNECT>();

                    datagrid.ItemsSource = this._tel_vid_connection_CollectionViewSource.View;

                    return true;

                }
            }*/

            return false;
        }

    }
}
