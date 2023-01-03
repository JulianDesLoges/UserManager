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
    /// ViewModel for UserExplorer
    /// </summary>
    public class UserExplorerViewModel : ViewModelBase
    {
        public ObservableCollection<UserGroupViewModel> UserGroups
        {
            get => _userGroups;
            set
            {
                _userGroups = value;
                OnPropertyChanged(nameof(UserGroups));
            }
        }

        private ObservableCollection<UserGroupViewModel> _userGroups;
    }
}
