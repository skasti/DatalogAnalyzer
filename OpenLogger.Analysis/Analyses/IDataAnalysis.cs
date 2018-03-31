using System.Collections.Generic;

namespace OpenLogger.Analysis.Analyses
{
    public interface IDataAnalysis
    {
        string Name { get; }
        List<DataPoint> Analyze(List<DataPoint> input);
    }
}