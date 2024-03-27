using Microsoft.EntityFrameworkCore;
using Route.C41.G02.BLL.interfaces;
using RouteC41G2DAL.Data;
using RouteC41G2DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.G02.BLL.Repositoies
{
    public class EmployeeRepository : IEmployeeRepository
    {
       
        
            private readonly ApplicationDbContext _dbcontext;

            public EmployeeRepository(ApplicationDbContext dbContext)
            {
                _dbcontext = dbContext;
            }

            public int Add(Employee entity)
            {
                _dbcontext.Employees.Add(entity);
                return _dbcontext.SaveChanges();
            }
            public int Update(Employee entity)
            {
                _dbcontext.Employees.Update(entity);
                return _dbcontext.SaveChanges();
            }

            public int Delete(Employee entity)
            {
                _dbcontext.Employees.Remove(entity);
                return _dbcontext.SaveChanges();
            }

            public Employee Get(int id)
            {
                // return _dbcontext.Employees.Find(id);
                return _dbcontext.Find<Employee>(id);

                ///var Employee = _dbcontext.Employees.Where(D => D.Id == id).FirstOrDefault();
                // return Employee;
            }

            public IEnumerable<Employee> GetAll()
            {
                return _dbcontext.Employees.AsNoTracking().ToList();
            }

    }
}
