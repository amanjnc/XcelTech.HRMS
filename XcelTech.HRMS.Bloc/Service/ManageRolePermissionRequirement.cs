using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Bloc.Service
{
    public class ManageRolePermissionRequirement : IAuthorizationRequirement
    {
    }

    public class ManageRolePermissionHandler : AuthorizationHandler<ManageRolePermissionRequirement>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageRolePermissionHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageRolePermissionRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                var claims = await _roleManager.GetClaimsAsync(await _roleManager.FindByNameAsync(role));
                if (claims.Any(c => c.Type == "Permission" && c.Value == "ManageRolePermissions"))
                {
                    context.Succeed(requirement);
                    return;
                }
            }
        }
    }
}
