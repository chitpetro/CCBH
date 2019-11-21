using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{

    public class c_tiente
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string tentiente, double tygia, string ghichu)
        {
            tiente tt = new tiente();
            tt.tentiente = tentiente;
            tt.tygia = tygia;
            tt.ghichu = ghichu;
            dbData.tientes.InsertOnSubmit(tt);
            dbData.SubmitChanges();
        }
        public void sua(string tentiente, double tygia, string ghichu)
        {
            var tt = (from a in dbData.tientes select a).Single(t => t.tentiente == tentiente);
            tt.tygia = tygia;
            tt.ghichu = ghichu;
            dbData.SubmitChanges();
        }

        public void xoa(string tentiente)
        {
            var tt = (from a in dbData.tientes select a).Single(t => t.tentiente == tentiente);
            dbData.tientes.DeleteOnSubmit(tt);
            dbData.SubmitChanges();
        }
    }
}
