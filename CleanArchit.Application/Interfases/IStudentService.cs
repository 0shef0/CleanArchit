using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Models;

namespace CleanArchit.Application.Interfases
{
    public interface IStudentService
    {
        public ViewStudentModel GetViewStudents();
        public void AddStudent(Student student);
        public void RemoveStudentById(int id);
        public void RemoveStudentByName(string name);
        public Student SearchStudentById(int id);
        public ViewStudentModel SearchStudentByName(string name);
        public bool UpdateStudent(Student student);
    }
}
