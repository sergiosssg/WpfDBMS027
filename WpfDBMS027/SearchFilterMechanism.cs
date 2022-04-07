using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{

    public delegate bool DelegateOperatorForComparision<T>(T arg1, T arg2, OperatorSignComparision operatorLogic);


    public delegate bool DelegateOperatorForComparisionWithTuples<T>((T, T) arg4compating, (T, T) argSample, OperatorSignComparision operatorLogic);


    public enum OperatorSignComparision
    {
        _EQ_, _NE_, _GT_, _LT_, _GE_, _LE_, _BETWEEN_STRICT_, _BETWEEN_STRICT_LEFT_, _BETWEEN_STRICT_RIGHT_, _BETWEEN_NO_STRICT_, _REGEX_
    }


    public enum OperatorSignLogic
    {
        _AND_, _OR_, _AND_NOT_, _OR_NOT_, _NIL_
    }



    /*
        public interface IOperatorForComparision<T>
        {

            public bool ComparisionSimpleOperator(T arg, OperatorSignLogic operatorLogic, IOperatorPredicateForComparision<T> operatorPredicateForComparision);

        }

    */



    public interface ICriteriaOfFilterChainLink<T>
    {

    }

    public interface IDBAppContext<T, TDbContext>
    {
        ICollection<T> GetLINQQueryBydbContext(TDbContext dbContext);

        ICollection<T> GetLINQQueryByQueryable(IQueryable<T> queryable);
    }


    public class CriteriaOfFilterChainLink<T> : ICriteriaOfFilterChainLink<T>
    {
        protected T _oneItemOfCriteriaLeft;
        protected OperatorSignComparision _operatorSignComparisioLeftn;
        protected OperatorSignLogic _operatorSignLogic;

        public CriteriaOfFilterChainLink()
        {
            this._oneItemOfCriteriaLeft = default(T);
            this._operatorSignComparisioLeftn = OperatorSignComparision._REGEX_;
            this._operatorSignLogic = OperatorSignLogic._NIL_;
        }

        public CriteriaOfFilterChainLink(T el)
        {
            this._oneItemOfCriteriaLeft = el;
            this._operatorSignComparisioLeftn = OperatorSignComparision._REGEX_;
            this._operatorSignLogic = OperatorSignLogic._NIL_;
        }

        public CriteriaOfFilterChainLink(T el, OperatorSignComparision operatorSignComparision)
        {
            this._oneItemOfCriteriaLeft = el;
            this._operatorSignComparisioLeftn = operatorSignComparision;
            this._operatorSignLogic = OperatorSignLogic._NIL_;
        }

        public CriteriaOfFilterChainLink(T el, OperatorSignComparision operatorSignComparision, OperatorSignLogic operatorSignLogic)
        {
            this._oneItemOfCriteriaLeft = el;
            this._operatorSignComparisioLeftn = operatorSignComparision;
            this._operatorSignLogic = operatorSignLogic;
        }

        public T ItemOfCriteriaLeftOnly
        {
            get
            {
                return this._oneItemOfCriteriaLeft;
            }
            set
            {
                this._oneItemOfCriteriaLeft = value;
            }
        }

        public OperatorSignComparision OperatorComparisionLeftOnly
        {
            get
            {
                return this._operatorSignComparisioLeftn;
            }
            set
            {
                this._operatorSignComparisioLeftn = value;
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




    public class PaarCriteriaOfFilterChainLink<T> : CriteriaOfFilterChainLink<T>
    {

    }




    public class CriteriaOfFilter<T> : IOperatorPredicateForComparision<T>
    {
        private IDictionary<CriteriaOfFilterChainLink<T>, DelegateOperatorForComparision<T>> _operatorComparisionDelegate;

        public CriteriaOfFilter()
        {
            this._operatorComparisionDelegate = new Dictionary<CriteriaOfFilterChainLink<T>, DelegateOperatorForComparision<T>>();
        }

        public void Add(CriteriaOfFilterChainLink<T> oneCriteriaChain, DelegateOperatorForComparision<T> operatorPredicateComparision)
        {
            this._operatorComparisionDelegate.Add(oneCriteriaChain, operatorPredicateComparision);
        }

        public bool EvalOnAllCriteria(T arg)
        {
            bool resultOfEvaluation = false;
            var criteriaOfFilterArray = this._operatorComparisionDelegate.Keys;

            int iIndx = 0;


            foreach (var criteriaChain in criteriaOfFilterArray)
            {
                var argument2 = criteriaChain.ItemOfCriteriaLeftOnly;
                var operatorComparision = criteriaChain.OperatorComparisionLeftOnly;
                var operatorLogic = criteriaChain.OperatorLogic;

                var operatorOfComparision = this._operatorComparisionDelegate[criteriaChain];

                if (iIndx++ == 0)
                {
                    bool boolResult = operatorOfComparision(arg, argument2, operatorComparision);
                    resultOfEvaluation = boolResult;
                }
                else if (operatorLogic == OperatorSignLogic._AND_)
                {
                    bool boolResult = operatorOfComparision(arg, argument2, operatorComparision);
                    resultOfEvaluation &= boolResult;
                }
                else if (operatorLogic == OperatorSignLogic._OR_)
                {
                    bool boolResult = operatorOfComparision(arg, argument2, operatorComparision);
                    resultOfEvaluation |= boolResult;
                }
                else if (operatorLogic == OperatorSignLogic._AND_NOT_)
                {
                    bool boolResult = !operatorOfComparision(arg, argument2, operatorComparision);
                    resultOfEvaluation &= boolResult;
                }
                else if (operatorLogic == OperatorSignLogic._OR_NOT_)
                {
                    bool boolResult = !operatorOfComparision(arg, argument2, operatorComparision);
                    resultOfEvaluation |= boolResult;
                }
                else if (operatorLogic == OperatorSignLogic._NIL_)
                {
                    continue;
                }
                ;
            }

            return resultOfEvaluation;
        }

        public bool EvalOnParticularCriteria(T arg, IEnumerable<CriteriaOfFilterChainLink<T>> criteriasOfFilter)
        {
            bool resultOfEvaluation = false;
            var criteriaOfFilterArray = this._operatorComparisionDelegate.Keys;

            int iIndx = 0;

            foreach (var criteriaChain in criteriasOfFilter)
            {
                var argument2 = criteriaChain.ItemOfCriteriaLeftOnly;
                var operatorComparision = criteriaChain.OperatorComparisionLeftOnly;
                var operatorLogic = criteriaChain.OperatorLogic;

                var operatorOfComparision = this._operatorComparisionDelegate[criteriaChain];

                if (iIndx++ == 0)
                {
                    resultOfEvaluation = operatorOfComparision(arg, argument2, operatorComparision);
                }
                else if (operatorLogic == OperatorSignLogic._AND_)
                {
                    resultOfEvaluation &= operatorOfComparision(arg, argument2, operatorComparision);
                }
                else if (operatorLogic == OperatorSignLogic._OR_)
                {
                    resultOfEvaluation |= operatorOfComparision(arg, argument2, operatorComparision);
                }
                else if (operatorLogic == OperatorSignLogic._AND_NOT_)
                {
                    resultOfEvaluation &= !operatorOfComparision(arg, argument2, operatorComparision);
                }
                else if (operatorLogic == OperatorSignLogic._OR_NOT_)
                {
                    resultOfEvaluation |= !operatorOfComparision(arg, argument2, operatorComparision);
                }
                else if (operatorLogic == OperatorSignLogic._NIL_)
                {
                    continue;
                }
                ;
            }


            return resultOfEvaluation;
        }

        public bool EvalOnAllCriteriaByObj(Object argObj)
        {
            if (argObj.GetType() == typeof(T))
            {
                T tArgument = (T)argObj;
                return this.EvalOnAllCriteria((T)argObj);
            }
            return false;
        }

    }


    public abstract class CriteriaOfFilterLINQ<T, D> : IOperatorPredicateForComparision<T>, IDBAppContext<T, D>
    {
        protected ICollection<CriteriaOfFilterChainLink<T>> _filterCriterias;

        public CriteriaOfFilterLINQ()
        {
            this._filterCriterias = new List<CriteriaOfFilterChainLink<T>>();
        }





        public void Add(CriteriaOfFilterChainLink<T> oneCriteriaChain)
        {
            this._filterCriterias.Add(oneCriteriaChain);
        }

        public int Amount
        {
            get
            {
                return _filterCriterias.Count;
            }
        }

        abstract public ICollection<T> GetLINQQueryBydbContext(D dbContext);


        abstract public ICollection<T> GetLINQQueryByQueryable(IQueryable<T> queryable);

    }
}





