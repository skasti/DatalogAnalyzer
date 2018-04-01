using System.Collections.Generic;

namespace OpenLogger.Analysis.Analyses
{
    public interface IDataAnalysis
    {
        string Name { get; }
        GraphType GraphType { get; }
        List<DataPoint> Analyze(List<DataPoint> input);
        string GetDetails();
        /// <summary>
        /// Can be used to provide custom labels for datapoints
        /// </summary>
        string CustomLabel(DataPoint point);

        IDataAnalysis Copy();
    }
}