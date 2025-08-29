using EF_Core_Assignment02.DataAccess;
using EF_Core_Assignment02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext _db;
        public DepartmentService(AppDbContext db)
        {
            _db = db;
        }

        #region CRUD Operations on Department
        public void AddDepartment(Department department)
        {
            if (department == null)
            {
                throw new Exception(nameof(department));
            }

                department.HiringDate = DateOnly.FromDateTime(DateTime.Now);

            _db.Departments.Add(department);
            _db.SaveChanges();

            Console.WriteLine("Department Added Successfully!");
        }



        public Department GetDepartment(int Id)
        {
            var Department = _db.Departments.FirstOrDefault(x => x.ID == Id);
            if (Department is null)
            {
                throw new Exception($"Department with Id {Id} not found!");
            }

            return Department;
        }


        public List<Department> GetAllDepartment()
        {
            List<Department> Departments = _db.Departments.ToList();

            return Departments;
        }



        public void UpdateDepartment(int id, Department updatedDepartment)
        {
            var DepartmentToBeUpdated = _db.Departments.FirstOrDefault(x => x.ID == id);
            if (DepartmentToBeUpdated is null)
            {
                throw new Exception($"Department with Id {id} not found!");
            }

            DepartmentToBeUpdated.Name = updatedDepartment.Name;
            DepartmentToBeUpdated.HiringDate = updatedDepartment.HiringDate;

            _db.Departments.Update(DepartmentToBeUpdated);
            _db.SaveChanges();

            Console.WriteLine("Department Updated Successfully!");
        }



        public void DeleteDepartment(int Id)
        {
            var DepartmentToBeDeleted = _db.Departments.FirstOrDefault(x => x.ID == Id);
            if (DepartmentToBeDeleted is null)
            {
                throw new Exception($"Department with Id {Id} not found!");
            }
            _db.Departments.Remove(DepartmentToBeDeleted);
            _db.SaveChanges();

            Console.WriteLine("Department Deleted Successfully!");

        }
        #endregion
    }
}
