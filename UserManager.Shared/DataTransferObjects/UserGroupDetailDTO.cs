using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Shared.DataTransferObjects
{
    public class UserGroupDetailDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool ReadPermission { get; set; }

        public bool ContributePermission { get; set; }

        public bool CreatePermission { get; set; }

        public bool ManagePermission { get; set; }
    }
}
