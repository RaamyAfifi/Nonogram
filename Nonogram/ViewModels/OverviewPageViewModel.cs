using NonogramModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nonogram.ViewModels
{
    public class OverviewPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<CreatedPuzzle> savedPuzzles = new List<CreatedPuzzle>();
        public CreatedPuzzle SelectedPuzzle { get; set; }

        public ICommand StartPuzzleCommand { get; set; }
    }
}
