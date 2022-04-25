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
    /// Логика взаимодействия для PageSimpleVz.xaml
    /// </summary>
    public partial class PageSimpleVz : Page
    {


        private CollectionViewSource _tel_vid_connection_CollectionViewSource;

        public DbSet<PO_TEL_VID_CONNECT> TEL_VID_CONNECTs;

        public DbAppContext DbAppContextProperty { get; }

        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }


        public PageSimpleVz()
        {
            OptionsOfDbContext = new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

            DbAppContextProperty = new DbAppContext(OptionsOfDbContext);

            DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();

            this.TEL_VID_CONNECTs = DbAppContextProperty.pO_TEL_VID_CONNECTs;

            InitializeComponent();
        }


        private static string GetConnectionString()
        {
            DbConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder["Data Source"] = "localhost";

            builder["Database"] = "sampd_cexs";

            builder["integrated Security"] = "true";

            return builder.ConnectionString;
        }




        private bool RefreshListviewWithCollection(Control dataViewControl, DbContext dbContext, ICollection<PO_TEL_VID_CONNECT> collection = null)
        {
            throw new NotImplementedException();
        }

    }
}
