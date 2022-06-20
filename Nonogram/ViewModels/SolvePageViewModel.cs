using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Microsoft.Toolkit.Mvvm.Input;
using NonogramModels;

namespace Nonogram.ViewModels
{
    public class SolvePageViewModel : INotifyPropertyChanged
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
            DoneCommand = new RelayCommand(validatePuzzle);
            ColumnHints = SolvingPuzzle.SolvedPuzzle.GetAllColumnHints();
            RowHints = SolvingPuzzle.SolvedPuzzle.GetAllRowHints();
        }

        /// <summary>
        /// Validate puzzle solution
        /// If the solution is right color the puzzle in the solution's color
        /// Also changes the button text and command of the button to go back the the overview
        /// </summary>
        private void validatePuzzle()
        {
            if (SolvingPuzzle.ValidateSolution())
            {
                SolvingPuzzle.ColorSolution();
                ButtonText = "Back to overview";
                DoneCommand = new RelayCommand(NavBarViewModel.GotoAllPuzzles);
            }
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

        /// <summary>
        /// Command for crossing off the cell
        /// Erases cross if cell is crossed
        /// </summary>
        public ICommand CrossCellCommand { get; } = new RelayCommand<Cell>(cell => {
            if (cell.IsCrossed)
            {
                cell.IsCrossed = false;
            }
            else if (!cell.IsColored)
            {
                cell.IsCrossed = true;
            }
        });

        /// <summary>
        /// Command for coloring the cell
        /// Erases color if cell is colored
        /// </summary>
        public ICommand ColorCellCommand { get; } = new RelayCommand<Cell>(cell => {
            if (cell.IsColored && !cell.IsCrossed)
            {
                cell.RGBA = Colors.White;
                cell.IsColored = false;
            }
            else if (!cell.IsCrossed)
            {
                cell.RGBA = Colors.Black;
                cell.IsColored = true;
            }
        });

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
