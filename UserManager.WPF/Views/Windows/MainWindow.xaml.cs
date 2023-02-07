using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UserManager.Shared.DataTransferObjects;
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
        private readonly WebApi _webApi;
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = (MainWindowViewModel)DataContext;
            _webApi = App.Services.GetService<WebApi>() ?? throw new Exception("WebApi Service not available.");
        }


        private async void UserExplorer_SelectionChanged(object obj)
        {
            // TODO use Dictionary / Application.Resources for this.
            if (obj is UserGroupViewModel userGroup)
            {
                // Request user group details
                var result = await _webApi.GetAsync($"UserGroup/{userGroup.Id}");

                if (!result.IsSuccessStatusCode) { throw new Exception("Failed to request UserGroup details."); }

                var groupDetails = await result.Content.ReadFromJsonAsync<UserGroupDetailDTO>();

                if (groupDetails == null) { throw new Exception("Invalid UserGroup details layout."); }

                Debug.WriteLine("SelectionChanged: UserGroupDetailViewModel Opening");
                _viewModel.CurrentDetailViewModel = new UserGroupDetailViewModel(userGroup, groupDetails);
            }
            else if (obj is UserViewModel user)
            {
                var result = await _webApi.GetAsync($"User/{user.Id}");

                if (!result.IsSuccessStatusCode) { throw new Exception("Failed to request User details."); }

                var userDetails = await result.Content.ReadFromJsonAsync<UserDetailDTO>();

                if (userDetails == null) { throw new Exception("Invalid User details layout."); }

                Debug.WriteLine("SelectionChanged: UserDetailViewModel Opening");
                _viewModel.CurrentDetailViewModel = new UserDetailViewModel(user, userDetails);
            }
            else
            {
                throw new Exception("Unknown UserExplorer selection.");
            }
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Init UserExplorer
            UpdateUserExplorer();
        }


        private async void UpdateUserExplorer()
        {
            var response = await _webApi.GetAsync("UserGroup");

            if (!response.IsSuccessStatusCode) { throw new Exception("Failed to request UserGroups"); }

            var userGroups = await response.Content.ReadFromJsonAsync<ObservableCollection<UserGroupViewModel>>();

            if (userGroups == null) { throw new Exception("Invalid UserGroups layout."); }

            ((UserExplorerViewModel)_userExplorer.DataContext).UserGroups = userGroups;
        }
    }
}
