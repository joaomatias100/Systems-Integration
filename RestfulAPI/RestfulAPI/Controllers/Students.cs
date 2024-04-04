namespace RestfulAPI.Controllers
{
    internal class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string course { get; set; }

        public Student()
        {
            id = 0;
            name = string.Empty;
            course = string.Empty;
        }

    }
}