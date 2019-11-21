using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_pxuat
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string key, string id, DateTime ngayxuat, string loaixuat, string idnv, string iddt,
            string diengiai, int so, string iddv, string tiente, double tygia)
        {
            pxuat px = new pxuat();
            px.key = key;
            px.id = id;
            px.ngayxuat = ngayxuat;
            px.loaixuat = loaixuat;
            px.idnv = idnv;
            px.iddt = iddt;
            px.diengiai = diengiai;
            px.so = so;
            px.iddv = iddv;
            px.tiente = tiente;
            px.tygia = tygia;
            dbData.pxuats.InsertOnSubmit(px);
            dbData.SubmitChanges();
        }

        public void sua(string key, DateTime ngayxuat, string loaixuat, string iddt,
            string diengiai, string tiente, double tygia)
        {
            var px = (from a in dbData.pxuats select a).Single(t => t.key == key);
            px.key = key;
            px.ngayxuat = ngayxuat;
            px.loaixuat = loaixuat;
            px.iddt = iddt;
            px.diengiai = diengiai;
            px.tiente = tiente;
            px.tygia = tygia;
            dbData.SubmitChanges();

        }

        public void xoa(string key)
        {
            var px = (from a in dbData.pxuats select a).Single(t => t.key == key);
            dbData.pxuats.DeleteOnSubmit(px);
            dbData.SubmitChanges();
        }

        public void xoact(string key)
        {
            var px = (from a in dbData.pxuatcts select a).Single(t => t.key == key);
            dbData.pxuatcts.DeleteOnSubmit(px);
            dbData.SubmitChanges();
        }
    }
}
