using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BUS
{
    public class Biencucbo
    {
        public static PhanQuyen2 QuyenDangChon { get; set; }
        public static string donvi = "";
        public static string idnv = "";
        public static string ten = "";
        public static string hostname = "";
        public static string IPaddress = "";
        public static int hdong = 0;
        public static string key = "";
        public static string skin = "";
        public static string skin2 = "";
        public static string DonViMain = "";
        public static string phongban = "";
        public static string DbName = "";
        public static string ServerName = "";
        public static int so;
        public static DateTime ngaysaochep;
        public static string path;
        public static string pathName;
        public static string ma;
        public static string link;
        public static double tongtien;


        public static object ngonngu;

        // Số lượng + đơn giá xuất nhập
        public static double soluong = 0;
        public static double dongia = 0;
        public static bool banhang = false;

        // Báo Cáo
        public static string ngaybc = "";
        public static string info = "";
        public static string title;
        public static bool xembc;
        public static string form;
        public static DateTime tungay;
        public static DateTime denngay;
        public static string iddt;

        public static double skip;
        public static double susd;
        public static double sbath;
        public static double sdiscount;
        public static double cash;
        public static double change;

    }
}
