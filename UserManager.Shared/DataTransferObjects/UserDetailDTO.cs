using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Shared.DataTransferObjects
{
    public class UserDetailDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyId { get; set; }

        public CompanyDTO Company { get; set; }

        public int GroupId { get; set; }
    }
}
