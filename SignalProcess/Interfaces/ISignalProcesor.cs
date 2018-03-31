using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcess.Interfaces
{
    /// <summary>
    /// A protocal for signal procesor objects
    /// </summary>
    public interface ISignalProcesor
    {
        void ProcessSignal(State state);
    }
}
