using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Wrapper for regex constants
    /// </summary>
    public class RegexConstants
    {
        public static readonly string CoordinatePointRegex = @"^\d\s\d$";                // Checks co-ordinate point like 0 0
        public static readonly string RoverInitialPointRegex = @"^\d\s\d\s[nwseNWSE]$";  // Checks initial state like 0 0 N - N is not case sensitive
        public static readonly string RoverInstructionRegex = @"^[lrmLRM]{1,}$";         // Checks given insturction like  lmRMMm  - Chars are not case sensitive
    }
}
