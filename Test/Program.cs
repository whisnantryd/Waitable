using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJMcCann.Lib.Waitable;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            
            Console.WriteLine("Started at " + startTime.ToString("mm\\:ss\\.fff"));

            var obj1 = new ToWaitOn(TimeSpan.FromSeconds(5));
            var obj2 = new ToWaitOn(TimeSpan.FromSeconds(2), new List<IWaitable> { obj1 });
            var obj3 = new ToWaitOn(TimeSpan.FromSeconds(5), new List<IWaitable> { obj1, obj2 });

            obj3.OnCompleted((sender, e) =>
            {
                var finishTime = DateTime.Now;
                Console.WriteLine("Finished at " + finishTime.ToString("mm\\:ss\\.fff"));
                Console.WriteLine("Diff " + finishTime.Subtract(startTime).TotalSeconds + " seconds");
            });

            var c = Console.ReadLine();
        }
    }
}
