using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class c_doituong
    {
        KetNoiDBDataContext dbData = new KetNoiDBDataContext();

        public void them(string id, string tendt, string nhom, string diachi, string msthue, string dienthoai, string email, string fax, string dd, string taikhoan, string nganhang, string gioitinh)
        {
            doituong dt = new doituong();
            dt.id = id;
            dt.tendt = tendt;
            dt.nhom = nhom;
            dt.diachi = diachi;
            dt.msthue = msthue;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.fax = fax;
            dt.dd = dd;
            dt.taikhoan = taikhoan;
            dt.gioitinh = gioitinh;
            dt.nganhang = nganhang;
            dbData.doituongs.InsertOnSubmit(dt);
            dbData.SubmitChanges();
        }

        public void sua(string id, string tendt, string nhom, string diachi, string msthue, string dienthoai, string email, string fax, string dd, string taikhoan, string nganhang, string gioitinh)
        {
            var dt = (from a in dbData.doituongs select a) .Single(t=>t.id == id);
            dt.tendt = tendt;
            dt.nhom = nhom;
            dt.diachi = diachi;
            dt.msthue = msthue;
            dt.dienthoai = dienthoai;
            dt.email = email;
            dt.gioitinh = gioitinh;
            dt.fax = fax;
            dt.dd = dd;
            dt.taikhoan = taikhoan;
            dt.nganhang = nganhang;
            dbData.SubmitChanges();
        }

        public void xoa(string id)
        {
            var dt = (from a in dbData.doituongs select a).Single(t => t.id == id);
            dbData.doituongs.DeleteOnSubmit(dt);
            dbData.SubmitChanges();
        }
    }
}
