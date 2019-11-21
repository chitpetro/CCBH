using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class c_loaisp
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

       public void them(string id, string tenloaisp)
       {
            dmloaisp sp = new dmloaisp();
           sp.id = id;
           sp.tenloaisp = tenloaisp;
            dbData.dmloaisps.InsertOnSubmit(sp);
            dbData.SubmitChanges();
       }

        public void sua(string id, string tenloaisp)
        {
            var sp = (from a in dbData.dmloaisps select a).Single(t=>t.id == id);
            sp.tenloaisp = tenloaisp;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var sp = (from a in dbData.dmloaisps select a).Single(t => t.id == id);
            dbData.dmloaisps.DeleteOnSubmit(sp);
            dbData.SubmitChanges();
        }
    }
}
