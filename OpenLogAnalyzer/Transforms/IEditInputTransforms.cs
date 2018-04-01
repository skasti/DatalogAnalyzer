using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;

namespace OpenLogAnalyzer.Transforms
{
    public interface IEditInputTransforms
    {
        event EventHandler<IInputTransform> Saved;
        void Create(double selectionMin, double selectionMax, double cursorX, double cursorY);
        void LoadTransform(IInputTransform transform);
        DialogResult ShowDialog(IWin32Window owner);
    }
    public interface IEditInputTransforms<T>: IEditInputTransforms where T: IInputTransform
    {
    }
}
