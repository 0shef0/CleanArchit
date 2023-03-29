using CleanArchit.Domain.Models;

namespace CleanArchit.Domain.Intarfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        void AddStudent(Student student);
        void RemoveStudentById (int id);
        void RemoveStudentByName(string name);
        Student SearchStudentById(int id);
        IEnumerable<Student> SearchStudentByName(string name);
        bool UpdateStudent(Student student);
    }
}