using NonogramModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;

namespace Nonogram.ViewModels
{
    public class DesignPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CreatedPuzzle designingPuzzle;

        private ObservableCollection<Color> blackColors = new ObservableCollection<Color>();
        private ObservableCollection<Color> whiteColors = new ObservableCollection<Color>();
        public Color SelectedBlackColor { get; set; } = Colors.Black;
        public Color SelectedWhiteColor { get; set; } = Colors.White;

        public ICommand FinishedCommand { get; set; }
        public ICommand ColorBlackCellCommand { get; set; }
        public ICommand ColorWhiteCellCommand { get; set; }

    }
}
