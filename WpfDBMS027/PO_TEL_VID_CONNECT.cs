﻿using System;
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



        public bool CompareByDefault(object obj)
        {
            if(obj == null || obj.GetType() != typeof(PO_TEL_VID_CONNECT))
            {
                return false;
            }

            PO_TEL_VID_CONNECT obj_TEL_VID_CONNECT = (PO_TEL_VID_CONNECT)obj;

            if (this.isEmpty() || obj_TEL_VID_CONNECT.isEmpty())
            {
                return false;
            }
            else if (this.Id == obj_TEL_VID_CONNECT.Id && this.KodOfConnect == string.Empty && this.Name == string.Empty)
            {
                return true;
            }
            else if (this.Id == 0 && this.KodOfConnect.Equals(obj_TEL_VID_CONNECT.KodOfConnect) && this.Name == string.Empty)
            {
                return true;
            }
            else if (this.Id == 0 && this.KodOfConnect == string.Empty && this.Name.Equals(obj_TEL_VID_CONNECT.Name))
            {
                return true;
            }
            return false;
        }


        public bool isEmpty()
        {
            if (this.Id == 0 && this.KodOfConnect == string.Empty && this.Name == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(PO_TEL_VID_CONNECT))
            {
                return false;
            }
            PO_TEL_VID_CONNECT tObj = (PO_TEL_VID_CONNECT)obj;
            if (this.isEmpty() || tObj.isEmpty())
            {
                return false;
            }
            if (this.Id == tObj.Id && this.KodOfConnect.Equals(tObj.KodOfConnect) && this.Name.Equals(tObj.Name))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
