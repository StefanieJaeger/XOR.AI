using System;
using System.Collections.Generic;
using System.Text;

namespace XOR.AI
{
    class Chromosome
    {
        private List<double> connections;
        private static int I0 = 1;
        private static int H0 = 1;
        private int fitness;

        public Chromosome()
        {
            connections = new List<double>();
            Random ran = new Random(Guid.NewGuid().GetHashCode());

            //add for random decimals to the gen string
            for (int i = 0; i < 9; i++)
            {
                double random = (ran.NextDouble() * 2) - 1;
                connections.Add(random);
            }

            //check for each case if the number gives the correct result, add a point if it does
            if (checkResult(1, Case1()))
                fitness++;
            if (checkResult(2, Case2()))
                fitness++;
            if (checkResult(3, Case3()))
                fitness++;
            if (checkResult(4, Case4()))
                fitness++;

            //Console.WriteLine("**********");
            //Console.WriteLine();
            //Console.WriteLine("Fitness: " + fitness + "/4");
            //Console.WriteLine();

            //foreach (double connection in connections)
            //{
            //    Console.WriteLine(connection);
            //}

            //Console.WriteLine();
            //Console.WriteLine("**********");
            //Console.Read();
        }

        public Chromosome(List<double> connections)
        {
            this.connections = connections;

            if (checkResult(1, Case1()))
                fitness++;
            if (checkResult(2, Case2()))
                fitness++;
            if (checkResult(3, Case3()))
                fitness++;
            if (checkResult(4, Case4()))
                fitness++;
        }

        public int getFitness()
        {
            return fitness;
        }

        public List<int> getRoundedConnections() {
            List<int> rounded = new List<int>();
            foreach (double con in connections) {
                rounded.Add((int)Math.Ceiling(con));
            }
            return rounded;
        }

        public List<double> getConnections()
        {
            return connections;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private double Case1()
        {
            int I1 = 0;
            int I2 = 0;

            double H1 = (connections[0] * I0 + connections[1] * I1 + connections[2] * I2) / 3;
            double H2 = (connections[3] * I0 + connections[4] * I1 + connections[5] * I2) / 3;

            double O = (H0 * connections[6] + H1 * connections[7] + H2 * connections[8]) / 3;

            return O;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private double Case2()
        {
            int I1 = 0;
            int I2 = 1;

            double H1 = (connections[0] * I0 + connections[1] * I1 + connections[2] * I2)/3;
            double H2 = (connections[3] * I0 + connections[4] * I1 + connections[5] * I2)/3;

            double O = (H0 * connections[6] + H1 * connections[7] + H2 * connections[8]) / 3;

            return O;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private double Case3()
        {
            int I1 = 1;
            int I2 = 0;

            double H1 = (connections[0] * I0 + connections[1] * I1 + connections[2] * I2) / 3;
            double H2 = (connections[3] * I0 + connections[4] * I1 + connections[5] * I2) / 3;

            double O = (H0 * connections[6] + H1 * connections[7] + H2 * connections[8]) / 3;

            return O;
        }

        /// <summary>
        /// Case 1 checks values 0 and 0, should return 0 respectively a negativ number
        /// </summary>
        /// <returns> a positive or negative number</returns>
        private double Case4()
        {
            int I1 = 1;
            int I2 = 1;

            double H1 = (connections[0] * I0 + connections[1] * I1 + connections[2] * I2) / 3;
            double H2 = (connections[3] * I0 + connections[4] * I1 + connections[5] * I2) / 3;

            double O = (H0 * connections[6] + H1 * connections[7] + H2 * connections[8])/3;

            return O;
        }

        /// <summary>
        /// Checks each case's result with the expected one
        /// </summary>
        /// <param name="caseNr"> the case number (1 to 4) </param>
        /// <param name="result"> the result of the case </param>
        /// <returns> whether the case gave the correct result or not </returns>
        private bool checkResult(int caseNr, double result)
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
