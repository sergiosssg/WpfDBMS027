using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfDBMS027
{

    public class CriteriaOfFilterLINQ4POTELVIDCONNECT : CriteriaOfFilterLINQ<PO_TEL_VID_CONNECT, DbAppContext>
    {

        /*
        protected ICollection<CriteriaOfFilterChainLink<T>> _filterCriterias;

        */

        private DbAppContext _dbContext;
        private IQueryable<PO_TEL_VID_CONNECT> _queryableOfT;


        public CriteriaOfFilterLINQ4POTELVIDCONNECT() : base()
        {

        }


        public CriteriaOfFilterLINQ4POTELVIDCONNECT(IQueryable<PO_TEL_VID_CONNECT> queryable) : base()
        {
            this._queryableOfT = queryable;
            this._queryableOfT = null;
        }


        public CriteriaOfFilterLINQ4POTELVIDCONNECT(DbAppContext dbContext) : base()
        {
            this._queryableOfT = null;
            this._dbContext = dbContext;
        }


        public IQueryable<PO_TEL_VID_CONNECT> Queryable
        {
            set => this._queryableOfT = value;

            get => this._queryableOfT;
        }


        public DbAppContext DBContextProperty
        {
            set => this._dbContext = value;

            get => this._dbContext;
        }


        public override IQueryable<PO_TEL_VID_CONNECT> GetLINQQueryBydbContext(DbAppContext dbContext)
        {
            IQueryable<PO_TEL_VID_CONNECT> returnedQueryable = null;
            if (base._filterCriterias.Count > 0)
            {
                int i = 0;
                foreach(CriteriaOfFilterChainLink<PO_TEL_VID_CONNECT> oneCriteriaFilterChain in base._filterCriterias)
                {
                    if(i++ == 0)  // first step in loop
                    {
                        if(oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._EQ_)  // "=="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id == oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty( oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) 
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty( oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteria.Name)
                                                    select p;
                            }
                        }
                        else if(oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._NE_)  // "!="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id != oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where !p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect)
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where !p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteria.Name)
                                                    select p;
                            }
                        }
                        else if(oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._GT_)  // ">"
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id > oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where   string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) > 0
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) > 0
                                                    select p;
                            }
                        }
                        else if(oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._LT_)  // "<"
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id < oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) < 0
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) < 0
                                                    select p;
                            }
                        }
                        else if(oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._GE_)   // ">="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id >= oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) >= 0
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) >= 0
                                                    select p;
                            }
                        }
                        else if(oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._LE_)   // "<="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id <= oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) <= 0
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {

                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) <= 0
                                                    select p;
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._REGEX_)  //  Grep
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                            {
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id == oneCriteriaFilterChain.ItemOfCriteria.Id
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                            {
                                string sPattern = oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect;

                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where Regex.IsMatch( p.KodOfConnect, sPattern)
                                                    select p;
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                            {
                                string sPattern = oneCriteriaFilterChain.ItemOfCriteria.Name;
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where  Regex.IsMatch( p.Name, sPattern)
                                                    select p;
                            }
                        }
                    }
                    else
                    {
                        if (oneCriteriaFilterChain.OperatorLogic == OperatorSignLogic._AND_ && returnedQueryable != null)
                        {
                            if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._EQ_)  // "=="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id == oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect)
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteria.Name)
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._NE_)  // "!="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id != oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where !p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect)
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where !p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteria.Name)
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._GT_)  // ">"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id > oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) > 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) > 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._LT_)  // "<"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id < oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) < 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) < 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._GE_)   // ">="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id >= oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) >= 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) >= 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._LE_)   // "<="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id <= oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) <= 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {

                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) <= 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._REGEX_)  //  Grep
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id == oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect;

                                    returnedQueryable = from p in returnedQueryable
                                                        where Regex.IsMatch(p.KodOfConnect, sPattern)
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteria.Name;
                                    returnedQueryable = from p in returnedQueryable
                                                        where Regex.IsMatch(p.Name, sPattern)
                                                        select p;
                                }
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorLogic == OperatorSignLogic._AND_NOT_ && returnedQueryable != null)
                        {
                            if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._EQ_)  // "=="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id != oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        !where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect)
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        !where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteria.Name)
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._NE_)  // "!="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id == oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect)
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteria.Name)
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._GT_)  // ">"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id <= oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) <= 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) <= 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._LT_)  // "<"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id >= oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) >= 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) >= 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._GE_)   // ">="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id < oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) < 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) < 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._LE_)   // "<="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id > oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect) > 0
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {

                                    returnedQueryable = from p in returnedQueryable
                                                        where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteria.Name) > 0
                                                        select p;
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparision == OperatorSignComparision._REGEX_)  //  Grep
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteria.Id > 0)
                                {
                                    returnedQueryable = from p in returnedQueryable
                                                        where p.Id != oneCriteriaFilterChain.ItemOfCriteria.Id
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteria.KodOfConnect;

                                    returnedQueryable = from p in returnedQueryable
                                                        where !Regex.IsMatch(p.KodOfConnect, sPattern)
                                                        select p;
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteria.Name))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteria.Name;
                                    returnedQueryable = from p in returnedQueryable
                                                        where !Regex.IsMatch(p.Name, sPattern)
                                                        select p;
                                }
                            }
                        }

                    }
                }

            }

            throw new NotImplementedException();
        }



        public override IQueryable<PO_TEL_VID_CONNECT> GetLINQQueryByQueryable(IQueryable<PO_TEL_VID_CONNECT> queryable)
        {
            throw new NotImplementedException();
        }

    }
}
