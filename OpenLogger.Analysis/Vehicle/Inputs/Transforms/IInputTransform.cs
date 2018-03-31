namespace OpenLogger.Analysis.Vehicle.Inputs.Transforms
{
    public interface IInputTransform
    {
        double Transform(double input);
        IInputTransform Copy();
    }
}
