namespace OpenLogger.Analysis.Vehicle.Inputs.Transforms
{
    public interface InputTransform
    {
        double Transform(double input);
        InputTransform Copy();
    }
}
