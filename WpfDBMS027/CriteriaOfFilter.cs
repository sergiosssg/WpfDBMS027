using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    public class CriteriaOfFilter
    {
        public CriteriaOfFilter()
        {
            this._ID_leftBoundary = 0;
            this._ID_rightBoundary = null;
            this._KodOfConnect_leftBoundary = string.Empty;
            this._KodOfConnect_rightBoundary = string.Empty;
            this._Name_leftBoundary = string.Empty;
            this._Name_rightBoundary = string.Empty;
            this._operatorSignComparision_for_ID = OperatorSignComparision._EQ_;
            this._operatorSignComparision_for_KodOfConnect = OperatorSignComparision._EQ_;
            this._operatorSignComparision_for_Name = OperatorSignComparision._EQ_;
            this._operatorSignLogic__ID__KodOfConnect = OperatorSignLogic._AND_;
            this._operatorSignLogic__KodOfConnect__Name = OperatorSignLogic._AND_;
        }

        private int? _ID_leftBoundary;
        private int? _ID_rightBoundary;

        private string _KodOfConnect_leftBoundary;
        private string _KodOfConnect_rightBoundary;

        private string _Name_leftBoundary;
        private string _Name_rightBoundary;


        private OperatorSignComparision _operatorSignComparision_for_ID;
        private OperatorSignComparision _operatorSignComparision_for_KodOfConnect;
        private OperatorSignComparision _operatorSignComparision_for_Name;

        private OperatorSignLogic _operatorSignLogic__ID__KodOfConnect;
        private OperatorSignLogic _operatorSignLogic__KodOfConnect__Name;


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


        public OperatorSignComparision OperatorSignComparision_for_ID
        {
            get
            {
                return this._operatorSignComparision_for_ID;
            }
            set
            {
                this._operatorSignComparision_for_ID = value;
            }
        }

        public OperatorSignComparision OperatorSignComparision_for_KodOfConnect
        {
            get
            {
                return this._operatorSignComparision_for_KodOfConnect;
            }
            set
            {
                this._operatorSignComparision_for_KodOfConnect = value;
            }
        }

        public OperatorSignComparision OperatorSignComparision_for_Name
        {
            get
            {
                return this._operatorSignComparision_for_Name;
            }
            set
            {
                this._operatorSignComparision_for_Name = value;
            }
        }

        public OperatorSignLogic OperatorSignLogic__ID__KodOfConnect
        {
            get
            {
                return this._operatorSignLogic__ID__KodOfConnect;
            }
            set
            {
                this._operatorSignLogic__ID__KodOfConnect = value;
            }
        }

        public OperatorSignLogic OperatorSignLogic__KodOfConnect__Name
        {
            get
            {
                return this._operatorSignLogic__KodOfConnect__Name;
            }
            set
            {
                this._operatorSignLogic__KodOfConnect__Name = value;
            }
        }
    }
}
