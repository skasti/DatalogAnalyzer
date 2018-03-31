using System.Collections.Generic;
using System.Linq;

namespace OpenLogger.Analysis.Analyses
{
    public class YDistributionAnalysis: IDataAnalysis
    {
        public List<DataPoint> Analyze(List<DataPoint> input)
        {
            var result = new List<DataPoint>();

            var start = -200;
            var stop = 200;
            var interval = 10;

            for (int x = start; x < stop; x += interval)
            {
                var count = input.Count(d => d.Y >= x && d.Y < x + interval);

                result.Add(new DataPoint(x, count));
            }

            return result;
        }
    }
}
