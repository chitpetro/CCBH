using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
   public class c_phongban
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string ten)
        {
            phongban pb = new phongban();
            pb.id = id;
            pb.ten = ten;
            dbData.phongbans.InsertOnSubmit(pb);
            dbData.SubmitChanges();
        }
        public void sua(string id, string ten)
        {
            var pb = (from a in dbData.phongbans select a).Single(t => t.id == id);
            pb.ten = ten;
            dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var pb = (from a in dbData.phongbans select a).Single(t => t.id == id);
            dbData.phongbans.DeleteOnSubmit(pb);
            dbData.SubmitChanges();
        }

    }
}
