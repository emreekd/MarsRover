using Common.Enums;
using Common.Models;
using ConfigurationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcess.Helpers
{
    /// <summary>
    /// A helper object for moving rovers
    /// </summary>
    public static class MovementHelper
    {
        /// <summary>
        /// Gets the rover's current state and changes the position on co-ordinate system
        /// </summary>
        /// <param name="roverState">Rover's current state</param>
        public static void Move(State roverState) 
        {
            int movementSize = ApplicationConfigReader.RoverMovementSize;
            switch (roverState.Direction)
            {
                case DirectionEnum.Undefined:
                    break;
                case DirectionEnum.North:
                    roverState.Point.Y += movementSize;
                    break;
                case DirectionEnum.East:
                    roverState.Point.X += movementSize;
                    break;
                case DirectionEnum.West:
                    roverState.Point.X -= movementSize;
                    break;
                case DirectionEnum.South:
                    roverState.Point.Y -= movementSize;
                    break;
                default:
                    break;
            }
        }
    }
}
