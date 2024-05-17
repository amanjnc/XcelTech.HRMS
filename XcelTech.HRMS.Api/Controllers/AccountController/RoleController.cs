using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet("getAllRoles")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("AssignPermissionClaim")]
        public async Task AssignPermissionClaimToRole(string roleName, string permission)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            var existingClaims = await _roleManager.GetClaimsAsync(role);

            Console.WriteLine(existingClaims);

            if (!existingClaims.Any(c => c.Type == "Permission" && c.Value == permission))
            {
                await _roleManager.AddClaimAsync(role, new Claim("Permission", permission));

                var newClaims = await _roleManager.GetClaimsAsync(role);
                Console.WriteLine(newClaims);


                Console.WriteLine("The permission claim has been assigned to the role.");
            }
            else
            {
                Console.WriteLine("The permission claim is already assigned to the role.");
            }
        }

        [HttpGet("getPermissionsForRole")]
        public async Task<List<string>> GetPermissionValuesForRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            var claims = await _roleManager.GetClaimsAsync(role);

            var permissionClaims = claims.Where(c => c.Type == "Permission").Select(c => c.Value).ToList();

            return permissionClaims;
        }


        [HttpPost("createNewRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            try
            {
                if (string.IsNullOrEmpty(roleName))
                {
                    return BadRequest("Role name is required.");
                }

                var existingRole = await _roleManager.FindByNameAsync(roleName);
                if (existingRole != null)
                {
                    return BadRequest("Role already exists.");
                }
                var newRole = new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpperInvariant()
                };
                var result = await _roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    return Ok("Role created successfully.");
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return BadRequest(errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            await _roleManager.DeleteAsync(role);
            return Ok("Role deleted successfully.");




        }




    }
}