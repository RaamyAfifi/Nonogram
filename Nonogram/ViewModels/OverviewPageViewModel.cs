using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using Nonogram.Pages;
using NonogramModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Nonogram.ViewModels
{
    public class OverviewPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<CreatedPuzzle> savedPuzzles = new List<CreatedPuzzle>();
        public CreatedPuzzle SelectedPuzzle { get; set; }

        public ICommand StartPuzzleCommand { get; set; }

        public OverviewPageViewModel()
        {
            loadPuzzles();
            StartPuzzleCommand = new RelayCommand(startPuzzle);
        }

        /// <summary>
        /// gets all saved puzzles in the json file
        /// </summary>
        private async void loadPuzzles()
        {
            SavedPuzzles = await PuzzleFactory.GetSavedPuzzles();
        }

        public List<CreatedPuzzle> SavedPuzzles
        {
            get => savedPuzzles;
            set
            {
                savedPuzzles = value;
                NotifyPropertyChanged();
            }
        }

        private void startPuzzle()
        {
            if (SelectedPuzzle == null) return;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(SolvePage), JsonConvert.SerializeObject(SelectedPuzzle));
        }

        /// <summary>
        /// The important notifier method of changed properties. This function should be called whenever you want to inform other classes that some property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the updated property. Leaving this blank will fill in the name of the calling property.</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
