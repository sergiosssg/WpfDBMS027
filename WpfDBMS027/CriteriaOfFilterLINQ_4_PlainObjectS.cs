using System;
using System.Collections.Generic;
using System.Configuration;
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
}
