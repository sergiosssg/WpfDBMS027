﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    public enum OperatorSignComparision
    {
        _EQ_, _NE_, _GT_, _LT_, _GE_, _LE_, _BETWEEN_STRICT_, _BETWEEN_STRICT_LEFT_, _BETWEEN_STRICT_RIGHT_, _BETWEEN_NO_STRICT_
    }

    public enum OperatorSignLogic
    {
        _AND_, _OR_, _NOT_
    }




    public interface OperatorForComparision
    {


        public delegate bool comparisionSimpleDelegate(object arg1, object arg2, object arg3, OperatorSignComparision operatorSigh, OperatorSignLogic? operatorSignLogic, comparisionSimpleDelegate comparisionSimpleDelegate);

    }
}
