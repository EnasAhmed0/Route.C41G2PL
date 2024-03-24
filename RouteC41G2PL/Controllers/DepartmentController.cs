using Microsoft.AspNetCore.Mvc;
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

        public DepartmentController(IDepartmentRepository departmentRepo)
        {
            _departmentsRepo = departmentRepo;/*new DepartmentRepository(new AppDbContext);*/
        }




        // / Department / Index 
        public IActionResult Index()
        {
            var departments = _departmentsRepo.GetAll();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Department depaartment)
        {
            if (ModelState.IsValid) // Server side Validation
            {
                var count =_departmentsRepo.Add(depaartment);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));   
                }
            }
            return View(depaartment);
        }
        [HttpGet]

        public IActionResult Details(int? id , string ViewName= "Details")
        {
            if (!id.HasValue)
                
            return BadRequest();
            var department = _departmentsRepo.Get(id.Value);

            if (department == null)
                return NotFound();
            return View( ViewName,department);


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
        public IActionResult Edit(Department department)
        {
            if(ModelState.IsValid)
            {

            }
        }







    }
}
