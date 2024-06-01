using CRUD_API.Models;

namespace CRUD_API.IServices
{
    public interface IStudentServices
    {
        public List<Student> GetAll();
        public Student GetById(string id);
        public bool CreateStudent(Student student);
        public bool UpdateStudent(Student student);
        public bool DeleteStudent(string id);
    }
}
