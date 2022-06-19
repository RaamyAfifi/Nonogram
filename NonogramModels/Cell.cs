using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace NonogramModels
{
    public class Cell
    {
        private bool isCrossed;
        private bool isColored;
        private Color rgba = Colors.White;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
