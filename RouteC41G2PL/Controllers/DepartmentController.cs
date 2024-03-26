using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Route.C41.G02.BLL.interfaces;
using RouteC41G2DAL.Models;
using System;

namespace RouteC41G2PL.Controllers
{
    public class DepartmentController : Controller
    {
        // inhertiance : Departmentcontroller is a controller

        //composition : Departmentcontroller has a DepartmentController

        private readonly IDepartmentRepository _departmentsRepo;
        private readonly IHostEnvironment _env;

        public DepartmentController(IDepartmentRepository departmentRepo, IHostEnvironment env)
        {
            _departmentsRepo = departmentRepo;/*new DepartmentRepository(new AppDbContext);*/
            _env = env;
        }




        // / Department / Index 
        public IActionResult Index()
        {
            var departments = _departmentsRepo.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server side Validation
            {
                var count = _departmentsRepo.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (!id.HasValue)

                return BadRequest();
            var department = _departmentsRepo.Get(id.Value);

            if (department == null)
                return NotFound();
            return View(ViewName, department);


        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {

            return Details(id, "Edit");



            ///if (!id.HasValue)

            //    return BadRequest();

            //var department = _departmentsRepo.Get(id.Value);

            //if (department == null)
            //    return NotFound();

            //return View(department);






        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            try
            {
                _departmentsRepo.Update(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occurred during Updating Department");

                return View(department);

            }

        }


        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Department department)
        {
            try
            {
                _departmentsRepo.Delete(department);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                    ModelState.AddModelError(string.Empty, "An Error Has Occurred during Deleting Department");

                return View(department);
            }





        }
    }
}
