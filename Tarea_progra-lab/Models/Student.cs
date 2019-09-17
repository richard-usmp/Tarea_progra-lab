using System;
using System.ComponentModel.DataAnnotations;

namespace PrograLabPC1.Models
{
    public class Student{
        [Key]
        public int Id{get; set;}
        
        //[Display(Name="Nombre")]
        public String Name {get; set;}
        [DataType(DataType.Date)]
        public DateTime Date {get; set;}
        public int Edad {get; set;}
        public String Hobbie {get; set;}
        public String Curso {get; set;}
        public int Credito {get; set;}
        public int TotalPagar{get; set;}
    }
}
