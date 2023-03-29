using CleanArchit.Presantation.MVC.Services.Interfaces;

namespace CleanArchit.Presantation.MVC.Services.Services
{
    public class CounterStudentService : ICounter
    {
        private uint counter = 0;

        public void AddCount()
        {
            counter++;
        }

        public uint GetCount()
        {
            return counter;
        }
    }
}
