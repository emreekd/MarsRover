using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    /// <summary>
    /// Enum type which describes the directions on co-ordinate system
    /// </summary>
    public enum DirectionEnum
    {
        Undefined = 0,
        North = 1,
        N = 1,
        East = 2,
        E = 2,
        West = 3,
        W = 3,
        South = 4,
        S = 4
    }
    /// <summary>
    /// Enum type which describes the instructions
    /// </summary>
    public enum SignalTypeEnum
    {
        Undefined = 0,
        Left = 1,
        L = 1,
        Right = 2,
        R = 2,
        Move = 3,
        M = 3
    }
}
