using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Host.Models
{
    public class RoverViewModel
    {
        public RoverPointModel UpperBounds { get; set; }
        public RoverActionModel[] Rovers { get; set; }
    }
    public class RoverActionModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public string Instruction { get; set; }
    }
    public class RoverPointModel
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}