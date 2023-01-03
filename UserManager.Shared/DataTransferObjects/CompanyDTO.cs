using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Shared.DataTransferObjects
{
    public class CompanyDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
