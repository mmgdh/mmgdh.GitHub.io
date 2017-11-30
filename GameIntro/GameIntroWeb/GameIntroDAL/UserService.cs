using GameIntroModel;
using MyBookShop.DAL;
using MyBookShop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroDAL
{
    public class UserService
    {
        public static IList<User> GetAllUsers()
        {
            string sqlAll = "SELECT * FROM Users";
            return GetUsersBySql(sqlAll);
        }
        /// <summary>
        /// 根据id查询单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        public static User GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            int userStateId;
            int userRoleId;
            using (SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id)))
            {
                if (reader.Read())
                {
                    User user = new User();
                    user.Id = (int)reader["Id"];
                    user.LoginName = (string)reader["LoginName"];
                    user.LoginPwd = (string)reader["LoginPwd"];
                    user.EmptyDisk = (int)reader["EmptyDisk"];
                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据登录名查询用户
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static User GetUserByLoginId(string loginName)
        {
            string sql = "SELECT * FROM Users WHERE LoginName = @LoginName";
            int userStateId;
            int userRoleId;
            using (SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@LoginName", loginName)))
            {
                if (reader.Read())
                {
                    User user = new User();

                    user.Id = (int)reader["Id"];
                    user.LoginName = (string)reader["LoginName"];
                    user.LoginPwd = (string)reader["LoginPwd"];
             //       userStateId = (int)reader["UserStateId"]; //FK
             //       userRoleId = (int)reader["UserRoleId"]; //FK
                    reader.Close();
            //        user.UserState = UserStateService.GetUserStateById(userStateId);
            //      user.UserRole = UserRoleService.GetUserRoleById(userRoleId);

                    return user;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
        }
        /// <summary>
        /// 依据sql语句查询用户
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        private static IList<User> GetUsersBySql(string safeSql)
        {
            List<User> list = new List<User>();

            using (DataTable table = DBHelper.GetDataSet(safeSql))
            {
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();

                    user.Id = (int)row["Id"];
                    user.LoginName = (string)row["LoginId"];
                    user.LoginPwd = (string)row["LoginPwd"];
                    user.Name = (string)row["Name"];
                    user.Address = (string)row["Address"];
                    user.Phone = (string)row["Phone"];
                    user.Mail = (string)row["Mail"];
                    user.UserState = UserStateService.GetUserStateById((int)row["UserStateId"]); //FK
                    user.UserRole = UserRoleService.GetUserRoleById((int)row["UserRoleId"]); //FK

                    list.Add(user);
                }

                return list;
            }
        }
        /// <summary>
        /// 根据sql及相关参数查询用户
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static IList<User> GetUsersBySql(string sql, params SqlParameter[] values)
        {
            List<User> list = new List<User>();

            using (DataTable table = DBHelper.GetDataSet(sql, values))
            {
                foreach (DataRow row in table.Rows)
                {
                    User user = new User();

                    user.Id = (int)row["Id"];
                    user.LoginName = (string)row["LoginName"];
                    user.LoginPwd = (string)row["LoginPwd"];
                    user.Name = (string)row["Name"];
                    user.Address = (string)row["Address"];
                    user.Phone = (string)row["Phone"];
                    user.Mail = (string)row["Mail"];
                    user.UserState = UserStateService.GetUserStateById((int)row["UserStateId"]); //FK
                    user.UserRole = UserRoleService.GetUserRoleById((int)row["UserRoleId"]); //FK

                    list.Add(user);
                }
                return list;
            }
        }

    }
}
