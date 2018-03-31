using Common.Enums;
using Common.Models;
using SignalProcess.Base;
using SignalProcess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalProcess
{
    /// <summary>
    /// Wrapper for signal processing
    /// This class process given signals for a rover
    /// </summary>
    public class RoverSignalProcesor : BaseSignalProcesor
    {
        public RoverSignalProcesor(List<Signal> signals)
            : base(signals)
        {

        }
        /// <summary>
        /// Runs rover and change its state with some instructions
        /// </summary>
        /// <param name="initalState">Inital state of rover</param>
        public override void ProcessSignal(State initalState)
        {
            if (this.SignalList != null && this.SignalList.Count > 0)
            {
                foreach (var signal in this.SignalList)
                {
                    switch (signal.SignalType)                                                    //Identify the signal type
                    {
                        case SignalTypeEnum.Left:
                        case SignalTypeEnum.Right:
                            RotationHelper.RotateToGivenDirection(initalState, signal.SignalType);//Rotate rover
                            break;
                        case SignalTypeEnum.Move:
                            MovementHelper.Move(initalState);                                      //Mover rover
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
