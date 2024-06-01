using CRUD_API.IServices;
using CRUD_API.Models;

namespace CRUD_API.Services
{
    public class StudentServices : IStudentServices
    {
        AppDbContext _context;
        public StudentServices()
        {
            _context = new AppDbContext();
        }
        public bool CreateStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteStudent(string id)
        {
            try
            {
                var deleteItem = _context.Students.Find(id);
                _context.Students.Remove(deleteItem);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(string id)
        {
            return _context.Students.Find(id);
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                var updateItem = _context.Students.Find(student.Id);
                updateItem.Name = student.Name;
                updateItem.Major = student.Major;
                // Còn nữa
                _context.Students.Update(updateItem);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
