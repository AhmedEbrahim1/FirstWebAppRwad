namespace FirstWebAppRwad.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }

    public static class StudentList
    {
        public static List<Student> Students { get; set; }
        = new List<Student>()
        {
               new Student(){Id=1,Name="Ahmed",Address="Cairo",Image="1.jpg"},
                new Student(){Id=2,Name="Ibrahim",Address="alex",Image="1.jpg"},
                new Student(){Id=3,Name="Ali",Address="mansoura",Image="1.jpg"},
                new Student(){Id=4,Name="Mona",Address="Cairo",Image="2.jpg"},
                new Student(){Id=5,Name="Esraa",Address="Cairo",Image="2.jpg"},
                new Student(){Id=6,Name="Nora",Address="Cairo",Image="2.jpg"},

        };

       
    }
}
