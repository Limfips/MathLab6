namespace MathLab_6.core
{
    public interface ISingleArgumentFunctionMinimizer
    {
        public double Minimize(Func f, double lowerBound, double higherBound, double precision);
    }
}