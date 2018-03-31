using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Wrapper for user prompt constants
    /// </summary>
    public class InstructionConstants
    {
        public static readonly string GetUpperCoordinate = "GetUpperCoordinate";
        public static readonly string GetInitialState = "GetInitialState";
        public static readonly string ErrorFirstFormat = "ErrorFirstFormat";
        public static readonly string GetRoverSignals = "GetRoverSignals";
        public static readonly string AskUpperBounds = "AskUpperBounds";
        public static readonly string AskInitialState = "AskInitialState";
        public static readonly string AskInstructions = "AskInstructions";
        public static readonly string GetInitialStateOthers = "GetInitialStateOthers";
        public static readonly string BoundExceedError = "BoundExceedError";
    }
}
