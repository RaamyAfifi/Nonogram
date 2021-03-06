using NonogramModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using Nonogram.Pages;

namespace Nonogram.ViewModels
{
    public class CreatePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CreatedPuzzle newPuzzle = new CreatedPuzzle("", "");
        public ICommand CreateCommand { get; set; }
        public int Xas { get; set; } = 10;
        public int Yas { get; set; } = 10;

        public CreatePageViewModel()
        {
            CreateCommand = new RelayCommand(createPuzzle);
        }

        /// <summary>
        /// create a CreatedPuzzle and send user to the design page with the puzzle as parameter
        /// </summary>
        private void createPuzzle()
        {
            var puzzle = new Puzzle(Xas, Yas);
            NewPuzzle.Puzzle = puzzle;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(DesignPage), JsonConvert.SerializeObject(NewPuzzle));
        }

        public CreatedPuzzle NewPuzzle
        {
            get => newPuzzle;
            set
            {
                newPuzzle = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
