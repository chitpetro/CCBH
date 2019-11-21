using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_ptt
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngaythu, string idnv, string iddt, int so, string iddv,
            string tiente, double tygia, string link, double tienthu, double tientra, double thanhtientt)
        {
            ptt pt = new ptt();
            pt.key = key;
            pt.id = id;
            pt.ngaythu = ngaythu;
            pt.idnv = idnv;
            pt.iddt = iddt;
            pt.so = so;
            pt.iddv = iddv;
            pt.tiente = tiente;
            pt.tygia = tygia;
            pt.link = link;
            pt.tienthu = tienthu;
            pt.tientra = tientra;
            pt.thanhtientt = thanhtientt;
            dbData.ptts.InsertOnSubmit(pt);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngaythu, string tiente, double tygia, double tienthu, double tientra, double thanhtientt)
        {
            var pt = (from a in dbData.ptts select a).Single(t => t.key == key);

            pt.ngaythu = ngaythu;
            pt.tiente = tiente;
            pt.tygia = tygia;
            pt.tienthu = tienthu;
            pt.tientra = tientra;
            pt.thanhtientt = thanhtientt;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var pt = (from a in dbData.ptts select a).Single(t => t.key == key);
            dbData.ptts.DeleteOnSubmit(pt);
            dbData.SubmitChanges();
        }
    }
}
