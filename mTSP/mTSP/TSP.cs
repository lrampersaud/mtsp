using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mTSP
{
    public class TSP
    {
        public List<Point> Cities { get; set; }
        public int Salesmen { get; set; }
        public int Generations { get; set; }
        public float MutationProbability { get; set; }
        public int PopultaionSize { get; set; }
        public Random Rand { get; set; }
        public Panel Canvas { get; set; }
        public int Delay { get; set; }
        public List<Pen> Pens { get; set; } 

        public TSP(List<Point> pCities, int pSalesmen, int pGenerations, float pMutationProbability, int pPopulationSize, Panel pCanvas, int pDelay)
        {
            Cities = pCities;
            Salesmen = pSalesmen;
            Generations = pGenerations;
            MutationProbability = pMutationProbability;
            PopultaionSize = pPopulationSize;
            Canvas = pCanvas;
            Delay = pDelay;
            Rand=new Random();
            Pens = new List<Pen>();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            for (int i = 0; i < Salesmen; i++)
            {
                Pens.Add(new Pen(Color.FromKnownColor(names[Rand.Next(names.Length)])));
            }
        }
        public Solution GeneticAlgorithm()
        {
            List<Solution> population = GenerateInitialPopulation();

            for (int i = 0; i < Generations; i++)
            {
                population = MakeNewPopulation(population);
                if (Delay > 0)
                {
                    Canvas.Refresh();
                    DrawSolution(population[0]);
                    Thread.Sleep(Delay);
                }
            }
            population = population.OrderBy(p => p.Cost).ToList();
            return population[0];
        }
        private Solution Crossover(Solution mother, Solution father)
        {
            int[] Begin = new int[Salesmen];
            int[] Count = new int[Salesmen];
            List<int> selectedGenes = new List<int>();

            int segmentStart = 0;

            List<int> salesmen = new List<int>();
            salesmen.AddRange(mother.Element.GetRange(Cities.Count,Salesmen));

            List<int> mElements = new List<int>();
            mElements.AddRange(mother.Element.GetRange(0, Cities.Count));


            for (int i = 0; i < salesmen.Count; i++)
            {
                Begin[i] = Rand.Next(salesmen[i]);
                if (salesmen[i] > Begin[i])
                {
                    Count[i] = Rand.Next(salesmen[i] - Begin[i]) + 1;
                }
                else
                {
                    Count[i] = salesmen[i];
                    Begin[i] = 0;
                }

                Begin[i] += segmentStart;

                segmentStart += salesmen[i];
            }



            for (int i = 0; i < Salesmen; i++)
            {
                for (int j = Begin[i]; j < Begin[i] + Count[i]; j++)
                {
                    selectedGenes.Add(mElements[j]);
                }
            }

            List<int> fElements = new List<int>();
            fElements.AddRange(father.Element.GetRange(0, Cities.Count));

            List<int> dadOrder = new List<int>();
            for (int i = 0; i < Cities.Count; i++)
            {
                if (!selectedGenes.Any(p => p == fElements[i]))
                {
                    dadOrder.Add(fElements[i]);
                }
            }
            int[] CountFather = new int[Salesmen];
            int total = dadOrder.Count;
            for (int i = 0; i < Salesmen; i++)
            {
                if (total <= 0)
                {
                    total = dadOrder.Count;
                    i = 0;
                }
                CountFather[i] = Rand.Next(total) + 1;
                total = total - CountFather[i];
            }
            CountFather[Salesmen-1] += total;

            Solution generated = new Solution();
            int mOffset = 0;
            int fOffset = 0;
            for (int i = 0; i < Salesmen; i++)
            {
                generated.Element.AddRange(selectedGenes.GetRange(mOffset,Count[i]));
                mOffset += Count[i];

                generated.Element.AddRange(dadOrder.GetRange(fOffset, CountFather[i]));
                fOffset += CountFather[i];
            }

            for (int i = 0; i < Salesmen; i++)
            {
                generated.Element.Add(Count[i] + CountFather[i]);
            }
            CalculateCost(generated);
            return generated;
        }
        private List<Solution> MakeNewPopulation(List<Solution> individuals)
        {
            List<Solution> newPopulation = new List<Solution>();

            // tournament selection and crossover
            Solution[] a1 = new Solution[individuals.Count];
            Solution[] a2 = new Solution[individuals.Count];

            for (int i = 0; i < individuals.Count; i++)
            {
                a1[i] = individuals[i].Clone();
                a2[i] = individuals[i].Clone();
            }


            //shuffle solutions for Randomness
            for (int i = 0; i < individuals.Count; i++)
            {
                int RandomIndex = Rand.Next(individuals.Count);
                Solution temp = a1[RandomIndex];
                a1[RandomIndex] = a1[i];
                a1[i] = temp;
            }


            //crossover
            for (int i = 0; i < individuals.Count - 4; i += 2)
            {
                Solution parent1 = BinaryTournament(a1[i], a1[i + 1]);
                Solution parent2 = BinaryTournament(a1[i + 2], a1[i + 3]);

                newPopulation.Add(Crossover(parent1, parent2));
                newPopulation.Add(Crossover(parent2, parent1));
            }

            // mutation
            foreach (var individual in newPopulation)
            {
                Mutate(individual);
            }
            newPopulation.AddRange(individuals);

            //sort solutions and take top solutions to go to the next generation
            newPopulation = newPopulation.OrderBy(p => p.Cost).ToList();

            List<Solution> generatedPopulation = new List<Solution>();
            List<String> stringData = new List<String>();
            int count = individuals.Count;
            for (int i = 0; i < count && i < newPopulation.Count; i++)
            {
                if (!stringData.Contains(newPopulation[i].ToString()))
                {
                    stringData.Add(newPopulation[i].ToString());
                    generatedPopulation.Add(newPopulation[i]);
                }
                else
                {
                    count++;
                }
            }
            return generatedPopulation;
        }
        private void Mutate(Solution sol)
        {
            if (Rand.NextDouble() < MutationProbability)
            {
                int first = Rand.Next(sol.Element.Count - Salesmen);
                int second = Rand.Next(sol.Element.Count - Salesmen);
                Swap(sol.Element, first, second);
                CalculateCost(sol);
            }
        }
        private Solution BinaryTournament(Solution individual1, Solution individual2)
        {
            if (individual1.Cost > individual2.Cost)
            {
                return individual1;
            }
            if (individual2.Cost > individual1.Cost)
            {
                return individual2;
            }

            if (Rand.NextDouble() < 0.5)
            {
                return individual1;
            }
            else
            {
                return individual2;
            }
        }
        private List<Solution> GenerateInitialPopulation()
        {
            List<Solution> population = new List<Solution>();
            for (int i = 0; i < PopultaionSize; i++)
            {
                population.Add(GenerateIndividual());
            }
            return population;
        }
        private Solution GenerateIndividual()
        {
            //2 part Chromosome: first part are the cities, second part are the salesmen
            List<int> element = new List<int>();
            for (int i = 0; i < Cities.Count; i++)
            {
                element.Add(i);
            }
            //Randomize solution
            for (int i = 0; i < element.Count; i++)
            {
                int first = Rand.Next(element.Count);
                int second = Rand.Next(element.Count);
                Swap(element, first, second);
            }
            //get salesmen
            List<int> salesmen = GenNumbers(Salesmen, Cities.Count);

            while (salesmen.Contains(0) || salesmen.Count < Salesmen)
            {
                salesmen = GenNumbers(Salesmen, Cities.Count);
            }
            element.AddRange(salesmen);
            Solution sol = new Solution(element);
            CalculateCost(sol);
            return sol;
        }
        private void CalculateCost(Solution sol)
        {
            if (sol.Element.Count >= Cities.Count + Salesmen)
            {
                int currentPos = 0;
                double total = 0f;
                int X1 = 0;
                int X2 = 0;

                int Y1 = 0;
                int Y2 = 0;
                List<int> element = sol.Element;

                List<int> salesmen = new List<int>();
                salesmen.AddRange(element.GetRange(Cities.Count, Salesmen));

                for (int i = 0; i < salesmen.Count; i++)
                {
                    //distance from first to last
                    X1 = Cities[element[currentPos]].X;
                    X2 = Cities[element[currentPos + salesmen[i] - 1]].X;
                    Y1 = Cities[element[currentPos]].Y;
                    Y2 = Cities[element[currentPos + salesmen[i] - 1]].Y;
                    total += Math.Sqrt((Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2)));

                    for (int j = currentPos; j < currentPos + salesmen[i] - 1; j++)
                    {
                        X1 = Cities[element[j]].X;
                        X2 = Cities[element[j + 1]].X;
                        Y1 = Cities[element[j]].Y;
                        Y2 = Cities[element[j + 1]].Y;
                        total += Math.Sqrt((Math.Pow((X1 - X2), 2) + Math.Pow((Y1 - Y2), 2)));
                    }
                    currentPos = currentPos + salesmen[i];
                }
                sol.Cost = total;
            }
            else
            {
                sol.Cost = 0f;
            }
        }
        private void Swap(List<int> element, int i, int j)
        {
            int first = element[i];
            element[i] = element[j];
            element[j] = first;
        }
        private List<int> GenNumbers(int n, int sum)
        {
            List<int> nums = new List<int>();
            for (int i = 0; i < n; i++)
            {
                nums.Add(0);
            }
            while (nums.Contains(0))
            {
                int total = sum;
                for (int i = 0; i < n; i++)
                {
                    if (total <= 0)
                    {
                        nums[i] = 0;
                    }
                    else
                    {
                        nums[i] = Rand.Next(total) + 1;
                    }
                    total -= nums[i];
                }
                nums[Salesmen-1] = nums[Salesmen-1] + total;
            }
            return nums;
        }
        private void DrawSolution(Solution solution)
        {
            Graphics g = Canvas.CreateGraphics();

            List<int> element = solution.Element;
            List<int> salesmen = new List<int>();
            salesmen.AddRange(solution.Element.GetRange(Cities.Count, Salesmen));

            int currentPos = 0;
            int X1 = 0;
            int X2 = 0;
            int Y1 = 0;
            int Y2 = 0;
            for (int i = 0; i < salesmen.Count; i++)
            {
                X1 = Cities[element[currentPos]].X;
                X2 = Cities[element[currentPos + salesmen[i] - 1]].X;
                Y1 = Cities[element[currentPos]].Y;
                Y2 = Cities[element[currentPos + salesmen[i] - 1]].Y;
                g.DrawLine(Pens[i], X1, Y1, X2, Y2);

                for (int j = currentPos; j < currentPos + salesmen[i] - 1; j++)
                {
                    X1 = Cities[element[j]].X;
                    X2 = Cities[element[j + 1]].X;
                    Y1 = Cities[element[j]].Y;
                    Y2 = Cities[element[j + 1]].Y;
                    g.DrawLine(Pens[i], X1, Y1, X2, Y2);
                }
                currentPos = currentPos + salesmen[i];
            }

            RectangleF rectf = new RectangleF(0, 0, 200, 50);
            string text = "Path length: " + Math.Round(solution.Cost, MidpointRounding.AwayFromZero) + " units";
            g.DrawString(text, new Font("Tahoma", 8), Brushes.Black, rectf);
        }
    }
}
