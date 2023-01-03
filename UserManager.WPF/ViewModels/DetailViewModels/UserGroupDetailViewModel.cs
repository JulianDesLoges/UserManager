using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.WPF.ViewModels.DetailViewModels
{
    /// <summary>
    /// ViewModel for the user group detail view.
    /// </summary>
    public class UserGroupDetailViewModel : ViewModelBase, IDetailViewModel
    {
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


        public UserGroupDetailViewModel(UserGroupViewModel userGroup)
        {
            _name = userGroup.Name;
            _readPermission = userGroup.ReadPermission;
            _contributePermission = userGroup.ContributePermission;
            _createPermission = userGroup.CreatePermission;
            _managePermission = userGroup.ManagePermission;
        }
    }
}
