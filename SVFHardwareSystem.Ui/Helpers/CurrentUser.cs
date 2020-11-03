using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.Ui.Helpers
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static string Name { get; set; }
        public static List<string> Permissions { private get; set; }
        public static List<string> Roles { private get; set; }
        public static bool HasUserPermission()
        {
            if (UserID == 1)
            {
                return true;
            }
            return false;
        }
        public static bool HasPermission(string permissionName)
        {
            if (UserID == 1)
            {
                return true;
            }

            var permission = Permissions.Where(p => p.ToUpper() == permissionName.ToUpper()).FirstOrDefault();
            if (permission != null)
            {
                return true;
            }

            return false;
        }
        public static bool HasRoles(string uRole)
        {
            if (UserID == 1)
            {
                return true;
            }

            var role = Roles.Where(p => p.ToUpper() == uRole.ToUpper()).FirstOrDefault();
            if (role != null)
            {
                return true;
            }

            return false;
        }
    }
}
