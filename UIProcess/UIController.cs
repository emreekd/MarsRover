using Common;
using Common.Enums;
using Common.Models;
using ConfigurationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UIProcess
{
    /// <summary>
    /// A wrapper for state management
    /// </summary>
    public class UIController
    {
        /// <summary>
        /// Contructor of UI Controller
        /// Single instance provided with this approach
        /// </summary>
        #region Constructor
        private static readonly UIController instance = new UIController();

        static UIController()
        {

        }
        public UIController()
        {

        }
        public static UIController Current
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Instructions for user prompts
        /// </summary>
        private static Instruction[] _instructions;
        public static Instruction[] Instructions
        {
            get
            {
                if (_instructions == null)
                {
                    _instructions = ConfigurationSettingsReader.GetInstructions();
                }
                return _instructions;
            }
        }
        /// <summary>
        /// Control for first rover launched
        /// </summary>
        public static bool FirstRoverLaunched { get; set; }
        public static Point SpaceUpperBound { get; set; }
        #endregion

        #region User Interactions
        /// <summary>
        /// Get upper bound of space from user
        /// </summary>
        /// <returns>Space's upper bound point</returns>
        public void PromptUpperGridBounds()
        {
            string output;
            Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetUpperCoordinate).Message);
            output = Console.ReadLine();
            while (!Regex.IsMatch(output, RegexConstants.CoordinatePointRegex))
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.ErrorFirstFormat).Message);
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.AskUpperBounds).Message);
                output = Console.ReadLine();
            }
            var coordinates = output.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
            SpaceUpperBound = new Point(coordinates[0], coordinates[1]);
        }
        /// <summary>
        /// Get initial co-ordinate point and direction of rover
        /// </summary>
        /// <returns>State of rover which contains co-ordinate point and direction</returns>
        public State PromptRoverInitalState()
        {
            string output;
            string[] stateInformations = new string[3];
            Point coordinates = null;
            if (FirstRoverLaunched)
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetInitialStateOthers).Message);
            }
            else
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetInitialState).Message);
            }
            output = Console.ReadLine();
            stateInformations = output.Split(' ').Select(p => p.ToString()).ToArray();
            coordinates = new Point(Convert.ToInt32(stateInformations[0]), Convert.ToInt32(stateInformations[1]));
            while (!Regex.IsMatch(output, RegexConstants.RoverInitialPointRegex) || !IsInBound(coordinates))
            {
                if (!IsInBound(coordinates) && coordinates != null)
                {
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.BoundExceedError).Message);
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.AskInitialState).Message);
                }
                else if (coordinates != null && !Regex.IsMatch(output, RegexConstants.RoverInitialPointRegex))
                {
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.ErrorFirstFormat).Message);
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.AskInitialState).Message);
                }
                output = Console.ReadLine();
                stateInformations = output.Split(' ').Select(p => p.ToString()).ToArray();
                coordinates = new Point(Convert.ToInt32(stateInformations[0]), Convert.ToInt32(stateInformations[1]));
            }
            return new State { Point = coordinates, Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), stateInformations[2].ToUpper()) };
        }
        /// <summary>
        /// Checks whether given co-ordinate point 
        /// is in identified research area
        /// </summary>
        /// <param name="coordinates">Co-ordinate point</param>
        /// <returns>check result</returns>
        private bool IsInBound(Point coordinates)
        {
            if (coordinates == null)
            {
                return false;
            }
            else if (coordinates.X >= 0 && coordinates.X <= SpaceUpperBound.X && coordinates.Y >= 0 && coordinates.Y <= SpaceUpperBound.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the instructions which is followed by the rover
        /// </summary>
        /// <returns></returns>
        public Signal[] PromptRoverSignals()
        {
            string output;
            Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetRoverSignals).Message);
            output = Console.ReadLine();
            while (!Regex.IsMatch(output, RegexConstants.RoverInstructionRegex))
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.ErrorFirstFormat).Message);
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.AskInstructions).Message);
                output = Console.ReadLine();
            }
            var signals = output.ToCharArray().Select(k => IdentifyInstruction(k)).ToArray();
            return signals;
        }
        /// <summary>
        /// Identify the given char as a signal
        /// </summary>
        /// <param name="k">Instruction, expected inputs are L,R,M</param>
        /// <returns>A signal which contains information about the given instruction</returns>
        private Signal IdentifyInstruction(char k)
        {
            return new Signal { SignalType = (SignalTypeEnum)Enum.Parse(typeof(SignalTypeEnum), k.ToString().ToUpper()) };
        }
        #endregion
    }
}
