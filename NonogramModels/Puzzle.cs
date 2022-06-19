using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramModels
{
    public class Puzzle
    {
        public ObservableCollection<ObservableCollection<Cell>> PuzzleSolution { get; set; } = new ObservableCollection<ObservableCollection<Cell>>();
        public int XAxis { get; set; }
        public int YAxis { get; set; }

        public Puzzle(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;

            InitPuzzle();
        }

        private void InitPuzzle()
        {
            for (int i = 0; i < YAxis; i++)
            {
                PuzzleSolution.Insert(i, new ObservableCollection<Cell>());
                for (int j = 0; j < XAxis; j++)
                {
                    PuzzleSolution[i].Insert(j, new Cell());
                }
            }
        }

        public List<bool> GetBlackAndWhiteSolution()
        {
            var solution = new List<bool>();

            for (int i = 0; i < YAxis; i++)
            {
                for (int j = 0; j < XAxis; j++)
                {
                    solution.Add(PuzzleSolution[i][j].IsColored);
                }
            }

            return solution;
        }
    }
}
