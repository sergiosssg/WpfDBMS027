using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{
    public class CriteriaOfFilterChainLink<T> : ICriteriaOfFilterChainLink<T>
    {
        private T  _oneItemOfCriteria;
        private OperatorSignComparision _operatorSignComparision;
        private OperatorSignLogic  _operatorSignLogic;

        public CriteriaOfFilterChainLink()
        {
            this._oneItemOfCriteria = default(T);
            this._operatorSignComparision = OperatorSignComparision._REGEX_;
            this._operatorSignLogic = OperatorSignLogic._NIL_;
        }

        public CriteriaOfFilterChainLink(T el)
        {
            this._oneItemOfCriteria = el;
            this._operatorSignComparision = OperatorSignComparision._REGEX_;
            this._operatorSignLogic = OperatorSignLogic._NIL_;
        }

        public CriteriaOfFilterChainLink(T el, OperatorSignComparision operatorSignComparision)
        {
            this._oneItemOfCriteria = el;
            this._operatorSignComparision = operatorSignComparision;
            this._operatorSignLogic = OperatorSignLogic._NIL_;
        }

        public CriteriaOfFilterChainLink(T el, OperatorSignComparision operatorSignComparision, OperatorSignLogic operatorSignLogic)
        {
            this._oneItemOfCriteria = el;
            this._operatorSignComparision = operatorSignComparision;
            this._operatorSignLogic = operatorSignLogic;
        }

        public T ItemOfCriteria
        {
            get
            {
                return this._oneItemOfCriteria;
            }
            set
            {
                this._oneItemOfCriteria = value;
            }
        }

        public OperatorSignComparision OperatorComparision
        {
            get
            {
                return this._operatorSignComparision;
            }
            set
            {
                this._operatorSignComparision = value;
            }
        }

        public OperatorSignLogic OperatorLogic
        {
            get
            {
                return this._operatorSignLogic;
            }
            set
            {
                this._operatorSignLogic = value;
            }
        }

    }
}
