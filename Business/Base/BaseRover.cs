using Business.Interfaces;
using Common.Models;
using SignalProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base
{
    /// <summary>
    /// Base object for Rover
    /// Each rover must have a context and definition for signal processing
    /// </summary>
    public abstract class BaseRover : IRover
    {
        public RoverContext Context { get; set; }
        public BaseRover(State initialState,Point upperBound)
        {
            this.Context = new RoverContext();
            this.Context.SetRoverState(initialState);
            this.Context.UpperBound = upperBound;
        }
        /// <summary>
        /// Process given signals and make Rover work
        /// </summary>
        /// <param name="signals"></param>
        public abstract void ProcessSignal(List<Signal> signals);
    }
}
