using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Analysis.Vehicle.Inputs;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Vehicle
{
    public class Vehicle: IHaveETag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Input> Inputs { get; set; }
        public string ETag { get; set; }

        public Vehicle()
        {
        }
    }
}
