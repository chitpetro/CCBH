using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dmloainhap
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, string loainhap, bool congno)
        {
            dmloainhap ln = new dmloainhap();
            ln.key = key;
            ln.id = id;
            ln.loainhap = loainhap;
            ln.congno = congno;
            ln.giamtrudt = false;
            dbData.dmloainhaps.InsertOnSubmit(ln);
            dbData.SubmitChanges();
        }
        public void sua(string key, string id, string loainhap, bool congno)
        {
            var ln = (from a in dbData.dmloainhaps select a).Single(t => t.key == key);
            ln.id = id;
            ln.loainhap = loainhap;
            ln.congno = congno;
            ln.giamtrudt = false;
            dbData.SubmitChanges();
        }
        public void xoa(string key)
        {
            var ln = (from a in dbData.dmloainhaps select a).Single(t => t.key == key);
            dbData.dmloainhaps.DeleteOnSubmit(ln);
            dbData.SubmitChanges();
        }
    }
}
