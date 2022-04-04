using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDBMS027
{

    public class CriteriaOfFilterLINQ4POTELVIDCONNECT : CriteriaOfFilterLINQ<PO_TEL_VID_CONNECT, DbAppContext>
    {

        public override IQueryable<PO_TEL_VID_CONNECT> GetLINQQuery(DbAppContext dbContext)
        {
            throw new NotImplementedException();
        }

    }
}
