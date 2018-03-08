using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLogger.Analysis.Vehicle.Inputs.Transforms
{
    public class LinearMapTransform: InputTransform
    {
        public double SourceMin { get; set; }
        public double SourceMax { get; set; }
        public double SourceRange => SourceMax - SourceMin;

        public double TargetMin { get; set; }
        public double TargetMax { get; set; }
        public double TargetRange => TargetMax - TargetMin;

        public double Transform(double input)
        {
            return (input - SourceMin) / SourceRange * TargetRange + TargetMin;
        }

        public override string ToString()
        {
            return $"Linear map [{SourceMin}/{SourceMax}] to [{TargetMin}/{TargetMax}]";
        }
    }
}
