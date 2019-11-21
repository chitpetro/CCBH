using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_nhomdonvi
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tennhom)
        {
            nhomdonvi dv = new nhomdonvi();
            dv.id = id;
            dv.tennhom = tennhom;
            dbData.nhomdonvis.InsertOnSubmit(dv);
            dbData.SubmitChanges();
        }
        public void sua(string id, string tennhom)
        {
            var dv = (from a in dbData.nhomdonvis select a).Single(t => t.id == id);
            dv.tennhom = tennhom;
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var dv = (from a in dbData.nhomdonvis select a).Single(t => t.id == id);
            dbData.nhomdonvis.DeleteOnSubmit(dv);
            dbData.SubmitChanges();
        }

    }
}
