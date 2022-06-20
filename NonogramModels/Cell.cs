using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// NotifyPropertyChanged() is needed for updating the color. Without it, the system won't know
        /// that the color has changed during the run time.
        /// </summary>
        public Color RGBA
        {
            get => rgba;
            set
            {
                rgba = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// NotifyPropertyChanged() is needed for updating the cell. Without it, the system won't know
        /// that the cell has changed during the run time.
        /// </summary>
        public bool IsCrossed
        {
            get => isCrossed;
            set
            {
                isCrossed = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// NotifyPropertyChanged() is needed for updating the cell. Without it, the system won't know
        /// that the cell has changed during the run time.
        /// </summary>
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
