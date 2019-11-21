using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_muccp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tenmuccp)
        {
            muccp m = new muccp();
            m.id = id;
            m.tenmuccp = tenmuccp;
            dbData.muccps.InsertOnSubmit(m);
            dbData.SubmitChanges();
        }
        public void sua(string id)
        {
            var m = (from a in dbData.muccps select a).Single(t => t.id == id);
            m.id = id;
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var m = (from a in dbData.muccps select a).Single(t => t.id == id);
            m.id = id;
            dbData.muccps.DeleteOnSubmit(m);
            dbData.SubmitChanges();
        }
    }
}
