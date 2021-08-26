using automailsorter.services.Scheduler;
using System;
using System.Threading.Tasks;

namespace automailsorter
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Scheduler scheduler = await Scheduler.InitialiseScheduler();
            Console.WriteLine("Hello World!");
        }
    }
}
