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
        public static void Move(State roverState, Point upperBound)
        {
            int movementSize = ApplicationConfigReader.RoverMovementSize;
            switch (roverState.Direction)
            {
                case DirectionEnum.Undefined:
                    break;
                case DirectionEnum.North:
                    if (roverState.Point.Y + movementSize >= 0 && roverState.Point.Y + movementSize <= upperBound.Y)
                        roverState.Point.Y += movementSize;
                    break;
                case DirectionEnum.East:
                    if (roverState.Point.X + movementSize >= 0 && roverState.Point.X + movementSize <= upperBound.X)
                        roverState.Point.X += movementSize;
                    break;
                case DirectionEnum.West:
                    if (roverState.Point.X - movementSize >= 0 && roverState.Point.X - movementSize <= upperBound.X)
                        roverState.Point.X -= movementSize;
                    break;
                case DirectionEnum.South:
                    if (roverState.Point.Y - movementSize >= 0 && roverState.Point.Y - movementSize <= upperBound.Y)
                        roverState.Point.Y -= movementSize;
                    break;
                default:
                    break;
            }
        }
    }
}
