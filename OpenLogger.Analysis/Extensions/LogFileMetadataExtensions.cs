using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLogger.Core;

namespace OpenLogger.Analysis.Extensions
{
    public static class LogFileMetadataExtensions
    {
        public static void UpdateAnalysisData(this LogFileMetadata metadata, SessionAnalysis analysis)
        {
            metadata.Laps = analysis.Laps.Count;
            metadata.Track = analysis.Track?.Name ?? "";
            metadata.Best = analysis.Laps.OrderBy(lap => lap.Time).FirstOrDefault()?.Time ?? TimeSpan.Zero;
            metadata.Average = analysis.Laps.Count > 0 ? TimeSpan.FromMilliseconds(analysis.Laps.Average(lap => lap.Time.TotalMilliseconds)) : TimeSpan.Zero;
        }
    }
}
