using naukaKolokwiumAPDB.Models;

using System.Collections.Generic;


namespace naukaKolokwiumAPDB.Services
{
    public class MockDbService : IDbService
    {

        private static IEnumerable<Student> _students = new List<Student>
        {
            new Student{IdStudent=1, FirstName="Jan", LastName="Kowal",IndexNumber="s123"},
            new Student{IdStudent=2, FirstName="Pawel", LastName="Szczebi",IndexNumber="s234"},
            new Student{IdStudent=3, FirstName="Ola", LastName="Gono",IndexNumber="s135"}
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
