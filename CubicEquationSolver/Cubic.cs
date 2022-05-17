using System;
using System.Numerics;

namespace CubicEquationSolver
{
    public class Cubic
    {
        const double ZeroAlmost = 1.0E-8; // 0.000000001
        const double Third = 1.0 / 3.0; // 0.333333

        public Complex[] Solve(double a, double b, double c, double d)
        {
            //Cardano's Method

            if (a == 0)
            {
                //=> bx^2 + cx + d = 0
                return null;
            }

            //Cardano constants
            double j = b / a;
            double k = c / a;
            double l = d / a;
            double p = -(j * j / 3.0) + k;
            double q = (2.0 / 27.0 * j * j * j) - (j * k / 3.0) + l;
            double t = q * q / 4.0 + p * p * p / 27.0;

            // force to be absolutely 0 to numbers very close to 0
            if (Math.Abs(t) < ZeroAlmost)
            {
                t = 0;
            }
            if (Math.Abs(q) < ZeroAlmost)
            {
                q = 0;
            }

            double r1 = 0, r2 = 0, r3 = 0, i1 = 0, i2 = 0, i3 = 0, i;

            if (t > 0)
            {
                //if t positive => 1 solution real and 2 complex
                // real solution

                r1 = CubeRoot(-q / 2.0 + Math.Sqrt(t))
                   + CubeRoot(-q / 2.0 - Math.Sqrt(t));

                // two complex solutions
                r2 = -r1 / 2.0;
                r3 = r2;

                // imaginary
                if (q == 0)
                {
                    i = Math.Sqrt(k);
                }
                else
                {
                    i = Math.Sqrt(Math.Abs(Math.Pow(r1 / 2.0, 2.0) + q / r1));
                }

                i1 = 0;
                i2 = i;
                i3 = -i;
            }
            if (t == 0)
            {
                // 3 real solutions, at least 2 are equal
                r1 = 2.0 * CubeRoot(-q / 2.0);
                r2 = -r1 / 2.0 + Math.Sqrt(Math.Pow(r1 / 2.0, 2.0) + q / r1);
                r3 = -r1 / 2.0 - Math.Sqrt(Math.Pow(r1 / 2.0, 2.0) + q / r1);
            }
            if (t < 0)
            {
                //for t negative => all solutions are real
                double x = -q / 2.0;
                double y = Math.Sqrt(-t); // we can't work with negative values => t positive
                double angle = Math.Atan(y / x);

                if (q > 0)
                {
                    // for q positive => angle = 2*PI - angle 
                    angle = 2 * Math.PI - angle; // ??????????????????
                }

                r1 = 2.0 * Math.Sqrt(-p / 3.0) * Math.Cos(angle / 3.0);
                r2 = 2.0 * Math.Sqrt(-p / 3.0) * Math.Cos((angle + 2.0 * Math.PI) / 3.0);
                r3 = 2.0 * Math.Sqrt(-p / 3.0) * Math.Cos((angle + 4.0 * Math.PI) / 3.0);
            }
            // the solutions: 
            Complex[] result = new Complex[3];

            result[0] = new Complex(r1 - j / 3.0, i1);
            result[1] = new Complex(r2 - j / 3.0, i2);
            result[2] = new Complex(r3 - j / 3.0, i3);

            return result;
        }

        double CubeRoot(double number)
        {
            if (number < 0)
                return -Math.Pow(-number, Third);
            else
                return Math.Pow(number, Third);
        }
    }
}
