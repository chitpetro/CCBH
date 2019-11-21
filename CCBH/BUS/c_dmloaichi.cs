using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dmloaichi
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string loaichi, bool chiphi, bool congno)
        {
            dmloaichi lc = new dmloaichi();
            lc.id = id;
            lc.loaichi = loaichi;
            lc.chiphi = chiphi;
            dbData.dmloaichis.InsertOnSubmit(lc);
            dbData.SubmitChanges();
        }
        public void sua(string id, string loaichi, bool chiphi, bool congno)
        {
            var lc = (from a in dbData.dmloaichis select a).Single(t => t.id == id);
            lc.loaichi = loaichi;
            lc.chiphi = chiphi;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var lc = (from a in dbData.dmloaichis select a).Single(t => t.id == id);
            dbData.dmloaichis.DeleteOnSubmit(lc);
            dbData.SubmitChanges();
        }
    }
}
