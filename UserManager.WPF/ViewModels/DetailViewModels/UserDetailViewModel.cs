using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Shared.DataTransferObjects;
using UserManager.WPF.Services;

namespace UserManager.WPF.ViewModels.DetailViewModels
{
    /// <summary>
    /// ViewModel for the user detail view.
    /// </summary>
    public class UserDetailViewModel : ViewModelBase, IDetailViewModel
    {
        public int Id { get; }

        
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string _firstName;


        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string _lastName;


        public int CompanyId
        {
            get => _companyId;
            set
            {
                _companyId = value;
                OnPropertyChanged(nameof(CompanyId));
            }
        }

        public int _companyId;


        public string CompanyName
        {
            get => _companyName;
            set
            {
                _companyName = value;
                OnPropertyChanged(nameof(CompanyName));
            }
        }

        public string _companyName;


        public int GroupId { get; }


        private readonly WebApi _webApi;
        private readonly UserViewModel _userViewModel;


        public UserDetailViewModel(UserViewModel userViewModel, UserDetailDTO user)
        {
            _userViewModel = userViewModel;
            Id = user.Id;
            _firstName = user.FirstName;
            _lastName = user.LastName;
            _companyId = user.CompanyId;
            _companyName = user.Company.Name;
            GroupId = user.GroupId;

            _webApi = App.Services.GetService<WebApi>() ?? throw new Exception("WebApi Service not available.");
        }


        public async void UpdateDetails()
        {
            var response = await _webApi.PutAsync($"User/{Id}", new UserDetailDTO()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                CompanyId = CompanyId,
                GroupId = GroupId,
                Company = new CompanyDTO()
                {
                    Name = CompanyName,
                    Id = CompanyId
                },
            });


            if (response.IsSuccessStatusCode)
            {
                _userViewModel.FirstName = FirstName;
                _userViewModel.LastName = LastName;
            }
        }
    }
}
