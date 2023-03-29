namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class Sort
    {
        public Sort(SortState sortState) 
        {
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DateSort = sortState == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
            MarkSort = sortState == SortState.MarkAsc ? SortState.MarkDesc : SortState.MarkAsc;
            IdSort = sortState == SortState.IdAsc? SortState.IdDesc : SortState.IdAsc;
            Current = sortState;
        }

        public SortState NameSort { get; }
        public SortState DateSort { get; }
        public SortState MarkSort { get; }
        public SortState IdSort { get; }
        public SortState Current { get; }
    }
}
