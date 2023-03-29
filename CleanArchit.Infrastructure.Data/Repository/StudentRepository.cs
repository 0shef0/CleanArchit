using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;
using CleanArchit.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Infrastructure.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDBContext _context;
        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        public void RemoveStudentById(int id)
        {
            Student student = (from students in _context.Students
                              where students.Id.Equals(id)
                              select students).First();
            if (student is not null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void RemoveStudentByName(string name)
        {
            Student student = (from students in _context.Students
                                        where students.Name.Equals(name)
                                        select students).First();
            if (student is not null)
            {
                _context.Students.Remove(student);
            }
        }

        public Student SearchStudentById(int id)
        {
            return _context.Students.FirstOrDefault(student => student.Id == id);
        }

        public IEnumerable<Student> SearchStudentByName(string name)
        {
            return from students in _context.Students
                             where students.Name.Equals(name)
                             select students;
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
