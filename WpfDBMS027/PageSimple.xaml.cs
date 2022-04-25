﻿using Microsoft.Data.SqlClient;
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

        private CollectionViewSource _tel_vid_connection_CollectionViewSource;

        public DbSet<PO_TEL_VID_CONNECT> TEL_VID_CONNECTs;

        public DbAppContext DbAppContextProperty { get; }

        public DbContextOptions<DbAppContext> OptionsOfDbContext { get; }


        public PageSimple()
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



        /**
        *  <summary
        *  
        *  this function performs all work with displaying data in Control
        *  
        */
        private bool RefreshListviewWithCollection(Control dataViewControl, DbContext dbContext, ICollection<PO_TEL_VID_CONNECT> collection = null)
        {
            if (dataViewControl == null) return false;
            if (dataViewControl.GetType() == typeof(ListView))
            {
                ListView lstView = (ListView)dataViewControl;

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




                    //lstView.BindingGroup

                    foreach(var oneTO in this._tel_vid_connection_CollectionViewSource.View)
                    {
                        var tTT = oneTO.GetType().Name;
                    }


                    lstView.ItemsSource = this._tel_vid_connection_CollectionViewSource.View;

                    

                    return true;
                }
                else
                {

                    /*
                                        if (this._tel_vid_connection_CollectionViewSource == null)
                                        {
                                            this._tel_vid_connection_CollectionViewSource = new CollectionViewSource();
                                        }
                                        this._tel_vid_connection_CollectionViewSource.Source = collection;
                                        lstView.ItemsSource = this._tel_vid_connection_CollectionViewSource.View;
                    */


                    return true;
                }
            }
            return false;
        }

        private void PageSimpleInstance1_Loaded(object sender, RoutedEventArgs e)
        {
            DbAppContextProperty.pO_TEL_VID_CONNECTs.Load();

            this.TEL_VID_CONNECTs = DbAppContextProperty.pO_TEL_VID_CONNECTs;

            bool resultOfRefreshing = RefreshListviewWithCollection( lst4POvidtelconnect, DbAppContextProperty);

        }
    }
}