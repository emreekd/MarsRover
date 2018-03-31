using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Common.Models
{
    /// <summary>
    /// Object that describes point on co-ordinate system
    /// </summary>
    public class Point 
    {
        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    /// <summary>
    /// Obhect that describes instruction which taken by the user
    /// </summary>
    public class Signal
    {
        public SignalTypeEnum SignalType { get; set; }
        public DirectionEnum Direction { get; set; }
    }
    /// <summary>
    /// Object that describes state of a rover
    /// </summary>
    public class State
    {
        public Point Point { get; set; }
        public DirectionEnum Direction { get; set; }
    }
    /// <summary>
    /// Object that is a wrapper for set of instructions
    /// </summary>
    public class InstructionContext
    {
        public Instruction[] Instructions { get; set; }
    }
    /// <summary>
    /// Object that describes an instruction for a prompt
    /// </summary>
    public class Instruction
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
