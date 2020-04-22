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

            var list = new List<Student>();
            using (SqlConnection con = new SqlConnection("Data Source = db-mssql; Initial Catalog=s18793; Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * from Student";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var st = new Student();
                   
                    st.IndexNumber =  dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    
                    list.Add(st);
                }





            }




                return Ok(list);

        }


        
        //3 body- cialo zadan
        [HttpGet("(indexNumber)")]
        public IActionResult GetStudent(string indexNumber)
        {

            using (SqlConnection con = new SqlConnection("Data Source = db-mssql; Initial Catalog=s18793; Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select * from Student where indexnumber = @index";
                com.Parameters.AddWithValue("index", indexNumber);
                con.Open();
                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var st = new Student();

                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();

                    return Ok(st);
                }





            }

            return NotFound(); 
        }

    
    }
}