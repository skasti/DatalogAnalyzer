using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenLogger.Analysis.Vehicle.Inputs.Transforms;

namespace OpenLogAnalyzer.Transforms
{
    interface IEditInputTransforms
    {
        event EventHandler<IInputTransform> Saved;

        void LoadTransform(IInputTransform transform);
        void CreateTransform(double selectionMin, double selectionMax, double cursorX, double cursorY);

        DialogResult ShowDialog(IWin32Window owner);
    }
}
