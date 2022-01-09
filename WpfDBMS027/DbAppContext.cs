using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    public class DbAppContext : DbContext
    {

        public DbSet<PO_TEL_VID_CONNECT> pO_TEL_VID_CONNECTs { get; set; }





        public DbAppContext() // base(@"Data Source=localhost\\SQLExpress;Initial Catalog=sampd_cexs;Integrated Security=True") //base(@"initial catalog=C:\SSG\PROJECTs\TELET\DB4TELEFONE\sampd_cexs.fdb;data source=localhost;user id=sysdba;password=masterkey;pooling=True")
        {
            ;
        }



        public DbAppContext(DbContextOptions<DbAppContext> options)  : base( options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\\SQLExpress;Initial Catalog=sampd_cexs;Integrated Security=True");
            }

            ;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PO_TEL_VID_CONNECT>().HasMany(c => (ICollection<PO_TEL_VID_CONNECT>)c.pO_TEL_OPERATORs);
            ;
        }


    }
}
