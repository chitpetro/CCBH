using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_giasp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string idsp, string iddv, double gia)
        {
            giasp g = new giasp();
            g.key = key;
            g.iddv = iddv;
            g.idsp = idsp;
            g.gia = gia;
            dbData.giasps.InsertOnSubmit(g);
            dbData.SubmitChanges();
        }

        public void sua(string key, string idsp, string iddv, double gia)
        {var g = (from a in dbData.giasps select a).Single(t => t.key == key);
            g.iddv = iddv;
            g.idsp = idsp;
            g.gia = gia;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var g = (from a in dbData.giasps select a).Single(t => t.key == key);
            dbData.giasps.DeleteOnSubmit(g);
            dbData.SubmitChanges();
        }
    }
}
