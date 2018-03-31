using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConfigurationUtilities
{
    public static class ApplicationConfigReader
    {
        #region Constants
        private static readonly string ShowInstructionsKey = "ShowInstructions";
        private static readonly string RoverSizeKey = "RoverSize";
        private static readonly string RoverMovementSizeKey = "RoverMovementSizeKey";
        #endregion
        /// <summary>
        /// Wrapper for reading configuration parameters
        /// </summary>
        /// <param name="parameterName">Name of config parameter</param>
        /// <returns></returns>
        public static string GetValue(string parameterName)
        {
            var value = ConfigurationManager.AppSettings[parameterName];
            return value != null ? value : string.Empty;
        }
        /// <summary>
        /// Checks Instruction messages are enabled or not
        /// </summary>
        public static bool InstructionsEnabled { 
            get {
                var value = GetValue(ShowInstructionsKey);
                if (!string.IsNullOrEmpty(value))
                {
                    return Convert.ToBoolean(value);
                }
                else
                {
                    return false;
                }
            } 
        }
        /// <summary>
        /// Returns number of rover size
        /// </summary>
        private static int _roverSize = 2;
        public static int RoverSize {
            get {
                var value = GetValue(RoverSizeKey);
                if(!string.IsNullOrEmpty(value))
                {
                    _roverSize = Convert.ToInt32(value);
                }
                return _roverSize;
            }
        }
        /// <summary>
        /// Returns to movement size on grid
        /// </summary>
        private static int _roverMovementSize = 1;
        public static int RoverMovementSize { 
            get {
                var value = GetValue(RoverMovementSizeKey);
                if (!string.IsNullOrEmpty(value))
                {
                    _roverMovementSize = Convert.ToInt32(value);
                }
                return _roverMovementSize;
            } 
        }
    }
}
