using GameIntroDAL;
using MyBookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameIntroBLL
{
    public static class UserManager
    {
        public static bool AdminLogin(string loginName, string loginPwd, out User validUser)
        {
            User user = UserService.GetUserByLoginId(loginName);


            if (user == null)
            {
                //用户名不存在 
                validUser = null;
                return false;
            }

            if (user.LoginPwd == loginPwd)
            {
                validUser = user;
                return true;
            }
            else
            {
                //密码错误
                validUser = null;
                return true;
            }
        }

        public static User GetUserById(int id)
        {
           return UserService.GetUserById(id);
        }
    }
}
