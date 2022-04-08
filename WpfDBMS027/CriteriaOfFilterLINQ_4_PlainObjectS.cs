using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
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

        protected DbAppContext _dbContext;
        protected IQueryable<PO_TEL_VID_CONNECT> _queryableOfT;


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


        public override ICollection<PO_TEL_VID_CONNECT> GetLINQQueryBydbContext(DbAppContext dbContext)
        {
            ICollection<PO_TEL_VID_CONNECT> returnedQueryable = null;
            if (base._filterCriterias.Count > 0)
            {
                int i = 0;
                foreach (CriteriaOfFilterChainLink<PO_TEL_VID_CONNECT> oneCriteriaFilterChain in base._filterCriterias)
                {
                    if (i++ == 0)  // first step in loop
                    {
                        if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._EQ_)  // "=="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id == oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                    select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect)
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name)
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._NE_)  // "!="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.Id != oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where !p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect)
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where !p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name)
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._GT_)  // ">"
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.Id > oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) > 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) > 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._LT_)  // "<"
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.Id < oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) < 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) < 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._GE_)   // ">="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.Id >= oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) >= 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) >= 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._LE_)   // "<="
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where p.Id <= oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) <= 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                             where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) <= 0
                                             select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._REGEX_)  //  Grep
                        {
                            if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                            {
                                var result = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where p.Id == oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                    select p;
                                returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                            {
                                string sPattern = @"" + oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect;

                                var result = dbContext.pO_TEL_VID_CONNECTs.Local.Where<PO_TEL_VID_CONNECT>((p) => Regex.IsMatch(p.KodOfConnect, sPattern)).ToList<PO_TEL_VID_CONNECT>();

                                RegexStringValidator myRegexValidator = null;

                                try
                                {
                                    if (sPattern.Length == 1 && sPattern.Contains('*'))
                                    {
                                        returnedQueryable = dbContext.pO_TEL_VID_CONNECTs.Local;
                                    }
                                    else
                                    {
                                        myRegexValidator = new RegexStringValidator(@"" + oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect);

                                        returnedQueryable = dbContext.pO_TEL_VID_CONNECTs.Local.Where<PO_TEL_VID_CONNECT>((p) => Regex.IsMatch(p.KodOfConnect, sPattern)).ToList<PO_TEL_VID_CONNECT>();
                                    }
                                }
                                catch (RegexParseException rpe)
                                {
                                    returnedQueryable = dbContext.pO_TEL_VID_CONNECTs.Local.Where<PO_TEL_VID_CONNECT>((p) => p.KodOfConnect.Contains(sPattern)).ToList<PO_TEL_VID_CONNECT>();
                                }
                                catch (ArgumentException e)
                                {

                                }

                            }
                            else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                            {

                                ICollection<PO_TEL_VID_CONNECT> returnedQueryableBugFixed = null;

                                string sPattern = @"" + oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name;


                                RegexStringValidator myRegexValidator = null;


                                try
                                {
                                    if (sPattern.Length == 1 && sPattern.Contains('*'))
                                    {
                                        returnedQueryable = dbContext.pO_TEL_VID_CONNECTs.Local;
                                    }
                                    else
                                    {

                                        myRegexValidator = new RegexStringValidator(@"" + oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name);

                                        returnedQueryable = dbContext.pO_TEL_VID_CONNECTs.Local.Where<PO_TEL_VID_CONNECT>((p) => Regex.IsMatch(p.Name, sPattern)).ToList<PO_TEL_VID_CONNECT>();
                                    }
                                }
                                catch (RegexParseException rpe)
                                {
                                    returnedQueryable = dbContext.pO_TEL_VID_CONNECTs.Local.Where<PO_TEL_VID_CONNECT>((p) => p.Name.Contains(sPattern)).ToList<PO_TEL_VID_CONNECT>();
                                }

                                catch (ArgumentException e)
                                {

                                }

                                /*
                                returnedQueryable = from p in dbContext.pO_TEL_VID_CONNECTs
                                                    where  Regex.IsMatch( p.Name, sPattern)
                                                    select p;

                                */
                                if (returnedQueryableBugFixed != null && returnedQueryableBugFixed.Count > 0)
                                {
                                    foreach (var oneEl in returnedQueryableBugFixed)
                                    {
                                        if (oneEl.Id > 0)
                                        {
                                            ; ; ;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (oneCriteriaFilterChain.OperatorLogic == OperatorSignLogic._AND_ && returnedQueryable != null)
                        {
                            if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._EQ_)  // "=="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id == oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._NE_)  // "!="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id != oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where !p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where !p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._GT_)  // ">"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id > oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) > 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) > 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._LT_)  // "<"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id < oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) < 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) < 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._GE_)   // ">="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id >= oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) >= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) >= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._LE_)   // "<="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id <= oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) <= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) <= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._REGEX_)  //  Grep
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id == oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect;

                                    var result = from p in returnedQueryable
                                                 where Regex.IsMatch(p.KodOfConnect, sPattern)
                                                 select p;

                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name;

                                    var result = from p in returnedQueryable
                                                 where Regex.IsMatch(p.Name, sPattern)
                                                 select p;

                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                        }
                        else if (oneCriteriaFilterChain.OperatorLogic == OperatorSignLogic._AND_NOT_ && returnedQueryable != null)
                        {
                            if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._EQ_)  // "=="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id != oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                        !
                                                 where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                        !
                                                 where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._NE_)  // "!="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id == oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where p.KodOfConnect.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Name.Equals(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name)
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._GT_)  // ">"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id <= oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) <= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) <= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._LT_)  // "<"
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id >= oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) >= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) >= 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._GE_)   // ">="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id < oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) < 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) < 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._LE_)   // "<="
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id > oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.KodOfConnect, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect) > 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    var result = from p in returnedQueryable
                                                 where string.Compare(p.Name, oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name) > 0
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                            else if (oneCriteriaFilterChain.OperatorComparisionLeftOnly == OperatorSignComparision._REGEX_)  //  Grep
                            {
                                if (oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id > 0)
                                {
                                    var result = from p in returnedQueryable
                                                 where p.Id != oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Id
                                                 select p;
                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.KodOfConnect;

                                    var result = from p in returnedQueryable
                                                 where !Regex.IsMatch(p.KodOfConnect, sPattern)
                                                 select p;

                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                                else if (!string.IsNullOrEmpty(oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name))
                                {
                                    string sPattern = oneCriteriaFilterChain.ItemOfCriteriaLeftOnly.Name;

                                    var result = from p in returnedQueryable
                                                 where !Regex.IsMatch(p.Name, sPattern)
                                                 select p;

                                    returnedQueryable = result.ToList<PO_TEL_VID_CONNECT>();
                                }
                            }
                        }

                    }
                }

            }
            return returnedQueryable;

            //throw new NotImplementedException();
        }



        public override ICollection<PO_TEL_VID_CONNECT> GetLINQQueryByQueryable(IQueryable<PO_TEL_VID_CONNECT> queryable)
        {
            throw new NotImplementedException();
        }

    }



    public class AdvancedCriteriaOfFilterLINQ4POTELVIDCONNECT<PO_TEL_VID_CONNECT, DbAppContext> : CriteriaOfFilterLINQ<PO_TEL_VID_CONNECT, DbAppContext>
    {
        public override ICollection<PO_TEL_VID_CONNECT> GetLINQQueryBydbContext(DbAppContext dbContext)
        {
            throw new NotImplementedException(); ;
        }

        public override ICollection<PO_TEL_VID_CONNECT> GetLINQQueryByQueryable(IQueryable<PO_TEL_VID_CONNECT> queryable)
        {
            throw new NotImplementedException(); ;
        }
    }


    public class MatrixOfOperatorsFor_POTELVIDCONNECT<PO_TEL_VID_CONNECT> : MatrixOf_OperatorSignComparision_Predicates<PO_TEL_VID_CONNECT>
    {
        private IDictionary<OperatorSignComparision, IDictionary<int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>> _matrixOfPredicates;

        private DbContext _dbContext1;

        private ICollection<PO_TEL_VID_CONNECT> _collection_PO;

        private IQueryable<PO_TEL_VID_CONNECT> _queryable_PO;

        

        public MatrixOfOperatorsFor_POTELVIDCONNECT()
        {
            this._matrixOfPredicates = new Dictionary<OperatorSignComparision, IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>>();


            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_EQ = new Dictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            

            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_EQ_for_PO__ID__ = null;
            predicate_tuple4_EQ.Add(0, streamOf_EQ_for_PO__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_EQ_for_PO__Kod__ = null;
            predicate_tuple4_EQ.Add(1, streamOf_EQ_for_PO__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_EQ_for_PO__Name__ = null;
            predicate_tuple4_EQ.Add(2, streamOf_EQ_for_PO__Name__);
            //predicate_tuple4_EQ.Add();
            //predicate_tuple4_EQ.Add();
            //predicate_tuple4_EQ.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._EQ_, predicate_tuple4_EQ);

            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_NE = new Dictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_NE_for_PO__ID__ = null;
            predicate_tuple4_NE.Add(0, streamOf_NE_for_PO__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_NE_for_PO__Kod__ = null;
            predicate_tuple4_NE.Add(1, streamOf_NE_for_PO__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_NE_for_PO__Name__ = null;
            predicate_tuple4_NE.Add(2, streamOf_NE_for_PO__Name__);
            //predicate_tuple4_NE.Add();
            //predicate_tuple4_NE.Add();
            //predicate_tuple4_NE.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._NE_, predicate_tuple4_NE);

            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_GT = new Dictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_GT_for_PO__ID__ = null;
            predicate_tuple4_GT.Add(0, streamOf_GT_for_PO__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_GT_for_PO__Kod__ = null;
            predicate_tuple4_GT.Add(1, streamOf_GT_for_PO__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_GT_for_PO__Name__ = null;
            predicate_tuple4_GT.Add(2, streamOf_GT_for_PO__Name__);
            //predicate_tuple4_GT.Add();
            //predicate_tuple4_GT.Add();
            //predicate_tuple4_GT.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._GT_, predicate_tuple4_GT);

            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_LT = new Dictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_LT_for_PO__ID__ = null;
            predicate_tuple4_LT.Add(0, streamOf_LT_for_PO__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_LT_for_PO__Kod__ = null;
            predicate_tuple4_LT.Add(1, streamOf_LT_for_PO__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_LT_for_PO__Name__ = null;
            predicate_tuple4_LT.Add(2, streamOf_LT_for_PO__Name__);
            //predicate_tuple4_LT.Add();
            //predicate_tuple4_LT.Add();
            //predicate_tuple4_LT.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._LT_, predicate_tuple4_LT);

            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_GE = new Dictionary<int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_GE_for_PO__ID__ = null;
            predicate_tuple4_GE.Add(0, streamOf_GE_for_PO__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_GE_for_PO__Kod__ = null;
            predicate_tuple4_GE.Add(1, streamOf_GE_for_PO__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_GE_for_PO__Name__ = null;
            predicate_tuple4_GE.Add(2, streamOf_GE_for_PO__Name__);
            //predicate_tuple4_GE.Add();
            //predicate_tuple4_GE.Add();
            //predicate_tuple4_GE.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._GE_, predicate_tuple4_GE);

            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_LE = new Dictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_LE_for_PO__ID__= null;
            predicate_tuple4_LE.Add(0, streamOf_LE_for_PO__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_LE_for_PO__Kod__ = null;
            predicate_tuple4_LE.Add(1, streamOf_LE_for_PO__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_LE_for_PO__Name__ = null;
            predicate_tuple4_LE.Add(2, streamOf_LE_for_PO__Name__);
            //predicate_tuple4_LE.Add();
            //predicate_tuple4_LE.Add();
            //predicate_tuple4_LE.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._LE_, predicate_tuple4_LE);

            IDictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>> predicate_tuple4_REGEX = new Dictionary< int, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>>>();
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_EQ_for_REGEX__ID__ = null;
            predicate_tuple4_REGEX.Add(0, streamOf_EQ_for_REGEX__ID__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_EQ_for_REGEX__Kod__ = null;
            predicate_tuple4_REGEX.Add(1, streamOf_EQ_for_REGEX__Kod__);
            Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> streamOf_EQ_for_REGEX__Name__ = null;
            predicate_tuple4_REGEX.Add(2, streamOf_EQ_for_REGEX__Name__);
            //predicate_tuple4_REGEX.Add();
            //predicate_tuple4_REGEX.Add();
            //predicate_tuple4_REGEX.Add();
            this._matrixOfPredicates.Add(OperatorSignComparision._REGEX_, predicate_tuple4_REGEX);
        }

        public DbContext DBContextProperty { get => this._dbContext1; set => this._dbContext1=value; }

        public IQueryable<PO_TEL_VID_CONNECT> QueryableProperty { get => this._queryable_PO; set => this._queryable_PO=value; }

        public ICollection<PO_TEL_VID_CONNECT> CollectionProperty { get => this._collection_PO; set => this._collection_PO=value; }

        public Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> Get_POs_Filtered(Predicate<PO_TEL_VID_CONNECT> predicateWhichFieldOf_PO_NotEmpty, OperatorSignComparision operatorSignComparision, Tuple<int, IQueryable<PO_TEL_VID_CONNECT>, ICollection<PO_TEL_VID_CONNECT>> baseTuple, DbContext dbcontext)
        {
            throw new NotImplementedException();
        }
    }

}
