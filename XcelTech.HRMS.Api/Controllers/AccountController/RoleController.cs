using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("createNewRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            try
            {
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



    }
}