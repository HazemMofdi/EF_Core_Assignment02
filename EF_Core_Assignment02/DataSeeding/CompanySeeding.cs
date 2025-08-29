using EF_Core_Assignment02.DataAccess;
using EF_Core_Assignment02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EF_Core_Assignment02.DataSeeding
{
    public static class CompanySeeding
    {
        public static void DataSeeding(AppDbContext db)
        {
            try
            {
                #region Seeding Departments
                if(!db.Departments.Any())
                {
                    var DepartmentsData = File.ReadAllText("Files\\departments.json");
                    var Departments = JsonSerializer.Deserialize<List<Department>>(DepartmentsData);
                    if(Departments?.Count > 0)
                    {
                        db.AddRange(Departments);
                        db.SaveChanges();
                        Console.WriteLine("Departments Has Been Seeded!");
                    }
                    else
                    {
                        Console.WriteLine("File Is Empty No Data To Seed");
                    }
                }
                #endregion


                #region Seeding Instructors
                if(!db.Instructors.Any())
                {
                    var InstructorsData = File.ReadAllText("Files\\employees.json");
                    var Instructors = JsonSerializer.Deserialize<List<Instructor>>(InstructorsData);
                    if(Instructors?.Count > 0)
                    {
                        db.AddRange(Instructors);
                        db.SaveChanges();
                        Console.WriteLine("Instructors Has Been Seeded!");
                    }
                    else
                    {
                        Console.WriteLine("File Is Empty No Data To Seed");
                    }
                }
                #endregion
            }
                
            catch(Exception ex)
            {
                Console.WriteLine("Error While Seeding Data!");
                Console.WriteLine($"Details: { ex.Message}");
            }
        }
    }
}
