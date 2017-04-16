using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatalogAnalyzer
{
    public partial class TrackLibrary : Form
    {
        private TrackRepository _repository;
        public TrackLibrary(TrackRepository repository)
        {
            _repository = repository;
            InitializeComponent();

            foreach (var track in _repository.Tracks)
            {
                
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
