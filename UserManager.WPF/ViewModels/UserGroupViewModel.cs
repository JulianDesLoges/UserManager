using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Shared.Models;

namespace UserManager.WPF.ViewModels
{
    /// <summary>
    /// ViewModel for UserGroups in UserExplorer
    /// </summary>
    public class UserGroupViewModel : ViewModelBase
    {
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _id;


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


        public ObservableCollection<UserViewModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private ObservableCollection<UserViewModel> _users;
    }
}
