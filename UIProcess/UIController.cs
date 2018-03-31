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
        private Instruction[] _instructions;
        public Instruction[] Instructions
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
        #endregion

        #region User Interactions
        /// <summary>
        /// Get upper bound of space from user
        /// </summary>
        /// <returns>Space's upper bound point</returns>
        public Point PromptUpperGridBounds()
        {
            string output;
            if (ApplicationConfigReader.InstructionsEnabled)
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetUpperCoordinate).Message);
                output = Console.ReadLine();
                while (!Regex.IsMatch(output, RegexConstants.CoordinatePointRegex))
                {
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.ErrorFirstFormat).Message);
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetUpperCoordinate).Message);
                    output = Console.ReadLine();
                }
                var coordinates = output.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
                return new Point(coordinates[0], coordinates[1]);
            }
            else
            {
                output = Console.ReadLine();
                while (!Regex.IsMatch(output, RegexConstants.CoordinatePointRegex))
                {
                    output = Console.ReadLine();
                }
                var coordinates = output.Split(' ').Select(p => Convert.ToInt32(p)).ToArray();
                return new Point(coordinates[0], coordinates[1]);
            }
        }
        /// <summary>
        /// Get initial co-ordinate point and direction of rover
        /// </summary>
        /// <returns>State of rover which contains co-ordinate point and direction</returns>
        public State PromptRoverInitalState()
        {
            string output;
            if (ApplicationConfigReader.InstructionsEnabled)
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetInitialState).Message);
                output = Console.ReadLine();
                while (!Regex.IsMatch(output, RegexConstants.RoverInitialPointRegex))
                {
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.ErrorFirstFormat).Message);
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetInitialState).Message);
                    output = Console.ReadLine();
                }
                var stateInformations = output.Split(' ').Select(p => p.ToString()).ToArray();
                var coordinates = new Point(Convert.ToInt32(stateInformations[0]), Convert.ToInt32(stateInformations[1]));
                return new State { Point = coordinates, Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), stateInformations[2].ToUpper()) };
            }
            else
            {
                output = Console.ReadLine();
                while (!Regex.IsMatch(output, RegexConstants.RoverInitialPointRegex))
                {
                    output = Console.ReadLine();
                }
                var stateInformations = output.Split(' ').Select(p => p.ToString()).ToArray();
                var coordinates = new Point(Convert.ToInt32(stateInformations[0]), Convert.ToInt32(stateInformations[1]));
                return new State { Point = coordinates, Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), stateInformations[2]) };
            }
        }
        /// <summary>
        /// Gets the instructions which is followed by the rover
        /// </summary>
        /// <returns></returns>
        public Signal[] PromptRoverSignals()
        {
            string output;
            if (ApplicationConfigReader.InstructionsEnabled)
            {
                Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetRoverSignals).Message);
                output = Console.ReadLine();
                while (!Regex.IsMatch(output, RegexConstants.RoverInstructionRegex))
                {
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.ErrorFirstFormat).Message);
                    Console.WriteLine(Instructions.First(k => k.Key == InstructionConstants.GetRoverSignals).Message);
                    output = Console.ReadLine();
                }
                var signals = output.ToCharArray().Select(k => IdentifyInstruction(k)).ToArray();
                return signals;
            }
            else 
            {
                output = Console.ReadLine();
                while (!Regex.IsMatch(output, RegexConstants.RoverInstructionRegex))
                {
                    output = Console.ReadLine();
                }
                var signals = output.ToCharArray().Select(k => IdentifyInstruction(k)).ToArray();
                return signals;   
            }
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
