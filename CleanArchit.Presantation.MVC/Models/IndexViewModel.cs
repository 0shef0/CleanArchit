using CleanArchit.Domain.Models;
using CleanArchit.Presantation.MVC.Models.Operations;

namespace CleanArchit.Presantation.MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Student> Students { get; }
        public Sort Sort { get; }
        public Filter Filter { get; }
        public Pagination Pagination { get; }

        public IndexViewModel(IEnumerable<Student> students, Sort sort, Filter filter, Pagination pagination)
        {
            Students = students;
            Sort = sort;
            Filter = filter;
            Pagination = pagination;
        }
    }
}
