﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;


namespace XcelTech.HRMS.Repo.Repo
{
   
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DepartmentRepository( ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            
        }

        public async Task createDepartment(Department department)
        {
            _applicationDbContext.Departments.Add(department);
            int savedChanges = await _applicationDbContext.SaveChangesAsync();

          
        }

        public async Task<bool> isNewDepartment(string DepartmentName)
        {
                
                var  isNotNew = await _applicationDbContext.Departments.AnyAsync(dep => dep.DepartmentName == DepartmentName);
                return isNotNew == false; 
            //or simply return !isNonew
        }
        public async Task<ActionResult<int>> getDepartmentByName(string DepartmentName)
        {
            var department = await _applicationDbContext.Departments.FirstOrDefaultAsync(dep => dep.DepartmentName == DepartmentName);
            if (department != null)
            {
                var departmentId = department.DepartmentId;
                Console.WriteLine("Hellasldjfisdf, world!");

                return departmentId;

            }
            Console.WriteLine("Hell isdf, world!");

            return new NotFoundResult();
            //or simply return !isNonew
        }
        public async Task<ActionResult<string>> getDepartmentNameById(int? DepartmentId)
        {
            var department = await _applicationDbContext.Departments.FirstOrDefaultAsync(dep => dep.DepartmentId == DepartmentId);
            if (department != null)
            {
                var departmentName = department.DepartmentName;

                return departmentName;
                Console.WriteLine("aman");
                Console.WriteLine(departmentName);

            }
            return new NotFoundResult();
            
        }



        public async Task<ActionResult<List<Department>>> getAllDepartment()
        {
            var departments = await _applicationDbContext.Departments
                .Select(e => new Department
                {
                    DepartmentName = e.DepartmentName,
                    DepartmentDescription = e.DepartmentDescription
                })
                .ToListAsync();

            return departments;
        }
        public async Task<ActionResult<List<string>>> getAllDepartmentNames()
        {
            var departmentNames = await _applicationDbContext.Departments
                .Select(d => d.DepartmentName)
                .ToListAsync();

            return departmentNames;
        }

    }
}
