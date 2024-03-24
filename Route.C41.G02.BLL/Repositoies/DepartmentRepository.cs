using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public class DepartmentRepository :IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public DepartmentRepository (ApplicationDbContext dbContext)
        {
          _dbcontext = dbContext;
        }
 
        public int Add(Department entity)
        {
            _dbcontext.Departments.Add(entity);
            return _dbcontext.SaveChanges();
        }
        public int Update(Department entity)
        {
            _dbcontext.Departments.Update(entity);
            return _dbcontext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbcontext.Departments.Remove(entity);
            return _dbcontext.SaveChanges();
        }

        public Department Get(int id)
        {
           // return _dbcontext.Departments.Find(id);
           return _dbcontext.Find<Department>(id);

          ///var department = _dbcontext.Departments.Where(D => D.Id == id).FirstOrDefault();
            // return department;
        }

        public IEnumerable<Department> GetAll()
       =>  _dbcontext.Departments.AsNoTracking().ToList();


    }

        
    
}
