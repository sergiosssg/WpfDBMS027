using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    public class CriteriaOfFilter
    {
        private int? _ID_leftBoundary;
        private int? _ID_rightBoundary;

        private string _KodOfConnect_leftBoundary;
        private string _KodOfConnect_rightBoundary;

        private string _Name_leftBoundary;
        private string _Name_rightBoundary;


        public int? ID_leftBoundary
        {
            get 
            {
                return this._ID_leftBoundary;
            }
            set 
            {
                this._ID_leftBoundary = value;
            }
        }

        public int? ID_rightBoundary
        {
            get
            {
                return this._ID_rightBoundary;
            }
            set
            {
                this._ID_rightBoundary = value;
            }
        }

        public string KodOfConnect_leftBoundary
        {
            get
            {
                return this._KodOfConnect_leftBoundary;
            }
            set
            {
                this._KodOfConnect_leftBoundary = value;
            }
        }

        public string KodOfConnect_rightBoundary
        {
            get
            {
                return this._KodOfConnect_rightBoundary;
            }
            set
            {
                this._KodOfConnect_rightBoundary = value;
            }
        }

        public string Name_leftBoundary
        {
            get
            {
                return this._Name_leftBoundary;
            }
            set
            {
                this._Name_leftBoundary = value;
            }
        }

        public string Name_rightBoundary
        {
            get
            {
                return this._Name_rightBoundary;
            }
            set
            {
                this._Name_rightBoundary = value;
            }
        }


    }
}
