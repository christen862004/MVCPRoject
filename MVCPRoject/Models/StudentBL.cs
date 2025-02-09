namespace MVCPRoject.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { ID=1,Name="Ahmed",ImageURl="m.png",Address="Alex"});
            students.Add(new Student() { ID=2,Name="Esraa",ImageURl="2.jpg",Address="Cairo"});
            students.Add(new Student() { ID=3,Name="Sara",ImageURl="2.jpg",Address="Cairo"});
            students.Add(new Student() { ID=4,Name="Waleed",ImageURl="m.png",Address="Cairo"});
        }
        public List<Student> GetAll() {
            return students;
        }

        public Student GetByID(int id)
        {
            return students.FirstOrDefault(e => e.ID == id);
        }
    }
}
