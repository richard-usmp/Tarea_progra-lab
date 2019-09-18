using System;
using Microsoft.AspNetCore.Mvc;
using PrograLabPC1.Models;
using System.Linq;

namespace PrograLabPC1.Controllers
{

    public class HomeController:Controller{

        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(){
            Console.WriteLine("Index");
            return View(_context.Student.ToList());
        }
        public IActionResult Create(){
            Console.WriteLine("Create");
            return View();
        }
        
        [HttpPost]
        public IActionResult Registro(Student stu){
            Console.WriteLine("Registro"); 
            Random rnd = new Random(); 
            stu.Edad=DateTime.Now.Year - stu.Date.Year;
            //calculo total 
            if(stu.Curso.Equals("Matematica")){
                stu.Credito=4;               
            }else if(stu.Curso.Equals("Lenguaje")){
                stu.Credito=5;
            }else if(stu.Curso.Equals("Fisica")){
                stu.Credito=6;
            }

            stu.TotalPagar=stu.Credito*100;

            //aleatorio
            stu.Id = rnd.Next(10000000, 99999999);
            _context.Add(stu);
            _context.SaveChanges();
            return View(stu);
        }

        public IActionResult detail(int? id){
            Console.WriteLine("detail");
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Student
                .SingleOrDefault(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
    

}