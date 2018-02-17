using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Analysis.Vehicle.Inputs;

namespace OpenLogger.Analysis.Vehicle
{
    public class Vehicle
    {
        public string Name { get; set; }
        public List<Input> Inputs { get; set; }

        public Vehicle()
        {
            Inputs = new List<Input>
            {
                new Input
                {
                    Name = "Speed",
                    Source = InputSource.Speed
                },

                new Input
                {
                    Name = "Altitude",
                    Source = InputSource.Altitude
                },

                new Input
                {
                    Name = "TPS",
                    Source = InputSource.Analog,
                    AnalogSource = 0,
                    Smoothing = 10
                },

                new Input
                {
                    Name = "Fork Position",
                    Source = InputSource.Analog,
                    AnalogSource = 1,
                    Smoothing = 10
                }
            };
        }
    }
}
