using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.VisualStudio.Presentation;

namespace XVSBrushes
{
    public class BrushesSetViewModel : ViewModel
    {
        private Type type;

        public BrushesSetViewModel(Type type, bool hasDirectBrushValues = false)
        {
            var names = type.FullName.Split('.');
            var lastTwoNames = names.Skip(Math.Max(0, names.Count() - 2)).ToArray();
            Title = lastTwoNames[0] + "." + lastTwoNames[1];
            this.type = type;
            Brushes = new ObservableCollection<BrushViewModel>();
            foreach(var prop in type.GetProperties())
            {
                if (!hasDirectBrushValues || prop.Name.EndsWith("Brush"))
                {
                    Brushes.Add(new BrushViewModel
                    {
                        Property = prop,
                        ContainingTypeName = Title,
                        HasDirectBrushValues = hasDirectBrushValues
                    });
                }
            }
        }

        public ObservableCollection<BrushViewModel> Brushes { get; private set; }

        public string Title { get; set; }
    }
}
