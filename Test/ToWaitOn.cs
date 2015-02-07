using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NJMcCann.Lib.Waitable;

namespace Test
{
    public class ToWaitOn : NJMcCann.Lib.Waitable.Waitable
    {

        public ToWaitOn(TimeSpan timeToCompletion)
        {
            // we wait on nothing
            doWork(timeToCompletion);
        }

        public ToWaitOn(TimeSpan timeToCompletion, List<IWaitable> waiton)
        {
            WaitsOn(waiton);
            OnStart((sender, e) =>
            {
                doWork(timeToCompletion);
            });
        }

        private void doWork(TimeSpan timeout)
        {
            var timer = new Timer(timeout.TotalMilliseconds);
            timer.Elapsed += (obj, e) =>
            {
                this.Completed(this, new EventArgs());
                timer.Stop();
                timer.Dispose();
                timer = null;
            };

            timer.Start();
        }

    }
}
