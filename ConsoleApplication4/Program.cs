using Business;
using Common.Enums;
using Common.Models;
using ConfigurationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIProcess;

namespace ConsoleApplication4
{
    /// <summary>
    /// A console application for rover management
    /// </summary>
    class Program
    {
        /// <summary>
        /// Everything starts from here
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Rover[] rovers = new Rover[ApplicationConfigReader.RoverSize];              // Arrange Rovers for mission
            UIController.Current.PromptUpperGridBounds();        // Arrange upper bound for research area
            for (int i = 0; i < rovers.Length; i++)
            {
                var roverInitialState = UIController.Current.PromptRoverInitalState();  // Place rover on the selected are at Mars
                var signals = UIController.Current.PromptRoverSignals().ToList();       // Get instructions for rover
                Rover rover = new Rover(roverInitialState);                             // Start rover engine
                rover.ProcessSignal(signals);                                           // Run rover!! Investigate the area
                rovers[i] = rover;                                                      // Park the rover and save results 
                if (i == 0)
                {
                    UIController.FirstRoverLaunched = true;                             // If successfuly launched first rover
                }
            }
            foreach (var rover in rovers)
            {
                Console.WriteLine(String.Format("{0} {1} {2}",                          // Print the final state of each rover
                    rover.Context.GetRoverState().Point.X,
                    rover.Context.GetRoverState().Point.Y,
                    rover.Context.GetRoverState().Direction.ToString().Substring(0,1)));
            }
            Console.Read();
        }
    }
}
