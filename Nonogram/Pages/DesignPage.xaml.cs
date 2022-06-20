using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Nonogram.ViewModels;
using NonogramModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Nonogram.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DesignPage : Page
    {
        public DesignPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Sets the data context to data context with the puzzle parameter
        /// </summary>
        /// <param name="e">containing a json sting with the CreatedPuzzle object</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CreatedPuzzle puzzle = JsonConvert.DeserializeObject<CreatedPuzzle>((string)e.Parameter);
            DataContext = new DesignPageViewModel(puzzle);

            base.OnNavigatedTo(e);
        }
    }
}
