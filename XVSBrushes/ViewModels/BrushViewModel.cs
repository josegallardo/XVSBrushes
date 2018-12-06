using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Xamarin.VisualStudio.Presentation;

namespace XVSBrushes
{
    public class BrushViewModel : ViewModel
    {
        public BrushViewModel()
        {
            CopyNameCommand = new RelayCommand(() => CopyName());
            IsVisible = true;
        }

        public bool HasDirectBrushValues { get; set; }
        public string ContainingTypeName { get; set; }
        private PropertyInfo property;

        public PropertyInfo Property
        {
            get { return property; }
            set
            {
                if (property != value)
                {
                    property = value;
                    OnPropertyChanged(nameof(Property));
                }
            }
        }

        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged(nameof(IsVisible));
                }
            }
        }

        public RelayCommand CopyNameCommand { get; private set; } 
        void CopyName()
        {
            Clipboard.SetText(ContainingTypeName + "." + this.Property.Name);
        }

        private Brush brushValue;

        public Brush BrushValue
        {
            get { return brushValue; }
            set
            {
                if (brushValue != value)
                {
                    brushValue = value;
                    OnPropertyChanged(nameof(BrushValue));
                }
            }
        }
    }
}
