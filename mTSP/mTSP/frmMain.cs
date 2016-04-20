using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mTSP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {

            btnStartStop.Text = "Stop";
            btnStartStop.Refresh();
            Random rand = new Random();
            int Salesmen = Convert.ToInt32(txtSalesmen.Text);
            int Generations = Convert.ToInt32(txtGenerationCount.Text);
            float MutationProbability = (float)Convert.ToDouble(txtMutationProbability.Text);
            int PopultaionSize = Convert.ToInt32(txtPopulationSize.Text);
            int CityCount = Convert.ToInt32(txtCities.Text);
            int Delay = Convert.ToInt32(txtDelay.Text);
            List<Point> Cities = new List<Point>();

            for (int i = 0; i < CityCount; i++)
            {
                int randomX = rand.Next(pnlCanvas.Width-50)+25;
                int randomY = rand.Next(pnlCanvas.Height-50)+25;
                Cities.Add(new Point {X = randomX, Y = randomY});
            }

            TSP tsp = new TSP(Cities, Salesmen, Generations, MutationProbability, PopultaionSize, pnlCanvas, Delay);

            Solution solution = tsp.GeneticAlgorithm();
            DrawSolution(solution, Cities, Salesmen, tsp.Pens);

            btnStartStop.Text = "Start";
        }

        private void DrawSolution(Solution solution, List<Point> Cities, int Salesmen, List<Pen> Pens)
        {
            Graphics g = pnlCanvas.CreateGraphics();
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
                //distance from first to last
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
            foreach (var c in Cities)
            {
                g.DrawEllipse(new Pen(Color.Black), new Rectangle(c.X, c.Y, 2, 2));
            }
        }
    }
}
