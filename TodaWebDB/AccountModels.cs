using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodaWebDB;

namespace TodaWebDB
{
    public class AccountModels
    {
        private TodaWebDbContext context = null;
        public AccountModels()
        {
            context = new TodaWebDbContext();
        }
        public bool Login(string Username, string Password)
        {
            var sqlParam = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password)
            };
            var res = context.Database.SqlQuery<bool>("usp_PMCC_UserWeb_CheckLogin @Username,@Password", sqlParam).SingleOrDefault();
            return res;
        }

        public UserWeb GetLoginUser(string Username, string Password)
        {
            var sqlParam = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password)
            };
            UserWeb res = context.Database.SqlQuery<UserWeb>("usp_PMCC_UserWeb_SelectUserLogin @Username,@Password", sqlParam).SingleOrDefault();
            return res;
        }

        public void RegisterUser(string Username, string Name, string PhoneNumber, string Email, string Password)
        {
            var sqlParam = new SqlParameter[]
            {
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password),
                new SqlParameter("@Name", Name),
                new SqlParameter("@PhoneNumber",PhoneNumber),
                new SqlParameter("@RoleID", 2),
                new SqlParameter("@Email",Email)
                
            };
            context.Database.ExecuteSqlCommand("usp_Web_tblUser_Insert @Username,@Password,@Name,@PhoneNumber,@RoleID,@Email", sqlParam);
        }
    }
}
