using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
    public class c_pnhap
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngaynhap, string loainhap, string idnv, string iddt,
            string diengiai, int so, string iddv, string tiente, double tygia)
        {
            pnhap pn = new pnhap();
            pn.key = key;
            pn.id = id;
            pn.ngaynhap = ngaynhap;
            pn.loainhap = loainhap;
            pn.idnv = idnv;
            pn.iddt = iddt;
            pn.diengiai = diengiai;
            pn.so = so;
            pn.iddv = iddv;
            pn.tiente = tiente;
            pn.tygia = tygia;
            dbData.pnhaps.InsertOnSubmit(pn);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngaynhap, string loainhap, string iddt,
            string diengiai, string tiente, double tygia)
        {
            var pn = (from a in dbData.pnhaps select a).Single(t => t.key == key);
            pn.ngaynhap = ngaynhap;
            pn.loainhap = loainhap;
            pn.iddt = iddt;
            pn.diengiai = diengiai;
            pn.tiente = tiente;
            pn.tygia = tygia;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var pn = (from a in dbData.pnhaps select a).Single(t => t.key == key);
            dbData.pnhaps.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var pn = (from a in dbData.pnhap_cts select a).Single(t => t.key == key);
            dbData.pnhap_cts.DeleteOnSubmit(pn);
            dbData.SubmitChanges();
        }




    }
}
