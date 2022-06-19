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
    }
}
