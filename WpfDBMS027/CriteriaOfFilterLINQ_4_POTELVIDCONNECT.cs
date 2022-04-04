using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }



        public override IQueryable<PO_TEL_VID_CONNECT> GetLINQQueryByQueryable(IQueryable<PO_TEL_VID_CONNECT> queryable)
        {
            throw new NotImplementedException();
        }

    }
}
