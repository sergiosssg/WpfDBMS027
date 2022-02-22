using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{



    public interface IOperatorPredicateForComparision<T>
    {

        public delegate bool OperatorForComparision(T arg, OperatorSignLogic operatorLogic, OperatorForComparision operatorForComparision);
    }




}
