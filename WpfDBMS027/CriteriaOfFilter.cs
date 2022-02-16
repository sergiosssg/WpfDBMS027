using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    public class CriteriaOfFilter<T>
    {

        private ICollection<ICriteriaOfFilterChainLink<T>>  _criteriaOfFilterCollection;


        public CriteriaOfFilter() => this._criteriaOfFilterCollection = new List<ICriteriaOfFilterChainLink<T>>();





    }
}
