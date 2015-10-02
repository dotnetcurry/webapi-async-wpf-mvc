using System.Collections.Generic;
using System.Linq;
using APIService.Models;

using Microsoft.Practices.Unity;

namespace APIService.DataAccessRepository
{
    public class clsDataAccessRepository : IDataAccessRepository<EmployeeInfo, int>
    {
        //The dendency for the DbContext specified the current class. 
        [Dependency]
        public ApplicationEntities ctx { get; set; }

        //Get all Employees
        public IEnumerable<EmployeeInfo> Get()
        {
            return ctx.EmployeeInfoes.ToList();
        }
        //Get Specific Employee based on Id
        public EmployeeInfo Get(int id)
        {
            return ctx.EmployeeInfoes.Find(id);
        }

        //Create a new Employee
        public void Post(EmployeeInfo entity)
        {
            ctx.EmployeeInfoes.Add(entity);
            ctx.SaveChanges();
        }
        //Update Exisitng Employee
        public void Put(int id, EmployeeInfo entity)
        {
            var Emp = ctx.EmployeeInfoes.Find(id);
            if (Emp != null)
            {
                Emp.EmpName = entity.EmpName;
                Emp.Salary = entity.Salary;
                Emp.DeptName = entity.DeptName;
                Emp.Designation = entity.Designation;
                ctx.SaveChanges();
            }
        }
        //Delete an Employee based on Id
        public void Delete(int  id)
        {
            var Emp = ctx.EmployeeInfoes.Find(id);
            if (Emp != null)
            {
                ctx.EmployeeInfoes.Remove(Emp);
                ctx.SaveChanges();
            }
        }
    }
}