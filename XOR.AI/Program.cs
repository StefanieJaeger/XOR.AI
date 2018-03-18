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
        private static List<double> connections;
        private static int I0 = 1;
        private static int H0 = 1;

        static void Main(string[] args)
        {
            connections = new List<double>();

            Random ran = new Random(Guid.NewGuid().GetHashCode());
            int fitness = 0;

            for (int i = 0; i < 9; i++)
            {
                double random = (ran.NextDouble() * 2) - 1;
                connections.Add(random);
            }

            if (checkResult(1, Case1()))
                fitness++;
            if (checkResult(2, Case2()))
                fitness++;
            if (checkResult(3, Case3()))
                fitness++;
            if (checkResult(4, Case4()))
                fitness++;

            Console.WriteLine("**********");
            Console.WriteLine();
            Console.WriteLine("Fitness: " + fitness + "/4");
            Console.WriteLine();

            foreach (double connection in connections)
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine();
            Console.WriteLine("**********");
            Console.Read();

            //if (fitness != 4)
            //{
            //    Main(new string[0]);
            //}

        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private static double Case1()
        {
            int I1 = 0;
            int I2 = 0;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private static double Case2()
        {
            int I1 = 0;
            int I2 = 1;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private static double Case3()
        {
            int I1 = 1;
            int I2 = 0;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private static double Case4()
        {
            int I1 = 1;
            int I2 = 1;

            double H1 = connections[0] * I0 + connections[1] * I1 + connections[2] * I2;
            double H2 = connections[3] * I0 + connections[4] * I1 + connections[5] * I2;

            double O = H0 * connections[6] + H1 * connections[7] + H2 * connections[8];

            return O;
        }

        /// <summary>
        /// Checks each case's result with the expected one
        /// </summary>
        /// <param name="caseNr"> the case number (1 to 4) </param>
        /// <param name="result"> the result of the case </param>
        /// <returns> whether the case gave the correct result or not </returns>
        private static bool checkResult(int caseNr, double result)
        {
            switch (caseNr)
            {
                case 1:
                    return result < 0;
                case 2:
                    return result > 0;
                case 3:
                    return result > 0;
                case 4:
                    return result < 0;
                default:
                    return false; //no value given
            }
        }

        }
}
