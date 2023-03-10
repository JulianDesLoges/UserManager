using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Shared.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public int GroupId { get; set; }

        public virtual UserGroup Group { get; set; }
    }
}
