using EF_Core_Assignment02.DataAccess;
using EF_Core_Assignment02.DataSeeding;
using EF_Core_Assignment02.Models;
using EF_Core_Assignment02.Services;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Assignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext db = new AppDbContext();
            //CompanySeeding.DataSeeding(db);

            #region Lazy Loading
            //var Instructor = db.Instructors.FirstOrDefault(i => i.ID == 1);
            //if(Instructor != null)
            //{
            //    Console.WriteLine($"Instructor Name: {Instructor.Name}");
            //    Console.WriteLine($"Department Id: {Instructor.Dept_ID}");
            //    Console.WriteLine($"Department Name: {Instructor.Department?.Name}");
            //}
            #endregion
            #region Eager Loading
            //var Instructor = db.Instructors.Include(d => d.Department).FirstOrDefault(i => i.ID == 1);
            //if (Instructor != null)
            //{
            //    Console.WriteLine($"Instructor Name: {Instructor.Name}");
            //    Console.WriteLine($"Department Id: {Instructor.Dept_ID}");
            //    Console.WriteLine($"Department Name: {Instructor.Department?.Name}");
            //}
            #endregion
            #region Explicit Loading
            // var Instructor = db.Instructors.FirstOrDefault(i => i.ID == 1);
            // db.Entry(Instructor)
            //.Reference(d => d.Department)
            //.Load();
            // if (Instructor != null)
            // {
            //     Console.WriteLine($"Instructor Name: {Instructor.Name}");
            //     Console.WriteLine($"Department Id: {Instructor.Dept_ID}");
            //     Console.WriteLine($"Department Name: {Instructor.Department?.Name}");
            // }
            #endregion

            var deptService = new DepartmentService(db);   // service layer

            while (true)
            {
                Console.WriteLine("--- Department Menu ---");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Get Department By Id");
                Console.WriteLine("3. Get All Departments");
                Console.WriteLine("4. Update Department");
                Console.WriteLine("5. Delete Department");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Enter Department Name: ");
                            var name = Console.ReadLine();

                            var newDept = new Department
                            {
                                Name = name,
                                HiringDate = DateOnly.FromDateTime(DateTime.Now)
                            };

                            deptService.AddDepartment(newDept);
                            Console.WriteLine("Department Added!");
                            break;

                        case "2":
                            Console.Clear();
                            Console.Write("Enter Department Id: ");
                            int id = int.Parse(Console.ReadLine());

                            var dept = deptService.GetDepartment(id);
                            Console.WriteLine($"ID: {dept.ID}, Name: {dept.Name}, HiringDate: {dept.HiringDate}");
                            break;

                        case "3":
                            Console.Clear();
                            List<Department> allDepts = deptService.GetAllDepartment();
                            foreach (var d in allDepts)
                            {
                                Console.WriteLine($"ID: {d.ID}, Name: {d.Name}");
                            }
                            break;

                        case "4":
                            Console.Clear();
                            Console.Write("Enter Department Id to Update: ");
                            int updateId = int.Parse(Console.ReadLine());

                            Console.Write("Enter New Department Name: ");
                            var newName = Console.ReadLine();

                            var updatedDept = new Department
                            {
                                ID = updateId,
                                Name = newName
                            };

                            deptService.UpdateDepartment(updateId, updatedDept);
                            Console.WriteLine("Department Updated!");
                            break;

                        case "5":
                            Console.Clear();
                            Console.Write("Enter Department Id to Delete: ");
                            int deleteId = int.Parse(Console.ReadLine());

                            deptService.DeleteDepartment(deleteId);
                            Console.WriteLine("Department Deleted!");
                            break;

                        case "0":
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
