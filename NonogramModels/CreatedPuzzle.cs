using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NonogramModels
{
    public class CreatedPuzzle
    {
        public Puzzle Puzzle { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }

        public CreatedPuzzle(string creator, string description)
        {
            Creator = creator;
            Description = description;
        }

        /// <summary>
        /// Get hints of all columns
        /// </summary>
        /// <returns>List containing lists of hints of all columns</returns>
        public List<List<int>> GetAllColumnHints()
        {
            var list = new List<List<int>>();
            for (int i = 0; i < Puzzle.XAxis; i++)
            {
                list.Add(GetColumnHints(i));
            }

            return list;
        }

        /// <summary>
        /// Get hints of all rows
        /// </summary>
        /// <returns>List containing lists of hints of all rows</returns>
        public List<List<int>> GetAllRowHints()
        {
            var list = new List<List<int>>();
            for (int i = 0; i < Puzzle.YAxis; i++)
            {
                list.Add(GetRowHints(i));
            }

            return list;
        }

        /// <summary>
        /// Get hints of row
        /// </summary>
        /// <param name="row">index of the row</param>
        /// <returns>List containing hint(s)</returns>
        public List<int> GetRowHints(int row)
        {
            var cellRow = Puzzle.PuzzleSolution[row];

            return GetHints(cellRow);
        }

        /// <summary>
        /// Get hints of column
        /// </summary>
        /// <param name="column">index of the column</param>
        /// <returns>List containing hint(s)</returns>
        public List<int> GetColumnHints(int column)
        {
            var cellColumn = new ObservableCollection<Cell>();

            foreach (var row in Puzzle.PuzzleSolution)
            {
                cellColumn.Add(row[column]);
            }

            return GetHints(cellColumn);
        }

        /// <summary>
        /// Get hints of ObservableCollection
        /// A hint is the amount of colored cells next to each other
        /// A new hint is added to the list if colored cells are separated by an uncolored cell
        /// returns list with 0 if no colored cells are in the collection
        /// </summary>
        /// <param name="collection">ObservableCollection of cells</param>
        /// <returns>List containing the hint(s)</returns>
        private static List<int> GetHints(ObservableCollection<Cell> collection)
        {
            var hints = new List<int>();
            var hint = 0;
            foreach (var cell in collection)
            {
                if (cell.IsColored)
                {
                    hint++;
                }
                else
                {
                    if (hint > 0)
                    {
                        hints.Add(hint);
                        hint = 0;
                    }
                }
            }

            if (hint > 0 || hints.Count == 0)
            {
                hints.Add(hint);
            }

            return hints;
        }
    }
}
