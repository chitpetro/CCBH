using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_account
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string uname, string name, string pass, string phongban, string madonvi, bool isActived, bool pos)
        {
            account ac = new account();
            ac.id = id;
            ac.uname = uname;
            ac.name = name;
            ac.pass = pass;
            ac.phongban = phongban;
            ac.madonvi = madonvi;
            ac.IsActived = isActived;
            ac.pos = pos;
            dbData.accounts.InsertOnSubmit(ac);
            dbData.SubmitChanges();
        }
        public void sua(string id, string name, string pass, string phongban, string madonvi, bool isActived, bool pos)
        {
            var ac = (from a in dbData.accounts select a).Single(t => t.id == id);
            ac.name = name;
            ac.pass = pass;
            ac.phongban = phongban;
            ac.madonvi = madonvi;
            ac.pos = pos;
            ac.IsActived = isActived;
            dbData.SubmitChanges();
        }
        public void sua2(string id, string name, string phongban, string madonvi, bool isActived, bool pos)
        {
            var ac = (from a in dbData.accounts select a).Single(t => t.id == id);
            ac.name = name;
            ac.phongban = phongban;
            ac.madonvi = madonvi;
            ac.IsActived = isActived;
            ac.pos = pos;dbData.SubmitChanges();
        }
        public void xoa(string id)
        {
            var ac = (from a in dbData.accounts select a).Single(t => t.id == id);
            dbData.accounts.DeleteOnSubmit(ac);
            dbData.SubmitChanges();
        }

    }
}
