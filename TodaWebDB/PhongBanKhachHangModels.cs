using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodaWebDB
{
    public class PhongBanKhachHangModels
    {
        private TodaWebDbContext context = null;
        public PhongBanKhachHangModels()
        {
            context = new TodaWebDbContext();
        }
        public List<PhongBanKhachHang> GetPhongBan()
        {
            List<PhongBanKhachHang> temp = new List<PhongBanKhachHang>();
            temp = context.Database.SqlQuery<PhongBanKhachHang>("usp_PMCC_tblPhongBan_SelectAll", new SqlParameter[0]).ToList();
            return temp;
        }
    }
}
