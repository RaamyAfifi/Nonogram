using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace NonogramModels
{
    public class Cell :INotifyPropertyChanged
    {
        // Check for if cell is crossed
        private bool isCrossed;
        // Check for if cell is colored
        private bool isColored;

        private Color rgba = Colors.White;
        public event PropertyChangedEventHandler PropertyChanged;

        public Color RGBA
        {
            get => rgba;
            set
            {
                rgba = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsCrossed
        {
            get => isCrossed;
            set
            {
                isCrossed = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsColored
        {
            get => isColored;
            set
            {
                isColored = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
