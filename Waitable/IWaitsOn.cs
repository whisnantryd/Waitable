using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJMcCann.Lib.Waitable
{
    public interface IWaitsOn
    {
        void WaitsOn(IWaitable waitable);
        void WaitsOn(List<IWaitable> waitables);
    }
}
