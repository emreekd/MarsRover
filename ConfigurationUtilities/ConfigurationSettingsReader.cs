using Common.Models;
using Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationUtilities
{
    /// <summary>
    /// Wrapper for reading configuration files
    /// </summary>
    public class ConfigurationSettingsReader
    {
        /// <summary>
        /// Reads the instructions.json file from ConfigurationFiles folder on executing assembly
        /// </summary>
        /// <returns>Set of instructions</returns>
        public static Instruction[] GetInstructions()
        {
            InstructionContext instructionContext = new InstructionContext();
            var fileContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ConfigurationFiles/instructions.json"));
            if (!string.IsNullOrEmpty(fileContent))
            {
                instructionContext = JsonSerializer.Deserialize<InstructionContext>(fileContent);
            }
            return instructionContext.Instructions;
        }
    }
}
