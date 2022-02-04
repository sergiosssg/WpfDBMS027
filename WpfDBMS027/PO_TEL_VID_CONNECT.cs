using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    [Table("TEL_VID_CONNECT")]
    public class PO_TEL_VID_CONNECT
    {

        public PO_TEL_VID_CONNECT()
        {
            this.Id = 0;
            this.KodOfConnect = string.Empty;
            this.Name = string.Empty;

        }


        [Required]
        [Key]
        [Column("ID_CONNECT")]
        public int Id
        {   //   ID_CONNECT   (PK)
            get;
            set;
        }


        [Column("KOD_CONNECT")]
        [MaxLength(1)]
        public string KodOfConnect
        {    //   KOD_CONNECT   C[1]
            get;
            set;
        }


        [Column("NAME_CONNECT")]
        [MaxLength(50)]
        public string Name
        {    //   NAME_CONNECT  V[50]
            get;
            set;
        }



    }
}
