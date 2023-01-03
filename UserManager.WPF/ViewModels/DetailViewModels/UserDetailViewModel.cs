using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Shared.DataTransferObjects;

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


        public UserDetailViewModel(UserDetailDTO user)
        {
            Id = user.Id;
            _firstName = user.FirstName;
            _lastName = user.LastName;
            _companyId = user.CompanyId;
            _companyName = user.Company.Name;
            GroupId = user.GroupId;
        }
    }
}
