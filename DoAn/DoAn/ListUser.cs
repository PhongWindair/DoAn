using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    internal class ListUser
    {
        private List<User> users;

        public ListUser()
        {
            users = new List<User>
            {
                new User { Username = "admin", Password = "1234", Role = "Quản lý" },
                new User { Username = "employee", Password = "abcd", Role = "Nhân viên" }
            };
        }

        public User Authenticate(string username, string password, string role)
        {
            return users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password &&
                u.Role == role
            );
        }
        public bool HasPermission(User user, string requiredRole)
        {
            return user != null && user.Role == requiredRole;
        }
    }

}
