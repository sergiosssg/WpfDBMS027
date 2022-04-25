using Microsoft.EntityFrameworkCore;
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
            InitializeComponent();
        }
    }
}
