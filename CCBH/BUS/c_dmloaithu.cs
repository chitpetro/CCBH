using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_dmloaithu
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();
        public void them(string id, string loaithu)
        {
            dmloaithu lt = new dmloaithu();
            lt.id = id;
            lt.loaithu = loaithu;
            dbData.dmloaithus.InsertOnSubmit(lt);
            dbData.SubmitChanges();
        }
        public void sua(string id, string loaithu)
        {
            var lt = (from a in dbData.dmloaithus select a).Single(t => t.id == id);
            lt.loaithu = loaithu;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var lt = (from a in dbData.dmloaithus select a).Single(t => t.id == id);
            dbData.dmloaithus.DeleteOnSubmit(lt);
            dbData.SubmitChanges();
        }

    }
}
