using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using naukaKolokwiumAPDB.Models;
using naukaKolokwiumAPDB.Services;

namespace naukaKolokwiumAPDB.Controllers
{
    [Route("api/students")]
    [ApiController]
    
    public class StudentsController : ControllerBase
    {

        /*
       private IDbService _dbService;
        
         public StudentsController(IDbService service)
         {
      
            _dbService = service;
         }
        [HttpGet]
        public IActionResult GetStudents(string orderby)
        {

            if (orderby == "LastName")
            {
                return Ok(_dbService.GetStudents().OrderBy(s => s.LastName));
            }

            return Ok(_dbService.GetStudents());
        }
       
        */
        [HttpGet]
        public IActionResult GetStundets()
        {


            using (SqlConnection con = new SqlConnection("Data Source = db-mssql; Initial Catalog=s18793; Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * from Students";
            }




                return Ok();
        }


        /*
        //3 body- cialo zadan
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            //..

            return Ok(student);
        }

    */
    }
}