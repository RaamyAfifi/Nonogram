using NonogramModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Microsoft.Toolkit.Mvvm.Input;

namespace Nonogram.ViewModels
{
    public class DesignPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CreatedPuzzle designingPuzzle;

        private ObservableCollection<Color> blackColors = new ObservableCollection<Color>();
        private ObservableCollection<Color> whiteColors = new ObservableCollection<Color>();

        public Color SelectedBlackColor { get; set; } = Colors.Black;
        public Color SelectedWhiteColor { get; set; } = Colors.White;
        public Color SelectedColorPicker { get; set; } = Colors.SkyBlue;

        public ICommand FinishedCommand { get; set; }
        public ICommand ColorBlackCellCommand { get; set; }
        public ICommand ColorWhiteCellCommand { get; set; }
        public ICommand AddBlackColorCommand { get; set; }
        public ICommand AddWhiteColorCommand { get; set; }

        public DesignPageViewModel(CreatedPuzzle puzzle)
        {
            //set the puzzle
            DesigningPuzzle = puzzle;

            //set start colors
            WhiteColors.Add(Colors.White);
            WhiteColors.Add(Colors.Red);
            WhiteColors.Add(Colors.Green);
            WhiteColors.Add(Colors.Blue);

            BlackColors.Add(Colors.Black);
            BlackColors.Add(Colors.Red);
            BlackColors.Add(Colors.Green);
            BlackColors.Add(Colors.Blue);

            FinishedCommand = new RelayCommand(FinishAndSavePuzzle);

            ColorBlackCellCommand = new RelayCommand<Cell>(cell => {
                cell.IsColored = true;
                cell.RGBA = SelectedBlackColor;
            });

            ColorWhiteCellCommand = new RelayCommand<Cell>(cell => {
                cell.IsColored = false;
                cell.RGBA = SelectedWhiteColor;
            });

            AddBlackColorCommand = new RelayCommand(addBlackColor);

            AddWhiteColorCommand = new RelayCommand(addWhiteColor);
        }

        private async void FinishAndSavePuzzle()
        {
            await PuzzleFactory.SavePuzzle(designingPuzzle);
            NavBarViewModel.GotoAllPuzzles();
        }

        public CreatedPuzzle DesigningPuzzle
        {
            get => designingPuzzle;
            set
            {
                designingPuzzle = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Color> BlackColors
        {
            get => blackColors;
            set
            {
                blackColors = value;
                NotifyPropertyChanged();
            }
        }

        private void addWhiteColor()
        {
            if (WhiteColors.Contains(SelectedColorPicker)) return;
            WhiteColors.Add(SelectedColorPicker);
        }

        private void addBlackColor()
        {
            if (BlackColors.Contains(SelectedColorPicker)) return;
            BlackColors.Add(SelectedColorPicker);
        }

        public ObservableCollection<Color> WhiteColors
        {
            get => whiteColors;
            set
            {
                whiteColors = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
