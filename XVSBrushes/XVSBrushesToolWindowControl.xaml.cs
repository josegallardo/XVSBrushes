namespace XVSBrushes
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;
    using Xamarin.VisualStudio.Presentation.Theme;

    /// <summary>
    /// Interaction logic for XVSBrushesToolWindowControl.
    /// </summary>
    public partial class XVSBrushesToolWindowControl : UserControl
    {
        List<System.Reflection.PropertyInfo> selectedProperties = new List<System.Reflection.PropertyInfo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="XVSBrushesToolWindowControl"/> class.
        /// </summary>
        public XVSBrushesToolWindowControl()
        {
            this.InitializeComponent();
            //PopulateBackgroundBrushesControls();
            var viewModel = new XVSBrushesViewModel();
            viewModel.Sets.Add(new BrushesSetViewModel(typeof(Xamarin.VisualStudio.Presentation.Theme.Brushes)));
            viewModel.Sets.Add(new BrushesSetViewModel(typeof(VsBrushes)));
            viewModel.Sets.Add(new BrushesSetViewModel(typeof(SystemColors), true));
            viewModel.FindResourceFunction = FindResource;
            viewModel.RefreshBrushes();
            this.DataContext = viewModel;
        }
    }
}