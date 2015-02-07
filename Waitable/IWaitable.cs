using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJMcCann.Lib.Waitable
{
    public interface IWaitable
    {
        void OnCompleted(EventHandler<EventArgs> handler);
        void Completed(object sender, EventArgs e);
    }
}
