using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramModels
{
    public class SolvingPuzzle
    {
        public CreatedPuzzle SolvedPuzzle { get; set; }
        public Puzzle Puzzle { get; set; }

        public SolvingPuzzle(CreatedPuzzle solvedPuzzle)
        {
            SolvedPuzzle = solvedPuzzle;
            Puzzle = new Puzzle(SolvedPuzzle.Puzzle.XAxis, SolvedPuzzle.Puzzle.YAxis);
        }

        /// <summary>
        /// Check if black and white solutions of puzzle en created puzzle are the same
        /// </summary>
        /// <returns>True if solution is right</returns>
        public bool ValidateSolution()
        {
            bool result = SolvedPuzzle.Puzzle.GetBlackAndWhiteSolution()
                .SequenceEqual(Puzzle.GetBlackAndWhiteSolution());
            return result;
        }

        /// <summary>
        /// Color the puzzle with the created puzzle's solution
        /// </summary>
        public void ColorSolution()
        {
            foreach (var row in Puzzle.PuzzleSolution.Select((value, x) => (value, x)))
            {
                foreach (var cell in row.value.Select((value, y) => (value, y)))
                {
                    cell.value.RGBA = SolvedPuzzle.Puzzle.PuzzleSolution[row.x][cell.y].RGBA;
                    cell.value.IsCrossed = false;
                }
            }
        }
    }
}
