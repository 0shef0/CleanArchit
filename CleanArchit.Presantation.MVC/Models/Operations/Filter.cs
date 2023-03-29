using CleanArchit.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class Filter
    {
        public Filter(List<Student> students, int mark) 
        {
            Students = new SelectList(students, "Id", "Mark");

            SelectedStudent = mark;
        }

        public SelectList Students { get; }

        public int SelectedStudent { get; }
    }
}
