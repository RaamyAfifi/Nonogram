using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using Nonogram.Pages;

namespace Nonogram.ViewModels
{
    public class NavBarViewModel
    {
        public ICommand AllPuzzleCommand { get; set; }
        public ICommand CreatePuzzleCommand { get; set; }

        public NavBarViewModel()
        {
            AllPuzzleCommand = new RelayCommand(GotoAllPuzzles);
            CreatePuzzleCommand = new RelayCommand(GotoCreatePuzzle);
        }

        public static void GotoAllPuzzles()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(OverviewPage));
        }

        public static void GotoCreatePuzzle()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(CreatePage));
        }
    }
}
