using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using UserManager.WPF.Services;
using UserManager.WPF.ViewModels;

namespace UserManager.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UserExplorer.xaml
    /// </summary>
    public partial class UserExplorer : UserControl
    {
        public event Action<object>? SelectionChanged;
        private readonly WebApi _webApi;


        public UserExplorer()
        {
            InitializeComponent();

            _webApi = App.Services.GetService<WebApi>() ?? throw new Exception("WebApi Service not available.");
        }


        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
            => SelectionChanged?.Invoke(((TreeView)sender).SelectedItem);
    }
}
