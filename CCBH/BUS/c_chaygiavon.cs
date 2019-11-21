using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class c_chaygiavon
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void chay(string key, double giavon)
        {
            var lst = (from a in dbData.pxuatcts select a).Single(t => t.key == key);

            lst.giavon = giavon;
            dbData.SubmitChanges();
        }

    }
}
