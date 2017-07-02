using System.Globalization;
using System.Windows.Forms;

namespace DatalogAnalyzer.DataChannels.Suspension
{
    public partial class SuspensionChannelEditor : DataChannelEditor
    {
        private readonly SuspensionChannel _suspensionChannel;

        public SuspensionChannelEditor()
            :base()
        {
            InitializeComponent();
        }

        public SuspensionChannelEditor(SuspensionChannel channel)
            : base(channel)
        {
            InitializeComponent();
            _suspensionChannel = channel;
            LoadFromChannel();
        }

        public override void Apply()
        {
            base.Apply();

            double arm1Length;
            double arm2Length;
            double armAxisDistance;

            if (double.TryParse(arm1Input.Text,
                NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                out arm1Length))
            {
                _suspensionChannel.Arm1Length = arm1Length;
            }
            else
            {
                MessageBox.Show("Failed to parse Arm #1");
            }

            if (double.TryParse(arm2Input.Text,
                NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                out arm2Length))
            {
                _suspensionChannel.Arm2Length = arm2Length;
            }
            else
            {
                MessageBox.Show("Failed to parse Arm #2");
            }

            if (double.TryParse(armAxisInput.Text,
                NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture,
                out armAxisDistance))
            {
                _suspensionChannel.ArmAxisDistance = armAxisDistance;
            }
            else
            {
                MessageBox.Show("Failed to parse Arm-Axis");
            }
        }

        private void LoadFromChannel()
        {
            arm1Input.Text = _suspensionChannel.Arm1Length.ToString(CultureInfo.CurrentUICulture);
            arm2Input.Text = _suspensionChannel.Arm2Length.ToString(CultureInfo.CurrentUICulture);
            armAxisInput.Text = _suspensionChannel.ArmAxisDistance.ToString(CultureInfo.CurrentUICulture);
        }

        public override void Reset()
        {
            base.Reset();
            LoadFromChannel();
        }
    }
}
