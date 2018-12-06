using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xamarin.VisualStudio.Presentation;

namespace XVSBrushes
{
    public class XVSBrushesViewModel : ViewModel
    {
        public ObservableCollection<BrushesSetViewModel> Sets { get; private set; }
        public RelayCommand HideUncheckedCommand { get; private set; }
        public RelayCommand UncheckAllCommand { get; private set; }
        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand ShowAllCommand { get; private set; }
        public Func<object, object> FindResourceFunction { get; internal set; }

        public XVSBrushesViewModel()
        {
            Sets = new ObservableCollection<BrushesSetViewModel>();
            HideUncheckedCommand = new RelayCommand(() => HideUnchecked());
            UncheckAllCommand = new RelayCommand(() => UncheckAll());
            ShowAllCommand = new RelayCommand(() => ShowAll());
            RefreshCommand = new RelayCommand(() => RefreshBrushes());
        }

        void HideUnchecked()
        {
            foreach (var brushset in Sets)
            {
                foreach (var brush in brushset.Brushes)
                {
                    brush.IsVisible = brush.IsChecked;
                }
            }
        }

        internal void RefreshBrushes()
        {
            foreach (var brushset in Sets)
            {
                foreach (var brush in brushset.Brushes)
                {
                    brush.BrushValue = brush.HasDirectBrushValues ? 
                        (Brush) brush.Property.GetValue(null) 
                        : (Brush) FindResourceFunction(brush.Property.GetValue(null));
                }
            }
        }

        void UncheckAll()
        {
            foreach (var brushset in Sets)
            {
                foreach (var brush in brushset.Brushes)
                {
                    brush.IsChecked = false;
                }
            }
        }

        void ShowAll()
        {
            foreach (var brushset in Sets)
            {
                foreach (var brush in brushset.Brushes)
                {
                    brush.IsVisible = true;
                }
            }
        }
    }
}
