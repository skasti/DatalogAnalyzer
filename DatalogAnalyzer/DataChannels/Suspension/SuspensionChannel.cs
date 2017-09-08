using System;

namespace DatalogAnalyzer.DataChannels.Suspension
{
    public class SuspensionChannel: DataChannel
    {
        public double ArmAxisDistance { get; set; }

        public double Arm2Length { get; set; }

        public double Arm1Length { get; set; }

        public double Offset { get; set; }

        public SuspensionChannel(int source, string name = null, ChartType chart = ChartType.Sensor, 
            double zeroPoint = 0.0, double scaling = 1.0, 
            double arm1Length = 100.0, double arm2Length = 100.0, double armAxisDistance = 0.0, double offset = 0.0, int smoothing = 2) 
            :base(source, name, chart, zeroPoint, scaling, smoothing)
        {
            Arm1Length = arm1Length;
            Arm2Length = arm2Length;
            ArmAxisDistance = armAxisDistance;
            Offset = offset;
            IconIndex = 1;
        }

        public override double Value(LogEntry entry)
        {
            if (!(Arm1Length > 0))
                return base.Value(entry);

            var degrees = base.Value(entry);
            var radians = degrees * Math.PI / 180.0;

            var arm1Sin = Math.Sin(radians);
            var arm1X = Math.Cos(radians) * Arm1Length;

            if (Arm2Length == 0.0)
                return (Math.Sin(radians) + 1) * Arm1Length;

            var arm2Cos = (arm1X - ArmAxisDistance) / Arm2Length;
            var arm2Sin = Math.Sqrt(1 - Math.Pow(arm2Cos, 2));

            return (arm2Sin * Arm2Length + arm1Sin * Arm1Length) - Offset;
        }

        public override DataChannelEditor CreateEditor()
        {
            var editor = new SuspensionChannelEditor(this);
            editor.OnSave += InvokeOnChanged;
            return editor;
        }
    }
}
