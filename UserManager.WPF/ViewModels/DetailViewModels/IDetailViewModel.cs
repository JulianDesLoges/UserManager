using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.WPF.ViewModels.DetailViewModels
{
    /// <summary>
    /// Interface for ViewModels that are DetailViewModels.
    /// </summary>
    public interface IDetailViewModel
    {
        /// <summary>
        /// Handles how a detail view behaves if the update button was pressed.
        /// </summary>
        void UpdateDetails();
    }
}
