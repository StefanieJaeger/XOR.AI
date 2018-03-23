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
        private static Chromosome[] parents = new Chromosome[2];
        private static Random ran;

        static void Main(string[] args)
        {
            populateRoulette();
            chooseParents();

            makeBabies(parents[0], parents[1]);
            giveResults(parents[0], parents[1]);
        }

        private static void chooseParents() {
            ran = new Random();
            parents[0] = roulette[ran.Next(roulette.Count)];
            parents[1] = roulette[ran.Next(roulette.Count)];
        }

        private static void giveResults(Chromosome mom, Chromosome dad, bool showStats = true) {
            if (showStats)
            {
                Console.WriteLine("mom: " + mom.getFitness());
                Console.WriteLine("dad: " + dad.getFitness());
                Console.WriteLine("child 1: " + gen2[0].getFitness());
                Console.WriteLine("child 2: " + gen2[1].getFitness());
            }
            Console.WriteLine("make more kids? m Or different parents (same collection)? d Or start new? n Or see gens of someone? g");
            string answer = Console.ReadLine();

            if (answer == "m")
            {
                gen2.Clear();
                makeBabies(parents[0], parents[1]);
                giveResults(parents[0], parents[1]);
            }
            else if (answer == "d")
            {
                chooseParents();
                gen2.Clear();
                makeBabies(parents[0], parents[1]);
                giveResults(parents[0], parents[1]);
            }
            else if (answer == "n")
            {
                string[] a = { };
                Program.Main(a);
            }
            else if (answer == "g")
            {
                Console.WriteLine("Mom? m Dad? d Child 1? c1 Child 2? c2");
                string who = Console.ReadLine();
                showGens(who);
            }
        }

        private static void showGens(string who) {
            if (who == "m")
            {
                Console.WriteLine("[{0}]", string.Join(", ", parents[0].getRoundedConnections()));
            }
            else if (who == "c1")
            {
                Console.WriteLine("[{0}]", string.Join(", ", gen2[0].getRoundedConnections()));
            }
            else if (who == "c2")
            {
                Console.WriteLine("[{0}]", string.Join(", ", gen2[1].getRoundedConnections()));
            }
            else if (who == "d")
            {
                Console.WriteLine("[{0}]", string.Join(", ", parents[1].getRoundedConnections()));
            }
            giveResults(parents[0], parents[1], false);
        }

        private static void makeBabies(Chromosome mom, Chromosome dad)
        {
            //choose a random place in the gen string
            int chromosoneCount = mom.getConnections().Count;
            int rate = ran.Next(chromosoneCount);
            List<double> connections1 = new List<double>();
            List<double> connections2 = new List<double>();

            //fill one child with mom's gens, the other with dad's up to the chosen spot
            for (int i = 0; i < rate; i++)
            {
                connections1.Add(mom.getConnections()[i]);
                connections2.Add(dad.getConnections()[i]);
            }
            //fill the rest with the other parent
            for (int i = rate; i < chromosoneCount; i++)
            {
                connections2.Add(mom.getConnections()[i]);
                connections1.Add(dad.getConnections()[i]);
            }

            //add the children to gen2
            Chromosome chromosome1 = new Chromosome(connections1);
            Chromosome chromosome2 = new Chromosome(connections2);

            gen2.Add(chromosome1);
            gen2.Add(chromosome2);
        }

        private static void populateRoulette()
        {
            //create 4 parents for gen1
            Chromosome chromosome1 = new Chromosome();
            Chromosome chromosome2 = new Chromosome();
            Chromosome chromosome3 = new Chromosome();
            Chromosome chromosome4 = new Chromosome();

            gen1.Add(chromosome1);
            gen1.Add(chromosome2);
            gen1.Add(chromosome3);
            gen1.Add(chromosome4);

            //give each as many places in the roulette as their fitness level
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
