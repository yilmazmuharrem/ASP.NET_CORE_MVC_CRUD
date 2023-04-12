using CRUD_MVC.Data;
using CRUD_MVC.Models;
using CRUD_MVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonDbContext _personDbContext;
        public PersonController(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext; 
        }


        [HttpGet]


        public async Task <IActionResult> Index()
        {
          var persons = await  _personDbContext.Employees.ToListAsync();
            return View(persons);
        }

        [HttpGet]

        public async Task<IActionResult> View(Guid id)
        {

          var person = await _personDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (person != null)
            {
                var viewModel = new UpdatePersonViewModel()
                {

                    Id = person.Id,
                    Name = person.Name,
                    Email = person.Email,
                    Salary = person.Salary,
                    Departmen = person.Departmen


                };
                return await Task.Run( () =>View("View",viewModel));
            }

            return RedirectToAction("Index");



            return View();
        }


        [HttpPost]

        public async Task<IActionResult> View(UpdatePersonViewModel model)
        {
            var person = await _personDbContext.Employees.FindAsync(model.Id);

            if (person != null)
            {
                person.Name = model.Name;
                person.Email = model.Email;
                person.Salary = model.Salary;
                person.Departmen = model.Departmen;


                await _personDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


       [HttpPost] 
        public async Task<IActionResult> Add(AddPersonViewModel addPerson)
        {

            

            var person = new Person()
            {

                Id = Guid.NewGuid(),
                Name = addPerson.Name,
                Email = addPerson.Email,
                Salary = addPerson.Salary,
              //  DateOfBirth = addPerson.DateOfBirth,
                Departmen = addPerson.Departmen,
            };
            await _personDbContext.Employees.AddAsync(person);
           await _personDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }


        [HttpPost]

        public async Task<IActionResult> Delete(UpdatePersonViewModel model)
        {
            var person = await _personDbContext.Employees.FindAsync(model.Id);

            if (person != null)
            {
                _personDbContext.Employees.Remove(person);

                await _personDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
