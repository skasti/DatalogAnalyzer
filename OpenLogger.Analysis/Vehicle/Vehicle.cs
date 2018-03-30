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
        }
    }
}
