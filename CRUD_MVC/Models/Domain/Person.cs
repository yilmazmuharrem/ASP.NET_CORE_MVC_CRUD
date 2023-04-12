namespace CRUD_MVC.Models.Domain
{
    public class Person
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public long Salary { get; set; }

     //   public DateTimeKind DateOfBirth { get; set; }

        public string Departmen { get; set; }
    }
}
