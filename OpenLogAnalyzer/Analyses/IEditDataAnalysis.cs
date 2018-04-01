using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Analyses;

namespace OpenLogAnalyzer.Analyses
{
    public interface IEditDataAnalysis
    {
        event EventHandler<IDataAnalysis> Saved;
        void Create();
        void LoadAnalysis(IDataAnalysis analysis);
        DialogResult ShowDialog(IWin32Window owner);
    }

    public interface IEditDataAnalysis<T> : IEditDataAnalysis where T : IDataAnalysis
    {
        
    }
}
