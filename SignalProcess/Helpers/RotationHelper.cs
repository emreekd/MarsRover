using Common.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcess.Helpers
{
    /// <summary>
    /// A Helper for rotating rover on the co-ordinate system
    /// </summary>
    public static class RotationHelper
    {
        /// <summary>
        /// Rotates roves on its axis according the given direction
        /// </summary>
        /// <param name="initialState">Rover's current state</param>
        /// <param name="signalType">Instruction to changing rotation</param>
        public static void RotateToGivenDirection(State initialState, SignalTypeEnum signalType) 
        {
            switch (signalType)
            {
                case SignalTypeEnum.Left:
                    if (initialState.Direction == DirectionEnum.East)
                        initialState.Direction = DirectionEnum.North;
                    else if (initialState.Direction == DirectionEnum.North)
                        initialState.Direction = DirectionEnum.West;
                    else if (initialState.Direction == DirectionEnum.West)
                        initialState.Direction = DirectionEnum.South;
                    else if (initialState.Direction == DirectionEnum.South)
                        initialState.Direction = DirectionEnum.East;
                    break;
                case SignalTypeEnum.Right:
                    if (initialState.Direction == DirectionEnum.East)
                        initialState.Direction = DirectionEnum.South;
                    else if (initialState.Direction == DirectionEnum.North)
                        initialState.Direction = DirectionEnum.East;
                    else if (initialState.Direction == DirectionEnum.West)
                        initialState.Direction = DirectionEnum.North;
                    else if (initialState.Direction == DirectionEnum.South)
                        initialState.Direction = DirectionEnum.West;
                    break;
                default:
                    break;
            }
        }
    }
}
