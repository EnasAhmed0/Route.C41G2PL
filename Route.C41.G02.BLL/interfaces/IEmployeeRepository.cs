﻿using RouteC41G2DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.G02.BLL.interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();


        Employee Get(int id);

        int Add(Employee entity);

        int Update(Employee entity);

        int Delete(Employee entity);


    }
}
