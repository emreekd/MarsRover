using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base
{
    /// <summary>
    /// Context object for managing state of a Rover
    /// </summary>
    public class RoverContext
    {
        private State RoverState;
        public RoverContext()
        {
            RoverState = null;
        }
        /// <summary>
        /// Sets the Rover's current state
        /// </summary>
        /// <param name="state">Desired state to place rover</param>
        public void SetRoverState(State state)
        {
            RoverState = state;
        }
        /// <summary>
        /// Returns the Rover's current state
        /// </summary>
        /// <returns>Rover's current state</returns>
        public State GetRoverState()
        {
            return RoverState;
        }
    }
}
