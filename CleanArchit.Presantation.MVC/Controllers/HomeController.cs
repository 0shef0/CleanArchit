using CleanArchit.Application.Interfases;
using CleanArchit.Domain.Models;
using CleanArchit.Infrastructure.Data.Context;
using CleanArchit.Presantation.MVC.Models;
using CleanArchit.Presantation.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using CleanArchit.Presantation.MVC.Models.Operations;

namespace CleanArchit.Presantation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;
        private readonly ICounter _counter;
        private readonly IWebHostEnvironment _environment;
      

        public HomeController(ILogger<HomeController> logger, IStudentService studentService, ICounter counter, IWebHostEnvironment environment)
        {
            _studentService= studentService;
            _logger = logger;
            _counter = counter;
            _environment = environment;
        }

        [HttpGet]


        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (student is not null)
            {
                _studentService.AddStudent(student);
                _counter.AddCount();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student student = _studentService.SearchStudentById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetailStudent(int id)
        {
            if(id != null)
            {
                var student = _studentService.SearchStudentById(id);
                if(student != null)
                {
                    return View(student);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveStudentById(int id)
        {
            _studentService.RemoveStudentById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            string filename = file.FileName;
            using (var fileStream = new FileStream(Path.Combine(_environment.WebRootPath, "images", filename), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", filename);
            return View();
            // return RedirectToAction("Index");
        }
        public IActionResult Index(int mark, int page = 1, SortState sortState = SortState.NameAsc)
        {
            const int pageSizeElement = 9;
            var viewStudent = _studentService.GetViewStudents();

            //filter
            if(mark != 0)
            {
                viewStudent.Students = viewStudent.Students.Where(s => s.Mark == mark);
            }

            //sort
            viewStudent.Students = sortState switch
            {
                SortState.NameDesc => viewStudent.Students.OrderByDescending(s => s.Name),
                SortState.NameAsc => viewStudent.Students.OrderBy(s => s.Name),
                SortState.DateDesc => viewStudent.Students.OrderByDescending(s => s.DateOfBirth),
                SortState.DateAsc => viewStudent.Students.OrderBy(s => s.DateOfBirth),
                SortState.MarkDesc => viewStudent.Students.OrderByDescending(s => s.Mark),
                SortState.MarkAsc => viewStudent.Students.OrderBy(s => s.Mark),
                SortState.IdDesc => viewStudent.Students.OrderByDescending(s => s.Id),
                _ => viewStudent.Students.OrderBy(s => s.Id),
            };

            //pagination
            var count = viewStudent.Students.Count();
            var items = viewStudent.Students.Skip((page - 1) * pageSizeElement).Take(pageSizeElement).ToList();

            IndexViewModel indexViewModel = new IndexViewModel(items,
                new Sort(sortState),
                new Filter(items, mark),
                new Pagination(count, page, pageSizeElement));


            HttpContext.Session.SetString("ProjectName", "CleanArchit");
            


            _counter.AddCount();
            ViewBag.Count = _counter.GetCount();
            
            return View(indexViewModel);
           
        }

        public IActionResult Privacy()
        {
            ViewData["ProjectName"] = HttpContext.Session.GetString("ProjectName");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}