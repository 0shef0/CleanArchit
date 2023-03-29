namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class Pagination
    {
        public Pagination(int count, int pagenumber, int pagesize)
        {
            PageNumber = pagenumber;
            TotalPages = (int)Math.Ceiling(count / (decimal)pagesize);
        }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPafe => PageNumber < TotalPages;
    }
}
