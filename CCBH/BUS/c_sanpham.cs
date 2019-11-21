using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class c_sanpham
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tensp, string dvt, string loai, string ghichu, bool mavach, byte[] hinhanh)
        {
            dmsanpham sp = new dmsanpham();
            sp.id = id;
            sp.tensp = tensp;
            sp.dvt = dvt;
            sp.loai = loai;
            sp.ghichu = ghichu;
            sp.mavach = mavach;
            sp.hinhanh = hinhanh;
            dbData.dmsanphams.InsertOnSubmit(sp);
            dbData.SubmitChanges();
        }

        public void sua(string id, string tensp, string dvt, string loai, string ghichu,bool mavach, byte[] hinhanh)
        {
            var sp = (from a in dbData.dmsanphams select a).Single(t=>t.id == id);
            sp.tensp = tensp;
            sp.dvt = dvt;
            sp.loai = loai;
            sp.ghichu = ghichu;
            sp.mavach = mavach;
            sp.hinhanh = hinhanh;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var sp = (from a in dbData.dmsanphams select a).Single(t => t.id == id);
            dbData.dmsanphams.DeleteOnSubmit(sp);
            dbData.SubmitChanges();
        }

    }
}
