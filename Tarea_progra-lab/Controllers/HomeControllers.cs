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
            return View();
        }
        
        [HttpPost]
        public IActionResult calculo(Student stu){
            Console.WriteLine("Calculo");  
            Random rnd = new Random(); 
            String curso=stu.Curso;  
            stu.Edad=DateTime.Now.Year - stu.Date.Year;
            
            //calculo total 
            if(curso.Equals("c1")){
                stu.Credito=4;
            }else if(curso.Equals("c2")){
                stu.Credito=5;
            }else if(curso.Equals("c3")){
                stu.Credito=6;
            }

            stu.TotalPagar=stu.Credito*100;

            //aleatorio
            stu.Id = rnd.Next(10000000, 99999999);
            
            _context.Add(stu);
            _context.SaveChanges();
            return View(stu);
        }

        public IActionResult details(){
            return View();
        }
    }
    

}