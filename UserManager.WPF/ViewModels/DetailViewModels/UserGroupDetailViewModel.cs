using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserManager.Shared.DataTransferObjects;
using UserManager.WPF.Services;

namespace UserManager.WPF.ViewModels.DetailViewModels
{
    /// <summary>
    /// ViewModel for the user group detail view.
    /// </summary>
    public class UserGroupDetailViewModel : ViewModelBase, IDetailViewModel
    {
        public int Id { get; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _name;


        public bool ReadPermission
        {
            get => _readPermission;
            set
            {
                _readPermission = value;
                OnPropertyChanged(nameof(ReadPermission));
            }
        }

        private bool _readPermission;


        public bool ContributePermission
        {
            get => _contributePermission;
            set
            {
                _contributePermission = value;
                OnPropertyChanged(nameof(ContributePermission));
            }
        }

        private bool _contributePermission;


        public bool CreatePermission
        {
            get => _createPermission;
            set
            {
                _createPermission = value;
                OnPropertyChanged(nameof(CreatePermission));
            }
        }

        private bool _createPermission;


        public bool ManagePermission
        {
            get => _managePermission;
            set
            {
                _managePermission = value;
                OnPropertyChanged(nameof(ManagePermission));
            }
        }

        private bool _managePermission;


        private readonly WebApi _webApi;
        private readonly UserGroupViewModel _userGroupViewModel;


        public UserGroupDetailViewModel(UserGroupViewModel userGroupViewModel, UserGroupDetailDTO userGroup)
        {
            _userGroupViewModel = userGroupViewModel;
            Id = userGroup.Id;
            _name = userGroup.Name;
            _readPermission = userGroup.ReadPermission;
            _contributePermission = userGroup.ContributePermission;
            _createPermission = userGroup.CreatePermission;
            _managePermission = userGroup.ManagePermission;

            _webApi = App.Services.GetService<WebApi>() ?? throw new Exception("WebApi Service not available.");
        }


        public async void UpdateDetails()
        {
            Debug.WriteLine("Updating UserGroup");
            var response = await _webApi.PutAsync($"UserGroup/{Id}", new UserGroupDetailDTO()
            {
                Id = Id,
                Name = Name,
                ReadPermission = ReadPermission,
                ContributePermission = ContributePermission,
                CreatePermission = CreatePermission,
                ManagePermission = ManagePermission
            });


            if (response.IsSuccessStatusCode)
            {
                _userGroupViewModel.Name = Name;
                _userGroupViewModel.ReadPermission = ReadPermission;
                _userGroupViewModel.ContributePermission = ContributePermission;
                _userGroupViewModel.CreatePermission = CreatePermission;
                _userGroupViewModel.ManagePermission = ManagePermission;
            }
        }
    }
}
