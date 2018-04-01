using Business;
using Common.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UIProcess;
using Web.Host.Models;

namespace Web.Host.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get instructions and process them for each rover
        /// </summary>
        /// <param name="UpperBounds">space bounds</param>
        /// <param name="Rovers">rovers to control</param>
        /// <returns>final positions</returns>
        [HttpPost]
        public JsonResult SendInstructions(RoverPointModel UpperBounds, RoverActionModel[] Rovers)
        {
            RoverActionModel[] results = new RoverActionModel[Rovers.Length];
            Point upperBound = new Point(UpperBounds.X, UpperBounds.Y);
            for (int i = 0; i < Rovers.Length; i++)
            {
                State initialRoverState = new State    //create state
                {
                    Direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), Rovers[i].Direction.ToUpper()),
                    Point = new Point(Rovers[i].X, Rovers[i].Y)
                };
                Rover rover = new Rover(initialRoverState, upperBound);    //create rover  
                var instructionList = new List<Signal>();
                foreach (var signal in Rovers[i].Instruction.ToCharArray())  // give instructions
                {
                    instructionList.Add(new Signal
                    {
                        SignalType =
                            (SignalTypeEnum)Enum.Parse(typeof(SignalTypeEnum), signal.ToString().ToUpper())
                    });
                }
                rover.ProcessSignal(instructionList);   // run roverr!
                results[i] = new RoverActionModel { Direction = rover.Context.GetRoverState().Direction.ToString().Substring(0, 1), X = rover.Context.GetRoverState().Point.X, Y = rover.Context.GetRoverState().Point.Y };
            }
            return Json(results);
        }
    }
}