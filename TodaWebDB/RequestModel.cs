using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodaWebDB
{
    public class RequestModel
    {
        private TodaWebDbContext context = null;
        public RequestModel()
        {
            context = new TodaWebDbContext();
        }
        public void InsertRequest(Request request)
        {
            var sqlParam = new SqlParameter[]
            {
                new SqlParameter("@UserID", request.UserID),
                new SqlParameter("@Value", request.Value),
                new SqlParameter("@PhongBan", request.PhongBan),
                new SqlParameter("@Subject", request.Subject),
                new SqlParameter("@Time", DateTime.Now),
                new SqlParameter("@Status", false)
            };
            context.Database.ExecuteSqlCommand("usp_Web_Request_Insert @UserID, @Value, @PhongBan, @Subject, @Time, @Status", sqlParam);
        }

        public List<Request> Request_SelectAll(int IDUser)
        {
            List<Request> temp = new List<Request>();
            temp = context.Database.SqlQuery<Request>("usp_Web_tblRequest_Select_IDUser @IDUser", new SqlParameter("@IDUser", IDUser)).ToList();
            return temp;
        }

        public List<Request> Request_SelectAllStatus(int? IDUser, bool Status)
        {
            List<Request> temp = new List<Request>();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IDUser", IDUser),
                new SqlParameter("@Status", Status)
            };
            temp = context.Database.SqlQuery<Request>("usp_Web_tblRequest_Select_IDUser_Status @IDUser, @Status", param).ToList();
            return temp;
        }
    }
}
