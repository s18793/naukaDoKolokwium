using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using naukaKolokwiumAPDB.DTOs;
using naukaKolokwiumAPDB.Models;

namespace naukaKolokwiumAPDB.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetAnimals(string sortBy)
        {



            var list = new List<Animal>();
            using (SqlConnection con = new SqlConnection("Data Source = db-mssql; Initial Catalog=s18793; Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                if (sortBy == null) sortBy = "AdmissionDate";
              //  com.Parameters.AddWithValue("sortby", sortBy);
                com.CommandText = $"Select * from Animal order by {sortBy}";
                // com.Parameters.AddWithValue("sortby", sortBy);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        var ani = new Animal();

                        ani.IdAnimal = (int)dr["IdAnimal"];
                        ani.Name = dr["Name"].ToString();
                        ani.Type = dr["Type"].ToString();
                        ani.AdmissionDate = DateTime.Parse(dr["AdmissionDate"].ToString());
                        ani.IdOwner = (int)dr["IdOwner"];
                        list.Add(ani);
                    }


                    return Ok(list);
                }
                catch (SqlException sql)
                {
                    return BadRequest("Nie prawidłowy parametr");
                }

                


            }





        }



        [HttpPost]

        public IActionResult AddAnimal(AnimalRequest animalRequest)
        {
            using (SqlConnection con = new SqlConnection("Data Source = db-mssql; Initial Catalog=s18793; Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                //var ani = new Animal();
                con.Open();
               
                com.CommandText = "Insert Into Animal (Name, Type, AdmissionDate, IdOwner) Values (@name, @type, @date, @idowner)";
                
                com.Parameters.AddWithValue("name", animalRequest.Name);
                com.Parameters.AddWithValue("type", animalRequest.Type);
                com.Parameters.AddWithValue("date", animalRequest.AdmissionDate);
                com.Parameters.AddWithValue("idowner", animalRequest.IdOwner);
               
                com.ExecuteNonQuery();
                return Ok();//404
             }
        }
    }
}