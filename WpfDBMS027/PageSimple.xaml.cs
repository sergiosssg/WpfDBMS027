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
    /// Логика взаимодействия для PageSimple.xaml
    /// </summary>
    public partial class PageSimple : Page
    {


        public DbAppContext DbAppContextProperty { get; }

        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }


        public PageSimple()
        {

            OptionsOfDbContext = new DbContextOptionsBuilder<DbAppContext>().UseSqlServer(GetConnectionString()).Options;

            DbAppContextProperty = new DbAppContext(OptionsOfDbContext);

            InitializeComponent();
        }



        private static string GetConnectionString()
        {
            DbConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            //builder["Data Source"] = "localhost";
            builder["Data Source"] = @"localhost\SQLExpress";

            builder["Database"] = "sampd_cexs";

            builder["integrated Security"] = "true";

            return builder.ConnectionString;
        }

    }
}
