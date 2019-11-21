using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BUS;

namespace BUS
{
    public class c_pchi
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string key, string id, DateTime ngaychi, string loaichi, string idnv, string iddt,
            string diengiai, int so, string iddv, string tiente, double tygia)
        {
            pchi pc = new pchi();
            pc.key = key;
            pc.id = id;
            pc.ngaychi = ngaychi;
            pc.loaichi = loaichi;
            pc.idnv = idnv;
            pc.iddt = iddt;
            pc.diengiai = diengiai;
            pc.so = so;
            pc.iddv = iddv;
            pc.tiente = tiente;
            pc.tygia = tygia;
            dbData.pchis.InsertOnSubmit(pc);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngaychi, string loaichi, string iddt,
            string diengiai, string tiente, double tygia)
        {
            var pc = (from a in dbData.pchis select a).Single(t => t.key == key);
            pc.ngaychi = ngaychi;
            pc.loaichi = loaichi;
            pc.iddt = iddt;
            pc.diengiai = diengiai;
            pc.tiente = tiente;
            pc.tygia = tygia;
            dbData.SubmitChanges();
        }

        public void xoa(string key)
        {
            var pc = (from a in dbData.pchis select a).Single(t => t.key == key);
            dbData.pchis.DeleteOnSubmit(pc);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var pc = (from a in dbData.pchicts select a).Single(t => t.key == key);
            dbData.pchicts.DeleteOnSubmit(pc);
            dbData.SubmitChanges();
        }

    }
}
