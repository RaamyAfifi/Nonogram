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
    public class CreatePageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateCommand { get; set; }

        private CreatedPuzzle newPuzzle = new CreatedPuzzle("", "");
    }
}
