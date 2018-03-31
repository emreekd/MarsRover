using Business.Base;
using Common.Models;
using SignalProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Wrapper for rover objects
    /// Rovers process instructions and investigate the given area in mars
    /// </summary>
    public class Rover : BaseRover
    {
        public Rover(State initialState)
            : base(initialState)
        {

        }
        /// <summary>
        /// Changes the state of rover according to given signals
        /// </summary>
        /// <param name="signals"></param>
        public override void ProcessSignal(List<Signal> signals)
        {
            RoverSignalProcesor procesor = new RoverSignalProcesor(signals);
            var currentState = this.Context.GetRoverState();
            procesor.ProcessSignal(currentState);                              //process signals and change current state
            Context.SetRoverState(currentState);                               //set rover state
        }
    }
}
