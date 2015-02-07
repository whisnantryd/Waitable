using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJMcCann.Lib.Waitable
{
    public abstract class Waitable : IWaitable, IWaitsOn
    {

        EventHandler<EventArgs> startHandler;

        EventHandler<EventArgs> completedHandler;

        List<IWaitable> waitablesList;

        public void OnStart(EventHandler<EventArgs> handler)
        {
            startHandler += handler;
        }

        #region IWaitable Members

        public void OnCompleted(EventHandler<EventArgs> handler)
        {
            completedHandler += handler;
        }

        public void Completed(object sender, EventArgs e)
        {
            completedHandler.Invoke(sender, e);
        }

        #endregion

        #region IWaitsOn Members

        public void WaitsOn(IWaitable waitable)
        {
            WaitsOn(new List<IWaitable> { waitable });
        }

        public void WaitsOn(List<IWaitable> waitables)
        {
            if (waitablesList == null) waitablesList = new List<IWaitable>();

            foreach (IWaitable member in waitables)
            {
                if (waitablesList.Contains(member) == false)
                {
                    waitablesList.Add(member);

                    member.OnCompleted((sender, e) =>
                    {
                        waitablesList.Remove(member);
                        if (waitablesList.Count == 0)
                        {
                            startHandler.Invoke(this, new EventArgs());
                        }
                    });
                }
            }
        }

        #endregion

    }
}
