using System.Collections.Generic;

namespace OpenLogger.Analysis.Analyses
{
    public interface IDataAnalysis
    {
        List<DataPoint> Analyze(List<DataPoint> input);
    }
}