using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserManager.WPF.Commands;
using UserManager.WPF.ViewModels.DetailViewModels;

namespace UserManager.WPF.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        public IDetailViewModel? CurrentDetailViewModel
        {
            get => _detailViewModel;
            set
            {
                _detailViewModel = value;
                OnPropertyChanged(nameof(CurrentDetailViewModel));
            }
        }

        private IDetailViewModel? _detailViewModel;


        public ICommand UpdateDetailsCommand => new Command(_ => _detailViewModel?.UpdateDetails());
    }
}
