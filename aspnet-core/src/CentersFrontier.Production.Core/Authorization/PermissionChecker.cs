using Abp.Authorization;
using CentersFrontier.Production.Authorization.Roles;
using CentersFrontier.Production.Authorization.Users;

namespace CentersFrontier.Production.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
