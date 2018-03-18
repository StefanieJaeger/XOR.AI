using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;

namespace XOR.AI
{
    class Program
    {
        private static List<double> connections = new List<double>();
        private static int I0 = 1;
        private static int H0 = 1;

        static void Main(string[] args)
        {
            Random ran = new Random();

            for (int i = 0; i < 9; i++)
            {
                double random = (ran.NextDouble() * 2) - 1;
                connections.Add(random);
                Console.WriteLine(random);
            }

            Console.WriteLine(Case1());
            Console.WriteLine(Case2());
            Console.WriteLine(Case3());
            Console.WriteLine(Case4());

            Console.Read();
        }


        private static double Case1()
        {
            int I1 = 0;
            int I2 = 0;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        private static double Case2()
        {
            int I1 = 0;
            int I2 = 1;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        private static double Case3()
        {
            int I1 = 1;
            int I2 = 0;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        private static double Case4()
        {
            int I1 = 1;
            int I2 = 1;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }
    }
}
