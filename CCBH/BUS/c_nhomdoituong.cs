using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_nhomdoituong
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tennhom)
        {
            nhomdoituong dt = new nhomdoituong();
            dt.id = id;
            dt.tennhom = tennhom;
            dbData.nhomdoituongs.InsertOnSubmit(dt);
            dbData.SubmitChanges();
        }
        public void sua(string id, string tennhom)
        {
            var dt = (from a in dbData.nhomdoituongs select a).Single(t => t.id == id);
            dt.tennhom = tennhom;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var dt = (from a in dbData.nhomdoituongs select a).Single(t => t.id == id);
            dbData.nhomdoituongs.DeleteOnSubmit(dt);
            dbData.SubmitChanges();
        }
    }
}
