using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BUS
{
    public class c_pthu
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngaythu, string loaithu, string idnv, string iddt,
            string diengiai, int so, string iddv, string tiente, double tygia)
        {
            pthu pt = new pthu();
            pt.key = key;
            pt.id = id;
            pt.ngaythu = ngaythu;
            pt.loaithu = loaithu;
            pt.idnv = idnv;
            pt.iddt = iddt;
            pt.diengiai = diengiai;
            pt.so = so;
            pt.iddv = iddv;
            pt.tiente = tiente;
            pt.tygia = tygia;
            dbData.pthus.InsertOnSubmit(pt);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngaythu, string loaithu, string iddt,
          string diengiai, string tiente, double tygia)
        {
            var pt = (from a in dbData.pthus select a).Single(t => t.key == key);
            pt.ngaythu = ngaythu;
            pt.loaithu = loaithu;
            pt.iddt = iddt;
            pt.diengiai = diengiai;
            pt.tiente = tiente;
            pt.tygia = tygia;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var pt = (from a in dbData.pthus select a).Single(t => t.key == key);
            dbData.pthus.DeleteOnSubmit(pt);
            dbData.SubmitChanges();
        }
        public void xoact(string key)
        {
            var pt = (from a in dbData.pthucts select a).Single(t => t.key == key);
            dbData.pthucts.DeleteOnSubmit(pt);
            dbData.SubmitChanges();
        }
    }
}
