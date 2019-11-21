using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class c_tudong
    {
        KetNoiDBDataContext db = new KetNoiDBDataContext();

        public void themtudong(string maphieu, int so)
        {
            tudong td = new tudong();
            td.maphieu = maphieu;
            td.so = so;
            td.iddv = Biencucbo.donvi;
            db.tudongs.InsertOnSubmit(td);
            db.SubmitChanges();
        }
        public void suatudong(string maphieu, int so)
        {
            tudong td = (from k in db.tudongs select k).Single(t => t.maphieu == maphieu);
            //td.maphieu = maphieu;
            td.so = so;
            db.SubmitChanges();
        }
    }
}
