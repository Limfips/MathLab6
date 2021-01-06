using System;
using System.IO;

namespace MathLab_6.core
{
    public class GoldenRatioMinimizer: ISingleArgumentFunctionMinimizer
    {
        private static readonly double GOLDEN_RATIO = (Math.Sqrt(5) + 1) / 2;
        public double Minimize(Func f, double lowerBound, double higherBound, double precision)
        {
            int counter = 0;
            double finalLength = higherBound - lowerBound;
            string logFileName = "GoldenRatioMinimizerOut.txt";
            if (new FileInfo(logFileName).Exists) File.Delete(logFileName);
            StreamWriter writer = new StreamWriter(File.Create(logFileName));

            while (!(Math.Abs(higherBound - lowerBound) < precision)) {
                double left = higherBound - ((higherBound - lowerBound) / GOLDEN_RATIO);
                double right = lowerBound + ((higherBound - lowerBound) / GOLDEN_RATIO);

                double intervalLength = higherBound - lowerBound;

                Double fLeft = f.Invoke(left);
                counter++;
                Double fRight = f.Invoke(right);
                counter++;
                if (fLeft >= fRight) {
                    lowerBound = left;
                } else {
                    higherBound = right;
                }

                finalLength = higherBound - lowerBound;
                writer.WriteLine("a= {0:f5} || b= {1:f5} || eps= {2:f5}\n", lowerBound, higherBound, finalLength);
            }
            writer.WriteLine("a= {0:f5} || b= {1:f5} || eps= {2:f5} ==> F= {3:f5}\n", lowerBound, higherBound, finalLength, f.Invoke((lowerBound + higherBound) / 2));
            writer.WriteLine("I calculated function for %d times", counter);
            writer.Close();
            return f.Invoke((lowerBound + higherBound) / 2);
        }
        
        public double Argmin(Func<Double, Double> f, double lowerBound, double higherBound, double precision) {
            while (!(Math.Abs(higherBound - lowerBound) < precision)) {
                Double left = higherBound - ((higherBound - lowerBound) / GOLDEN_RATIO);
                Double right = lowerBound + ((higherBound - lowerBound) / GOLDEN_RATIO);

                Double fLeft = f.Invoke(left);
                Double fRight = f.Invoke(right);

                if (fLeft >= fRight) {
                    lowerBound = left;
                } else {
                    higherBound = right;
                }
            }
            return (lowerBound + higherBound) / 2;
        }
    }
}