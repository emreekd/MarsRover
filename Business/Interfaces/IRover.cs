using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// A protocal for a rover
    /// Each rover has an ability to process a list of signals
    /// </summary>
    public interface IRover
    {
        void ProcessSignal(List<Signal> signals);
    }
}
