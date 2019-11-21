using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dmloaixuat
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them( string id, string loaixuat, bool doanhthu, bool noibo)
        {
            dmloaixuat ln = new dmloaixuat();
          
            ln.id = id;
            ln.loaixuat = loaixuat;
            ln.doanhthu = doanhthu;
            ln.noibo = noibo;
            dbData.dmloaixuats.InsertOnSubmit(ln);
            dbData.SubmitChanges();
        }
        public void sua(string id, string loaixuat, bool doanhthu, bool noibo)
        {
            var ln = (from a in dbData.dmloaixuats select a).Single(t => t.id == id);
        
            ln.loaixuat = loaixuat;
            ln.doanhthu = doanhthu;
            ln.noibo = noibo;
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var ln = (from a in dbData.dmloaixuats select a).Single(t => t.id == id);
            dbData.dmloaixuats.DeleteOnSubmit(ln);
            dbData.SubmitChanges();
        }
    }
}
