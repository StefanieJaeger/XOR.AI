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
        private static List<Chromosome> roulette = new List<Chromosome>();
        private static List<Chromosome> gen1 = new List<Chromosome>();
        private  static List<Chromosome> gen2 = new List<Chromosome>();
        private static Random ran;

        static void Main(string[] args)
        {
            ran = new Random();
            populateRoulette();
            Chromosome mom = roulette[ran.Next(roulette.Count)];
            Chromosome dad = roulette[ran.Next(roulette.Count)];

            makeBabies(mom, dad);
        }

        private static void makeBabies(Chromosome mom, Chromosome dad)
        {
            int chromosoneCount = mom.getConnections().Count;
            int rate = ran.Next(chromosoneCount);
            List<double> connections1 = new List<double>();
            List<double> connections2 = new List<double>();

            for (int i = 0; i < rate; i++)
            {
                connections1.Add(mom.getConnections()[i]);
                connections2.Add(dad.getConnections()[i]);
            }
            for (int i = rate; i < chromosoneCount; i++)
            {
                connections2.Add(mom.getConnections()[i]);
                connections1.Add(dad.getConnections()[i]);
            }

            Chromosome chromosome1 = new Chromosome(connections1);
            Chromosome chromosome2 = new Chromosome(connections2);

            gen2.Add(chromosome1);
            gen2.Add(chromosome2);
        }

        private static void populateRoulette()
        {
            Chromosome chromosome1 = new Chromosome();
            Chromosome chromosome2 = new Chromosome();
            Chromosome chromosome3 = new Chromosome();
            Chromosome chromosome4 = new Chromosome();

            gen1.Add(chromosome1);
            gen1.Add(chromosome2);
            gen1.Add(chromosome3);
            gen1.Add(chromosome4);

            for (int i = 0; i < chromosome1.getFitness(); i++)
            {
                roulette.Add(chromosome1);
            }
            for (int i = 0; i < chromosome2.getFitness(); i++)
            {
                roulette.Add(chromosome2);
            }
            for (int i = 0; i < chromosome3.getFitness(); i++)
            {
                roulette.Add(chromosome3);
            }
            for (int i = 0; i < chromosome4.getFitness(); i++)
            {
                roulette.Add(chromosome4);
            } 
        }
    }
}
