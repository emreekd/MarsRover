using Common.Models;
using SignalProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcess.Base
{
    /// <summary>
    /// Base class for calculating the given instructions
    /// </summary>
    public abstract class BaseSignalProcesor : ISignalProcesor
    {
        public List<Signal> SignalList { get; set; }    // List of instructions
        public BaseSignalProcesor(List<Signal> signals) // Constructor that takes the instructor
        {
            this.SignalList = signals;
        }
        public abstract void ProcessSignal(State state, Point upperBound); // Process signal
    }
}
