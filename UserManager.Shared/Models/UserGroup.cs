using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Shared.Models
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ReadPermission { get; set; }

        public bool ContributePermission { get; set; }

        public bool CreatePermission { get; set; }

        public bool ManagePermission { get; set; }

        public ICollection<User> Users { get; set; } = new ObservableCollection<User>();
    }
}
