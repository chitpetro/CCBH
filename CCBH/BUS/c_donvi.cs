using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class c_donvi
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tendonvi, string nhomdonvi, string dvql, int cap, string diachi)
        {
            donvi dv = new donvi();
            dv.id = id;
            dv.tendonvi = tendonvi;
            dv.nhomdonvi = nhomdonvi;
            dv.dvql = dvql;
            dv.cap = cap;
            dv.diachi = diachi;
            dbData.donvis.InsertOnSubmit(dv);
            dbData.SubmitChanges();
        }
        public void sua(string id, string tendonvi, string nhomdonvi, string dvql, int cap, string diachi)
        {
            var dv = (from a in dbData.donvis select a).Single(t => t.id == id);
            dv.tendonvi = tendonvi;
            dv.nhomdonvi = nhomdonvi;
            dv.dvql = dvql;
            dv.cap = cap;
            dv.diachi = diachi;
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var dv = (from a in dbData.donvis select a).Single(t => t.id == id);
            dbData.donvis.DeleteOnSubmit(dv);
            dbData.SubmitChanges();
        }
    }
}
