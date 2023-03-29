using CleanArchit.Application.Interfases;
using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;

namespace CleanArchit.Application.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        } 
        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public ViewStudentModel GetViewStudents()
        {
            return new ViewStudentModel
            {
                Students = _studentRepository.GetStudents()
            };
        }

        public void RemoveStudentById(int id)
        {
            _studentRepository.RemoveStudentById(id);
        }

        public void RemoveStudentByName(string name)
        {
            _studentRepository.RemoveStudentByName(name);
        }

        public Student SearchStudentById(int id)
        {
            return _studentRepository.SearchStudentById(id);
        }

        public ViewStudentModel SearchStudentByName(string name)
        {
            return new ViewStudentModel
            {
                Students = _studentRepository.SearchStudentByName(name)
            };
        }

        public bool UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }
    }
}
