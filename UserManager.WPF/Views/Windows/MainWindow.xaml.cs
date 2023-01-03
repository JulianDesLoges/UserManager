using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserManager.Shared;
using UserManager.WPF.Services;
using UserManager.WPF.ViewModels;
using UserManager.WPF.ViewModels.DetailViewModels;
using UserManager.WPF.Views.UserControls;

namespace UserManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = (MainWindowViewModel)DataContext;
        }


        private void UserExplorer_SelectionChanged(object obj)
        {
            
            
            if (obj.GetType() == typeof(UserGroupViewModel))
            {
                Debug.WriteLine("SelectionChanged: UserGroupDetailViewModel Opening");
                _viewModel.CurrentDetailViewModel = new UserGroupDetailViewModel();
            }
            else if (obj.GetType() == typeof(UserViewModel))
            {
                Debug.WriteLine("SelectionChanged: UserDetailViewModel Opening");
                _viewModel.CurrentDetailViewModel = new UserDetailViewModel();
            }
        }
    }
}
