using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using NonogramModels;

namespace Nonogram.ViewModels
{
    public class SolvePageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<List<int>> RowHints { get; set; }
        public List<List<int>> ColumnHints { get; set; }
        private SolvingPuzzle solvingPuzzle;
        public string Dimensions { get; set; }
        private string buttonText { get; set; } = "Done";
        private ICommand doneCommand { get; set; }

        public SolvePageViewModel(CreatedPuzzle puzzle)
        {
            SolvingPuzzle = new SolvingPuzzle(puzzle);
            Dimensions = SolvingPuzzle.Puzzle.XAxis + "/" + SolvingPuzzle.Puzzle.YAxis;
            ColumnHints = SolvingPuzzle.SolvedPuzzle.GetAllColumnHints();
            RowHints = SolvingPuzzle.SolvedPuzzle.GetAllRowHints();
        }

        public SolvingPuzzle SolvingPuzzle
        {
            get => solvingPuzzle;
            set
            {
                solvingPuzzle = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand DoneCommand
        {
            get => doneCommand;
            set
            {
                doneCommand = value;
                NotifyPropertyChanged();
            }
        }

        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
